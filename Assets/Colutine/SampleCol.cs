using System.Collections;
using UnityEngine;

//Unityのコルーチン解説Script　　＃間違ってるかもしれん
public class SampleCol : MonoBehaviour
{
    //コルーチンはメゾット（いわゆる関数）のように使える
    //メゾットと違うのは関数外に出るための方法がいくつかある
    IEnumerator Col1()//コルーチンの基本形
    {
        Debug.Log("A");
        yield break;//Breakで終了する
        Debug.Log("B");
    }

    IEnumerator Col2()//基本形2・・基本的にこちらを使う
    {
        Debug.Log("2A");
        yield return null;//一度関数外に出る
        //待ち時間は外による
        //戻ってきたときここから始まる
        Debug.Log("2B");
        //下まで来たら終了する
    }

    IEnumerator Col3() 
    {
        Debug.Log("A");
        yield return new WaitForSeconds(0.1f);//0.1秒待って再開
        Debug.Log("B");
    }

    IEnumerator Col4()
    {
        Debug.Log("A");
        yield return new WaitUntil(() => A);//trueの場所で止まる・・trueなら再開・・falseなら止まり続ける
        A = false;
        Debug.Log("B");
    }

    IEnumerator Col5()
    {
        Debug.Log("A");
        yield return StartCoroutine(Col2());
        Debug.Log("B");
    }
    private IEnumerator X;//コルーチンを格納する変数がある

    public bool A = false;
    private void Start()
    {
        X = Col1();
        StartCoroutine(Col4());//コルーチンスタート
        StartCoroutine(X);
    }
}
