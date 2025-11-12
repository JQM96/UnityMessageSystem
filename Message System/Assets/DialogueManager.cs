using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;

    Queue<string> quedMessages = new Queue<string>();

    private void Start()
    {
        InitDialogue();
        ShowQuedMessage();
    }

    public void SetText(string newText)
    {
        dialogueText.text = newText;
    }

    public void QueMessage(string message)
    {
        quedMessages.Enqueue(message);
    }

    public void ShowQuedMessage()
    {
        if (quedMessages.Count > 0)
            SetText(quedMessages.Dequeue());
    }
    public void InitDialogue()
    {
        if (dialogue == null) return;

        foreach (string line in dialogue.lines)
        {
            QueMessage(line);
        }
    }
}
