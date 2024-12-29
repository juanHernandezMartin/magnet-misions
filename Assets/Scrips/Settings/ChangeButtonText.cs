using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonText : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    public void Start()
    {
        string languageCode = SharedState.StartGameData["languageCode"];
        string text = SharedState.LanguageDefs[buttonText.text];
        buttonText.text = text;
    }
}
