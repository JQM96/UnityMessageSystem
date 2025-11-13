using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private Image characterPortrait;

    [Header("Typewriter effect")]
    [SerializeField] private float textSpeed;
    [SerializeField] private AudioSource textAudioSource;
    [SerializeField] private AudioClip textAudioClip;

    [Header("Voice lines")]
    [SerializeField] private AudioSource voiceLinesAudioSource;

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

        if (voiceLinesAudioSource != null)
            voiceLinesAudioSource.clip = dm.voiceLine;

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
        if (voiceLinesAudioSource != null)
            voiceLinesAudioSource.Play();

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
        dialogueText.maxVisibleCharacters = 0;

        while (true)
        {

            if (dialogueText.textInfo.characterInfo[dialogueText.maxVisibleCharacters].character != ' ')
            {
                textAudioSource.pitch = Random.Range(0.9f, 1.1f);
                textAudioSource.PlayOneShot(textAudioClip);
            }

            dialogueText.maxVisibleCharacters++;

            yield return new WaitForSeconds(1 / textSpeed);

            if (dialogueText.maxVisibleCharacters >= dialogueText.textInfo.characterCount)
            {
                break;
            }
        }
    }
}
