using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private Image characterPortrait;
    [SerializeField] private float textSpeed;

    private Sprite lastCharacterPortrait;

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
        characterPortrait.sprite = dm.portrait;

        if (dm.portrait != null)
            lastCharacterPortrait = dm.portrait;
        else
            characterPortrait.sprite = lastCharacterPortrait;
    }

    public void QueMessage(DialogueMessage message)
    {
        quedMessages.Enqueue(message);
    }

    public void ShowQuedMessage()
    {
        if (quedMessages.Count <= 0)
            return;

        StopAllCoroutines();

        SetMessageTexts(quedMessages.Dequeue());

        StartCoroutine("TypeWriteText");
    }
    public void InitDialogue()
    {
        if (dialogue == null) return;

        foreach (DialogueMessage dm in dialogue.messages)
        {
            QueMessage(dm);
        }
    }

    private IEnumerator TypeWriteText()
    {
        int totalCharacters = dialogueText.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            counter++;
            dialogueText.maxVisibleCharacters = counter;

            yield return new WaitForSeconds(1/textSpeed);
        }
    }
}
