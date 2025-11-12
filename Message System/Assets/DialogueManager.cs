using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI characterText;

    Queue<DialogueMessage> quedMessages = new Queue<DialogueMessage>();

    private void Start()
    {
        InitDialogue();
        ShowQuedMessage();
    }

    public void SetMessageTexts(DialogueMessage dm)
    {
        dialogueText.text = dm.message;
        characterText.text = dm.characterName;
    }

    public void QueMessage(DialogueMessage message)
    {
        quedMessages.Enqueue(message);
    }

    public void ShowQuedMessage()
    {
        if (quedMessages.Count > 0)
            SetMessageTexts(quedMessages.Dequeue());
    }
    public void InitDialogue()
    {
        if (dialogue == null) return;

        foreach (DialogueMessage dm in dialogue.messages)
        {
            QueMessage(dm);
        }
    }
}
