using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "Game/Text/Saved/Data")]
public class Text_Data : ScriptableObject
{
    //もとのテキストデータ
    [SerializeField,Header("テキストデータ")]
    public string Text;
}

[CreateAssetMenu(fileName = "AllText_Data", menuName = "Game/Text/Saved/AllText_Data")]
public class Character_AllText_Data : ScriptableObject
{
    //データをまとめるやつ
    [SerializeField, Header("データのキャラクターネーム(確認用)")] private string Name;
    [SerializeField, Header("キャラクターテキストデータまとめ")] public Text_Data[] AllTextData;
}