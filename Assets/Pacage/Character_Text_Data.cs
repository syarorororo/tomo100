using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class TextSetting
{
    [SerializeField,Header("テキストデータ格納場所")]
    public string Text;
    [SerializeField,Header("しゃべる方にtrue")]
    public bool Side;
}

[CreateAssetMenu(fileName = "NewCharacter_Text_Data", menuName = "Text_Data")]
public class Character_Text_Data : ScriptableObject
{
    [SerializeField,Header("テキストデータ")]
    public TextSetting[] Data;
    [SerializeField,Header("キャラクター設定")]
    public string CharacterName;
    [SerializeField, Header("キャラクター画像")]
    public Sprite CharacterImage;
}