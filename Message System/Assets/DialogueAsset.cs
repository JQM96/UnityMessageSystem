using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDialogue")]
public class DialogueAsset : ScriptableObject
{
    public List<DialogueMessage> messages;
}