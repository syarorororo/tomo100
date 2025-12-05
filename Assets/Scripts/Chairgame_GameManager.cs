using System.Runtime.CompilerServices;
using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class Chairgame_GameManager : MonoBehaviour
{
    public Vector3 centerPoint = Vector3.zero;
    [SerializeField]
    private GameObject CreateObj;
    [SerializeField]
    public int CreateCount = 7;
    [SerializeField]
    public float radius = 3.0f;
    [SerializeField]
    public float repeat = 2f;
    Chairgame_Music C_Music;
    Chairsgame_base C_Base;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centerPoint = transform.position;
        StartCoroutine(CreateChair());
        C_Music = GetComponent<Chairgame_Music>();
        C_Base = GetComponent<Chairsgame_base>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateChair()
    {
        var oneCycle = 2.0f*Mathf.PI;
        for (var i = 0; i < CreateCount; i++)
        {
            var point = ((float)i/CreateCount)*oneCycle;
            var repeatPoint = point*repeat;
            
            var x = Mathf.Cos(repeatPoint)*radius;
            var y = Mathf.Sin(repeatPoint)*radius;

            var position = centerPoint +new Vector3(x,0, y);

            var obj = Instantiate(CreateObj,position,Quaternion.identity,transform);
            CreateObj.tag = "Chair";

            Vector3 dirFromCenter = (obj.transform.position - centerPoint).normalized;

            dirFromCenter.y = 0;
            if (dirFromCenter.sqrMagnitude > 0.001f)
            {
                obj.transform.rotation = Quaternion.LookRotation(dirFromCenter);
            }
        }
        yield break;
    }

    IEnumerator PlayGame()
    {
       if(CreateCount != 0)
        {
          C_Music.AudioPlay();
        }
        CreateCount -= 1;

        yield break;
    }
}
