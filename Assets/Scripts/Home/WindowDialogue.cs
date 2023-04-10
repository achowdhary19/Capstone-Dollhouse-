using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class WindowDialogue : MonoBehaviour
{
    
    [SerializeField] private float typingSpeed = 0.05f;
    
    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI windowText;
    
    [Header("Buttons")]
    [SerializeField] private GameObject okButton;
    
    [Header("Animation Controller")]
    [SerializeField] private Animator SpeechBubbleAnimator; 
    
    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource uIAudioSource; 
    
    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] momSentences;
    [TextArea]
    [SerializeField] private string[] brotherSentences;
 

    private int index;
    private float speechBubbleAnimationDelay = 0.6f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        StartCoroutine(StartDialogue());
    }
    
    IEnumerator StartDialogue()
    {
        if (SerialScript.Instance.PlayerName == "Mom")
        {
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeMomDialogue());
        }
        
        if (SerialScript.Instance.PlayerName == "Brother")
        {
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeBrotherDialogue());
        }
    }
    
    private IEnumerator TypeMomDialogue()
    {
        foreach (char letter in momSentences[index].ToCharArray()) 
        {
            windowText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        okButton.SetActive(true); 
    }
    
    private IEnumerator TypeBrotherDialogue()
    {
        foreach (char letter in brotherSentences[index].ToCharArray()) 
        {
            windowText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        okButton.SetActive(true); 
    }
    
    
    public void okButtonMethod()
    {
        if (SerialScript.Instance.PlayerName == "Brother")
        {
            ContinueBrotherDialogue();
        }
        
        else if (SerialScript.Instance.PlayerName == "Mom")
        {
            ContinueMomDialogue();
        }
        
    }
    
    public void ContinueMomDialogue()
    {
        uIAudioSource.Play();
        if (index >= momSentences.Length - 1)  //if last sentence: empty string, reset index, turn off the button and close the speech bubble 
        {
            windowText.text = string.Empty;
            index = 0; 
            okButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }

        else  //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (index < momSentences.Length - 1)
            {
                index++;
                windowText.text = string.Empty;
                StartCoroutine(TypeMomDialogue());
            }
        }
    }

    public void ContinueBrotherDialogue()
    {
        uIAudioSource.Play();
        if (index >= brotherSentences.Length - 1)  //if last sentence: empty string, reset index, turn off the button and close the speech bubble 
        {
            windowText.text = string.Empty;
            index = 0; 
            okButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }

        else  //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (index < brotherSentences.Length - 1)
            {
                index++;
                windowText.text = string.Empty;
                StartCoroutine(TypeBrotherDialogue());
            }
        }
    }
    
    
    
    
    
    
}
