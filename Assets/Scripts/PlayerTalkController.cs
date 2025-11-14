using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Mono.Cecil.Cil;
public class PlayerTalkController : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    public int x = 0;//会話量
    public int P_sele;//プレイヤーの選択肢
    [SerializeField]
    Text_Controler T_con;
    [SerializeField] 
    Character_Text_Data[] data;
    [SerializeField]
    public GameObject TalkWindow;
    [SerializeField]
    public GameObject SelectPanel;
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
        SelectPanel.SetActive(false);
      
    }
    public void OnTalk(InputAction.CallbackContext context)
    {
        if(context.started && isTalk)
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
        /*
        yield return StartCoroutine(T_con.textcol(data.Data[0].Text));
        IsPush = false ;
        yield return new WaitUntil(() => IsPush);
        yield return new WaitForSeconds(1f);*/

        x = data[0].Data.Length;
        Debug.Log("Start of Loop");
        for(int i = 0;i<x;i++)
          {
            Debug.Log("Text for Loop");
             yield return StartCoroutine(T_con.textcol(data[0].Data[i].Text));
             IsPush=false;
            Debug.Log($"x={i}");
             yield return new WaitUntil(() => IsPush);
             IsPush=false;
          } 
        yield return StartCoroutine(SelectCol());
        yield break;
    }
    IEnumerator SelectTalkCol(int a)
    {
        
        x=data[a].Data.Length;  
        for (int i = 0; i < x; i++)
        {
            Debug.Log("Text for Loop");
            yield return StartCoroutine(T_con.textcol(data[a].Data[i].Text));
            IsPush = false;
            Debug.Log($"x={i}");
            yield return new WaitUntil(() => IsPush);
            IsPush = false;
        }
        
        yield break;
    }
    IEnumerator SelectCol()
    {
       SelectPanel.SetActive(true);
        yield return new WaitUntil(() => IsPush);
        SelectPanel.SetActive(false);
        switch (P_sele)
        {
            case 0://はい
                yield return StartCoroutine(SelectTalkCol(1));
               
                break;
            case 1://いいえ
                yield return StartCoroutine(SelectTalkCol(2));
                
                break;
        }
    yield break ;
        
    }
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            IsPush = true;
        }
    }
    
    public void OnClick(int v)
    {
        P_sele = v;
        IsPush = true;
    }
}
