using UnityEngine;

[System.Serializable]
public class Chara_data2 : MonoBehaviour
{
    public string characterName;   // キャラクターの名前
    public string dialogueText;    // セリフ内容
    public bool isPlayerResponse;  // プレイヤーの選択肢かどうか
    public string[] choices;       // 選択肢（ある場合）
}
[System.Serializable]
public class DialogueBranch
{
    public Chara_data2[] dialogues;    // この分岐に関連する会話群
    public int[] nextBranchIndices; // 各選択肢が選ばれた後に進む分岐のインデックス
}

[CreateAssetMenu(fileName = "NewConversation", menuName = "Conversation System/Conversation")]
public class Conversation : ScriptableObject
{
    public string conversationName;   // 会話名
    public DialogueBranch[] branches; // 各分岐の会話データ
}