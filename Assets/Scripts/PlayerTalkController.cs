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
                Debug.Log("��bUI��\��");
            if(TalkWindow.activeSelf )
            {
                Debug.Log("��b�J�n�B��b�ȊO�̃v���O�������~");
                SetScriptsEnabled(false);
            }
            else
            {
                Debug.Log("��b�I��");
                SetScriptsEnabled(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "TalkNPC")
        {
            isTalk = true;
             Debug.Log("��b�\�ł�");
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
            Debug.Log("��b�\�ł�zo");
        }
        
    }*/
    // Update is called once per frame
    void Update()
    {
      
    }
}
