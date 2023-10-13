using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Conversation", fileName = "new Conversation")]
public class ConversationSO : ScriptableObject
{
    [SerializeField] [TextArea] private List<string> dialogs;

    public List<string> GetDialogs()
    {
        return dialogs;
    }
}
