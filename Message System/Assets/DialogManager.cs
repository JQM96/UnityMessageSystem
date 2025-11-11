using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;

    private void Start()
    {
        SetText("Very simple implementation...");
    }

    public void SetText(string newText)
    {
        dialogText.text = newText;
    }
}
