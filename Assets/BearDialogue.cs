using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class BearDialogue : MonoBehaviour
{
    
    [SerializeField] private float typingSpeed = 0.05f;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI bearText;

    [Header("Buttons")]
    [SerializeField] private GameObject okButton;
    
    [Header("Animation Controller")]
    [SerializeField] private Animator SpeechBubbleAnimator; 

    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource uIAudioSource; 

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] sentences;

    private int index;
    
    private float speechBubbleAnimationDelay = 0.6f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        Debug.Log("trying to press");/*if(EventSystem.current.IsPointerOverGameObject())
            return;*/
        StartCoroutine(StartDialogue());
    }

    public IEnumerator StartDialogue()
    {
        SpeechBubbleAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(speechBubbleAnimationDelay);
        StartCoroutine(TypeDialogue());
    }


    private IEnumerator TypeDialogue()
    {
        foreach (char letter in sentences[index].ToCharArray()) 
        {
            bearText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
         okButton.SetActive(true);
    }

    public void ContinueButtonMethod()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on the UI");
            }
            else if ( ! EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("did not click on ui ");
            }
        }
        */
        ContinueDialogue();
    }

    public void ContinueDialogue()
    {
        uIAudioSource.Play();
        if (index >= sentences.Length - 1)  //if last sentence: empty string, reset index, turn off the button and close the speech bubble 
        {
            bearText.text = string.Empty;
            index = 0; 
            okButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }
        
        else  //else go to next sentence, empty the bubble, and type the next sentence 
        {
            if (index < sentences.Length - 1)
            {
                index++;
                bearText.text = string.Empty;
                StartCoroutine(TypeDialogue());
            }
        }
    }
}
