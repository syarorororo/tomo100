using System.Collections;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] double Time;
    [SerializeField]
    Character_Text_Data data;
    [SerializeField]
    Text_Controler con;
    void Start()
    {/*
        //StartCoroutine(time(Time));
        Debug.Log(data.CharacterName);
        Debug.Log(data.Data[0].Text);
        Debug.Log(data.Data[1].Text);
        Debug.Log(data.Data[0].Side);

        StartCoroutine(con.textcol(data.Data[0].Text));*/
    }
    
    IEnumerator time(double time)
    {
        for(double i = 0; i <= time; i += 0.1f)
        {
            Debug.Log($"Time:{(float)0.1f * (int)(i * 10)}");
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("End");
        yield break;
    }
}
