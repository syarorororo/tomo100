using UnityEngine;


[CreateAssetMenu(fileName = "Character_Data", menuName = "Game/Character_Data")]
public class Character_Data : ScriptableObject
{
    [SerializeField, Header("キャラクターネーム")] public string Name;
    [SerializeField, Header("キャラクターの画像")] public Sprite Image;
}
