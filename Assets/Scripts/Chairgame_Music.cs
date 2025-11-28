using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class Chairgame_Music : MonoBehaviour
{
    Chairsgame_base chairsgame_Base;
    public AudioSource audiosource;
    private float randomPlayTIme;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomPlayTIme = Random.Range(5f, 30f);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AudioPlay()
    {
        audiosource.Play();
        Invoke("Stopmusic", randomPlayTIme);
        yield break;
    }
    void StopMusic()
    {
        audiosource.Stop();
        chairsgame_Base.MovePos(true);
    }
}
