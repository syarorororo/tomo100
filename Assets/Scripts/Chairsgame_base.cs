using UnityEngine;
using System.Collections;
public class Chairsgame_base : MonoBehaviour
{
    
    public GameObject CenterObj;
    public float rote_sp;

    private GameObject nearobj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nearobj = searchTag(gameObject, "Chair");

    }

    // Update is called once per frame
    void Update()
    {
        MovePos(false);
    }
   public void MovePos(bool i)
    {
        if (i)
        {
            transform.LookAt(nearobj.transform);
            transform.Translate(Vector3.forward* Time.deltaTime);   
        }
        else
        {
            transform.RotateAround(CenterObj.transform.position, Vector3.up, rote_sp * Time.deltaTime);
        }
    }
    
    GameObject searchTag(GameObject nowobj,string tagname)
    {
        float tmpDis = 0;
        float nearDis = 0;

        GameObject targetobj = null;
        foreach(GameObject obs in GameObject.FindGameObjectsWithTag(tagname))
        {
            tmpDis = Vector3.Distance(obs.transform.position, nowobj.transform.position);  
            
            if(nearDis == 0||nearDis >  tmpDis)
            {
                nearDis = tmpDis;
                targetobj = obs; 
            }
        }
        return targetobj;
    }
}
