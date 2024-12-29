using System.Collections;
using System.Collections.Generic;
using LoLSDK;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public string nextSceneName;
    public string[] lines;
    [SerializeField] private TextMeshProUGUI dialogueText; // Reference to the TextMeshPro component
    [SerializeField] private GameObject dialogueBox;      // Reference to the dialogue box panel
    [SerializeField] private float typingSpeed = 0.05f;   // Speed of text appearance

    private Queue<string> dialogueLines; // Queue to hold dialogue lines
    private bool isTyping = false;      // Flag to check if text is still being typed
    private AudioSource audioText;

    public void Start()
    {
        audioText = GetComponent<AudioSource>();
        dialogueLines = new Queue<string>();
        dialogueBox.SetActive(false); // Initially hide the dialogue box
        StartDialogue();
    }

    public void StartDialogue()
    {
        dialogueBox.SetActive(true); // Show the dialogue box
        dialogueLines.Clear();      // Clear any previous dialogue lines

        foreach (string line in lines)
        {
            dialogueLines.Enqueue(line); // Add lines to the queue
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (isTyping) return; // Prevent skipping while typing

        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueLines.Dequeue();
        string languageCode = SharedState.StartGameData["languageCode"];
        string text = SharedState.LanguageDefs[line];
        StartCoroutine(TypeLine(text));
        SpeakText( text, languageCode);
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter; // Add one letter at a time
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false); // Hide the dialogue box
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueBox.activeSelf && !isTyping)
        {
            DisplayNextLine(); // Wait for mouse click to display the next line
        }
    }

    public void SpeakText(string text, string languageCode)
    {
#if UNITY_EDITOR

        audioText.Stop();
        // Speak the clip of text requested from using this MonoBehaviour as the coroutine owner.
        ((ILOLSDK_EDITOR)LOLSDK.Instance.PostMessage).SpeakText(text,
            clip => { audioText.clip = clip; audioText.Play(); },
            this,
            languageCode);
#else
		LOLSDK.Instance.SpeakText(speakTextArgs.text);
#endif
    }
}
