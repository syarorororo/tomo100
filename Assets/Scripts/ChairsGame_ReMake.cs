using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ChairsGame_ReMake : MonoBehaviour
{
    /*
     椅子取りゲームで作るべきもの
    ・椅子までの移動　済
    ・回転（音楽なってるとき）済
    ・椅子を取られた時の対象の変更
    ・椅子を少なくしてゲームのリスタート
  　  一連をコルーチン操作でやってみる
    ・リザルト
    次やること
    ・ゲームマネージャーの参照をとる
    ・そのオブジェクトからこのスクリプトを参照
    ・この中のセンターオブジェクトを参照
     */
    public bool St=false;
   // public bool end=false;
    ChairGame_Player player;
    Chairsgame_base enemy;
    public AudioSource audiosource;
    private float randomPlayTIme;//音楽再生時間
    private float randomWaitTIme;//待機時間
    public Vector3 centerPoint = Vector3.zero;
    [SerializeField]
    private GameObject CreateObj;//生成するオブジェクト
    [SerializeField]
    private GameObject CreateCharaObj;//生成するキャラオブジェクト
    [SerializeField]
    private GameObject centobj;
    [SerializeField]
    public int CreateCount = 7;//椅子を生成する数
    [SerializeField]
    public float radius = 3.0f;//生成する円の半径
    [SerializeField]
    public int CreateCharaCount = 8;//キャラを生成する数
    [SerializeField]
    public float C_radius = 6.0f;//生成する円の半径(キャラ)
    [SerializeField]
    public float repeat = 2f;
    [SerializeField]
    Text TimerText;
    [SerializeField]
    Text ResultText;
    float limitTime = 3;
    [SerializeField]
    public GameObject Panel;
    [SerializeField]
    public GameObject ResultPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomPlayTIme = Random.Range(5f, 30f);//音楽を流す時間設定
        randomWaitTIme = Random.Range(0f, 2f);//待機時間設定
        centerPoint = transform.position;
        ResultPanel.SetActive(false);
        StartCoroutine(GameMaster());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------ゲームをまとめるコルーチン------------------
    IEnumerator GameMaster()
    {
        Debug.Log("GameMasterが読み込まれました");
       // while(CreateCount<1)
       // {
         Debug.Log("ゲームループ開始");
        yield return StartCoroutine(CreateChair());
        yield return StartCoroutine(CharaCreate());
        yield return StartCoroutine(StartGame());
        yield return StartCoroutine(MusicController());
           //CreateCount -= 1;
          //CreateCharaCount -= 1;
      // }
        //yield return new WaitUntil(() => end);
        yield return StartCoroutine(EndedGame());
        Debug.Log("ゲームループ終了");           
        yield break;
    }
    //--------------------ゲーム終了のコルーチン----------------------
    IEnumerator EndedGame()
    {
        ResultPanel.SetActive(true);
        ResultText.text = "Finish!!";
        yield return new WaitForSeconds(2f);
        ResultText.text = "";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
        yield break;
    }
    //--------------------ゲームの開始前のコルーチン------------------
    IEnumerator StartGame()
    {
        limitTime -= Time.deltaTime;
        TimerText.text = limitTime.ToString("F0");
        if (limitTime < 0)
        {
            limitTime = 0;
            St = true;
        }
        yield return new WaitUntil(()=>St);
        St = false;
        Panel.SetActive(false);
        yield break;
    }
    //--------------------音楽を流して止めるコルーチン----------------
    IEnumerator MusicController()
    {
        audiosource.Play();
        Debug.Log("音楽が流れ始めました。");
        yield return new WaitForSeconds(randomPlayTIme);
        audiosource.Stop();
        Debug.Log("音楽が止まりました。");
        player.ClickMouse(true);
        yield return new WaitForSeconds(randomWaitTIme);
        enemy.MovePos(true);
        yield break;
    }
    //--------------------椅子を円形に生成するコルーチン--------------
    IEnumerator CreateChair()
    {
        Debug.Log("CreateChairが読み込まれました");
        var oneCycle = 2.0f * Mathf.PI;
        if(CreateCount>=1)
        {
            for (var i = 0; i < CreateCount; i++)
            {
                float angle = (float)i / CreateCount * oneCycle;

                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;
                /*
                var point = ((float)i / CreateCount) * oneCycle;
                var repeatPoint = point * repeat;

                var x = Mathf.Cos(repeatPoint) * radius;
                var y = Mathf.Sin(repeatPoint) * radius;
                */
                var position = centerPoint + new Vector3(x, 0, y);

                var obj = Instantiate(CreateObj, position, Quaternion.identity, transform);
                CreateObj.tag = "Chair";

                Vector3 dirFromCenter = (obj.transform.position - centerPoint).normalized;

                dirFromCenter.y = 0;
                if (dirFromCenter.sqrMagnitude > 0.001f)
                {
                    obj.transform.rotation = Quaternion.LookRotation(dirFromCenter);
                }
            }
        Debug.Log("椅子の生成が終わりました。");
        }
        else
        {
           StartCoroutine(EndedGame());//ゲーム終了
        }
            yield break;
    }
    //--------------------キャラを円形に生成するコルーチン--------------
    IEnumerator CharaCreate()
    {
        Debug.Log("CharaCreateが読み込まれました");
        var oneCycle = 2.0f * Mathf.PI;
        if (CreateCharaCount >= 2)
        {
            for (var i = 0; i < CreateCharaCount; i++)
            {
                float angle = (float)i / CreateCharaCount * oneCycle;

                float x = Mathf.Cos(angle) * C_radius;
                float y = Mathf.Sin(angle) * C_radius;
                /*
                var point = ((float)i / CreateCharaCount) * oneCycle;
                var repeatPoint = point * repeat;

                var x = Mathf.Cos(repeatPoint) * C_radius;
                var y = Mathf.Sin(repeatPoint) * C_radius;
                */
                var position = centerPoint + new Vector3(x, 0, y);

                var C_obj = Instantiate(CreateCharaObj, position, Quaternion.identity, transform);
              
                Vector3 dirFromCenter = (C_obj.transform.position - centerPoint).normalized;

                dirFromCenter.y = 0;
               
            }
            Debug.Log("キャラの生成が終わりました。");
            
        }
        else
        {
            StartCoroutine(EndedGame());//ゲーム終了
        }
        yield break;
       
    }
}
