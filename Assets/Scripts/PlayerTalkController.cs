using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerTalkController : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    int x = 0;//会話量
    [SerializeField]
    Text_Controler T_con;
    [SerializeField] 
    Character_Text_Data data;
    [SerializeField]
    public GameObject TalkWindow;
    [SerializeField]
    public MonoBehaviour[] ScriptsToDisable;
    private TextMeshProMode TextmeshProMode;
    private TextMeshPro _textMeshPro;
    private TextMeshProUGUI textMeshProUGUI;
    private TMP_Text TMP_Text;

    bool isTalk = false;
    public bool IsPush = false;
    
    public enum TextMeshProMode{TextMeshPro,TextMeshProUGUI,TMP_Text}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TalkWindow.SetActive(false);
        StartCoroutine(TalkCol());
    }
    public void OnTalk(InputAction.CallbackContext context)
    {
        if(context.performed && isTalk)
        {
            
            TalkWindow.SetActive(true);
            Debug.Log("会話UIを表示");  
            
            Debug.Log("会話開始。会話以外のプログラムを停止");
            SetScriptsEnabled(false);
            StartCoroutine(Whilecol());              
            Debug.Log("会話終了");
            
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "TalkNPC")
        {
            isTalk = true;
             Debug.Log("会話可能です");
        }
    }
    public void SetScriptsEnabled(bool enabled)
    {
        foreach (var script in ScriptsToDisable)
        {
            if(script != null)
            {
                script.enabled = enabled;
            }
        }
    }

    IEnumerator Whilecol()
    {
        yield return StartCoroutine(TalkCol());
        SetScriptsEnabled(true);
        TalkWindow.SetActive(false);
    }
   IEnumerator TalkCol()
    {

        yield return StartCoroutine(T_con.textcol(data.Data[0].Text));
        IsPush = false ;
        yield return new WaitUntil(() => IsPush);
        yield return new WaitForSeconds(2f);
        /*     
          for(int i = 0;i<x;i++)
          {
             yield return StartCoroutine(T_con.textcol(data.Data[i].Text));
             IsPush=false;
             yield return new WaitUntil(() => Ispush);
             IsPush=false;
          } */
        yield break;
    }
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            IsPush = true;
        }
    }
}
