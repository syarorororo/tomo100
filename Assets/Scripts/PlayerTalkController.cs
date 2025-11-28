using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Mono.Cecil.Cil;
using UnityEngine.UIElements;
public class PlayerTalkController : MonoBehaviour
{
    
    
    bool isTalk = false;
    public bool IsPush = false;
    [SerializeField] MakeConversation_Text_Data data;
    public enum TextMeshProMode{TextMeshPro,TextMeshProUGUI,TMP_Text}
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        StartCoroutine(col(data.Datas));
    }

    IEnumerator col(Setting_Text_Data[] data)
    {
        foreach (var item in data)
        {
            Debug.Log(item.Data.Text);
            if(item.s != null)
            {
                StartCoroutine(col(item.s.Switch_Data[0].Switched_Data));
            }
            
        }
        yield break;
    }

}

public class IE
{ }

