using System.Collections;
using TMPro;
using UnityEngine;

public class Text_Controler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField, Header("•\Ž¦ŠÔŠu")] float Speed = 0.1f;
    public IEnumerator textcol(string data)
    {
        /*
         * foreach( var c in data ){
           text.text += c;
           yield return new WaitForSeconds(Speed);
         }
         */
        text.maxVisibleCharacters = 0;
        text.text = data;
        for(int i = 0; i < data.Length; i++)
        {
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(Speed);
        }
        yield break;
    }
}
