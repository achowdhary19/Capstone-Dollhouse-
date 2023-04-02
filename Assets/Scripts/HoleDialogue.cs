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
    [SerializeField] private GameObject momContinueButton;
    [SerializeField] private GameObject brotherContinueButton;
    [SerializeField] private GameObject brotherYesButton;
    [SerializeField] private GameObject brotherNoButton;
    
    [Header("Animation Controller")]
    [SerializeField] private Animator MomSpeechBubbleAnimator; 
    [SerializeField] private Animator BrotherSpeechBubbleAnimator;

    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource uIAudioSource; 
    
    
    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] momSentences;
    [TextArea]
    [SerializeField] private string[] brotherSentences;
    
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
            Debug.Log("INteract key pressed ");
            StartCoroutine(StartDialogue());
        }



        if (momContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ContinueMomDialogue();
            }
        }
        
        if (brotherContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ContinueBrotherDialogue();
            }
        }
    }
     public IEnumerator StartDialogue()
    {
        speechBubble.SetActive(true);
        if (SerialScript.Instance.PlayerName == "Mom")
        {
            MomSpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeMomDialogue());
        }
       
        else if (SerialScript.Instance.PlayerName == "Brother")
        {
            BrotherSpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeBrotherDialogue());
        }
    }
    
    private IEnumerator TypeMomDialogue()
    {
        foreach (char letter in momSentences[holeIndex].ToCharArray()) 
        {
            holeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        momContinueButton.SetActive(true); 
    }
    
    private IEnumerator TypeBrotherDialogue()
    {
        foreach (char letter in brotherSentences[holeIndex].ToCharArray()) 
        {
            holeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        brotherContinueButton.SetActive(true);
        
        if (holeIndex >= brotherSentences.Length - 1) //if last sentence, which in brother case is a question. continue button OFF, yes/no ON 
        {
            brotherContinueButton.SetActive(false);
            brotherYesButton.SetActive(true);
            brotherNoButton.SetActive(true); 
        }
        
  

        
    }
    
    public void ContinueMomDialogue()
    {
        uIAudioSource.Play();
        if (holeIndex >= momSentences.Length - 1)  //if last sentence: empty string, reset index, turn off the button and close the speech bubble 
        {
            holeText.text = string.Empty;
            holeIndex = 0; 
            momContinueButton.SetActive(false);
            MomSpeechBubbleAnimator.SetTrigger("Close");
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
            brotherContinueButton.SetActive(false);
            brotherYesButton.SetActive(false);
            brotherNoButton.SetActive(false);

            
            BrotherSpeechBubbleAnimator.SetTrigger("Close");
            
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
    
    public void EnterHole(){
        SceneManager.LoadScene("InsideHole");
        brotherYesButton.SetActive(false);
        brotherNoButton.SetActive(false); 
        Debug.Log("'trying to enter hole '");
    }

    public void CloseBubble()
    {
        holeText.text = string.Empty;
        holeIndex = 0; 
        BrotherSpeechBubbleAnimator.SetTrigger("Close");
    }

  
}
