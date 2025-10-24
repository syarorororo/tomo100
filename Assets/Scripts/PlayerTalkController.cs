using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using TMPro;
public class PlayerTalkController : MonoBehaviour
{
    [SerializeField]
    public GameObject TalkWindow;
    [SerializeField]
    public MonoBehaviour[] ScriptsToDisable;
    private TextMeshProMode TextmeshProMode;
    private TextMeshPro _textMeshPro;
    private TextMeshProUGUI textMeshProUGUI;
    private TMP_Text TMP_Text;

    bool isTalk = false;
    
    public enum TextMeshProMode{TextMeshPro,TextMeshProUGUI,TMP_Text}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TalkWindow.SetActive(false);

    }
    public void OnTalk(InputAction.CallbackContext context)
    {
        if(context.performed && isTalk)
        {
            
                TalkWindow.SetActive(true);
                Debug.Log("会話UIを表示");
            if(TalkWindow.activeSelf )
            {
                Debug.Log("会話開始。会話以外のプログラムを停止");
                SetScriptsEnabled(false);
            }
            else
            {
                Debug.Log("会話終了");
                SetScriptsEnabled(true);
            }
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
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag =="TalkNPC")
        {
            Debug.Log("会話可能ですzo");
        }
        
    }*/
    // Update is called once per frame
    void Update()
    {
      
    }
}
