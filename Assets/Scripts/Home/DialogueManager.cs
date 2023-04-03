using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    
    public static GameObject speechBubble; 
    
    [SerializeField] private float typingSpeed = 0.05f;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI bookText;

    [Header("Continue Button")]
    [SerializeField] private GameObject continueButton;
    
    [Header("Animation Controller")]
    [SerializeField] private Animator SpeechBubbleAnimator; 
    
    
    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] bookSentences;
    
    private int bookIndex;

    void Start()
    {
        speechBubble = GameObject.Find("SpeechBubble");
        speechBubble.SetActive(false);
    }


    private void OnMouseDown()
    {
        speechBubble.SetActive(true);
        StartCoroutine(TypeBookDialogue());
    }

    private IEnumerator TypeBookDialogue()
    {
        foreach (char letter in bookSentences[bookIndex].ToCharArray())
        {
            bookText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (bookIndex < bookSentences.Length - 1)
        {
            bookIndex++;
            bookText.text = string.Empty;
            StartCoroutine(TypeBookDialogue());

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
