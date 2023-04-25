using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TrollDialogue : MonoBehaviour
{
    public static GameObject speechBubble; 
    
    [SerializeField] private float typingSpeed = 0.05f;
    
    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI trollText;
    
    [Header("Buttons")]
    [SerializeField] private GameObject ContinueButton;
    
    [Header("Animation Controller")]
    [SerializeField] private Animator SpeechBubbleAnimator; 
    
    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] dialogue;
    
    private int index;
    
    private float speechBubbleAnimationDelay = 0.6f;
    
    public KeyCode interactKey = KeyCode.E; // The key the player needs to press to interact
    private bool inTriggerZone = false; // Whether the player is in the trigger zone
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
            //interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false;
            //interactText.gameObject.SetActive(false);
        }
    }
    
    void Start()
    {
        speechBubble = GameObject.Find("SpeechBubble");
        speechBubble.SetActive(false);
    }

    void Update()
    {
        if (inTriggerZone && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartDialogue());
        }
        
        if (ContinueButton.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
              ContinueDialogue();
            }
        }
        
    }
    
    public IEnumerator StartDialogue()
    {
        speechBubble.SetActive(true);
        
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeDialogue());
        
    }

    private IEnumerator TypeDialogue()
    {
        foreach (char letter in dialogue[index].ToCharArray()) 
        {
            trollText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        ContinueButton.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (index >= dialogue.Length - 1)  //if last sentence: empty string, reset index, turn off the button and close the speech bubble 
        {
            trollText.text = string.Empty;
            index = 0; 
            ContinueButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }
        
        else  //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                trollText.text = string.Empty;
                StartCoroutine(TypeDialogue());
            }
        }
    }

}
