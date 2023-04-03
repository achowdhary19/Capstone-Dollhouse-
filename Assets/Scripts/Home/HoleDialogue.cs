using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class HoleDialogue : MonoBehaviour
{
    public static GameObject speechBubble; 
    
    [SerializeField] private float typingSpeed = 0.05f;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI holeText;

    [Header("Buttons")]
    [SerializeField] private GameObject ContinueButton;
    /*
    [SerializeField] private GameObject brotherContinueButton;
    */
    [SerializeField] private GameObject brotherYesButton;
    [SerializeField] private GameObject brotherNoButton;
    
    [Header("Animation Controller")]
    [SerializeField] private Animator SpeechBubbleAnimator; 

    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource uIAudioSource; 
    
    
    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] momSentences;
    [TextArea]
    [SerializeField] private string[] brotherSentences;
    [TextArea]
    [SerializeField] private string[] sisterSentences;
    
    private int holeIndex;
  
    private float speechBubbleAnimationDelay = 0.6f;
    
    public KeyCode interactKey = KeyCode.E; // The key the player needs to press to interact
    private bool inTriggerZone = false; // Whether the player is in the trigger zone


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
            Debug.Log("player in trigger zone");
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
        
      
        // StartCoroutine(OnMouseDown());
    }
    /*void OnMouseDown()
    {
        Debug.Log("Mouse button clicked on player object");
        StartCoroutine(StartDialogue());
    }*/
    
    

    void Update() //player can press enter button to continue dialogue. 
    {

        if (inTriggerZone && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Interact key pressed");
            StartCoroutine(StartDialogue());
        }



        if (ContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ContinueButtonMethod();
            }
        }
    }
     public IEnumerator StartDialogue()
    {
        speechBubble.SetActive(true);
        if (SerialScript.Instance.PlayerName == "Mom")
        {
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeMomDialogue());
        }
        
        else if (SerialScript.Instance.PlayerName == "Dad")
        {
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeMomDialogue());
        }
       
        else if (SerialScript.Instance.PlayerName == "Brother")
        {
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeBrotherDialogue());
        }
        
        else if (SerialScript.Instance.PlayerName == "Sister")
        {
            SpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeSisterDialogue());
        }
    }
    
    private IEnumerator TypeMomDialogue()
    {
        foreach (char letter in momSentences[holeIndex].ToCharArray()) 
        {
            holeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        ContinueButton.SetActive(true); 
    }
    
    private IEnumerator TypeBrotherDialogue()
    {
        foreach (char letter in brotherSentences[holeIndex].ToCharArray()) 
        {
            holeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        ContinueButton.SetActive(true);
        
        if (holeIndex >= brotherSentences.Length - 1) //if last sentence, which in brother case is a question. continue button OFF, yes/no ON 
        {
            ContinueButton.SetActive(false);
            brotherYesButton.SetActive(true);
            brotherNoButton.SetActive(true); 
        }
    }
    
    private IEnumerator TypeSisterDialogue()
    {
        foreach (char letter in sisterSentences[holeIndex].ToCharArray()) 
        {
            holeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        ContinueButton.SetActive(true);
        
        if (holeIndex >= sisterSentences.Length - 1) //if last sentence, which in brother case is a question. continue button OFF, yes/no ON 
        {
            //brother and sister will share yes no continue button 
            ContinueButton.SetActive(false);
            brotherYesButton.SetActive(true);
            brotherNoButton.SetActive(true); 
        }
    }
    
    
    public void ContinueButtonMethod()
    {
        if (SerialScript.Instance.PlayerName == "Brother")
        {
            ContinueBrotherDialogue();
        }
        
        else if (SerialScript.Instance.PlayerName == "Mom")
        {
            ContinueMomDialogue();
        }
        
        else if (SerialScript.Instance.PlayerName == "Sister")
        {
            ContinueSisterDialogue();
        }
    }

    public void ContinueMomDialogue()
    {
        uIAudioSource.Play();
        if (holeIndex >= momSentences.Length - 1)  //if last sentence: empty string, reset index, turn off the button and close the speech bubble 
        {
            holeText.text = string.Empty;
            holeIndex = 0; 
            ContinueButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }

        else  //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (holeIndex < momSentences.Length - 1)
            {
                holeIndex++;
                holeText.text = string.Empty;
                StartCoroutine(TypeMomDialogue());
            }
        }
    }


    public void ContinueBrotherDialogue()
    {
        uIAudioSource.Play();
        if (holeIndex >= brotherSentences.Length - 1) //if past last sentence index, empty reset close  
        {
            holeText.text = string.Empty;
            holeIndex = 0;
            ContinueButton.SetActive(false);
            brotherYesButton.SetActive(false);
            brotherNoButton.SetActive(false);
            
            SpeechBubbleAnimator.SetTrigger("Close");
            
        }
        else //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (holeIndex < brotherSentences.Length - 1)
            {
                holeIndex++;
                holeText.text = string.Empty;
                StartCoroutine(TypeBrotherDialogue());
            }
        }
    }
    
    public void ContinueSisterDialogue()
    {
        uIAudioSource.Play();
        if (holeIndex >= sisterSentences.Length - 1) //if past last sentence index, empty reset close  
        {
            holeText.text = string.Empty;
            holeIndex = 0;
            ContinueButton.SetActive(false);
            brotherYesButton.SetActive(false);
            brotherNoButton.SetActive(false);
            
            SpeechBubbleAnimator.SetTrigger("Close");
            
        }
        else //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (holeIndex < sisterSentences.Length - 1)
            {
                holeIndex++;
                holeText.text = string.Empty;
                StartCoroutine(TypeSisterDialogue());
            }
        }
    }
    

    public void YesButtonMethod()
    {
        if (SerialScript.Instance.PlayerName == "Brother")
        {
            EnterHole();
        }
        
        else if (SerialScript.Instance.PlayerName == "Sister")
        {
            SisterEnterHole();
        }
    }
    
    public void EnterHole(){
        SceneManager.LoadScene("InsideHole");
        brotherYesButton.SetActive(false);
        brotherNoButton.SetActive(false); 
        Debug.Log("'trying to enter hole '");
    }
    
    public void SisterEnterHole(){
        SceneManager.LoadScene("HoleTroll");
        brotherYesButton.SetActive(false);
        brotherNoButton.SetActive(false); 
    }
}
