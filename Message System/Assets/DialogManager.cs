using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;

    Queue<string> quedMessages = new Queue<string>();

    private void Start()
    {
        QueMessage("Very simple implementation...");
        QueMessage("...");
        QueMessage("Yes...");
        QueMessage("Very simple...");
        QueMessage("Very implementation...");
        QueMessage("...");
    }

    public void SetText(string newText)
    {
        dialogText.text = newText;
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
}
