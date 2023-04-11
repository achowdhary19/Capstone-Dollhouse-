using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LavaDialogue : MonoBehaviour
{
    public static GameObject speechBubble;

    [SerializeField] private float typingSpeed = 0.05f;
    
    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI lavaText;
    
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
    void Start()
    { 
        /*speechBubble = GameObject.Find("SpeechBubble");
        speechBubble.SetActive(false);*/
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
        //speechBubble.SetActive(true);
        SpeechBubbleAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(speechBubbleAnimationDelay);
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            lavaText.text += letter; 
            yield return new WaitForSeconds(typingSpeed);
        }
        okButton.SetActive(true);
    }

    public void okButtonMethod()
    {
        uIAudioSource.Play();
        if( index >= sentences.Length -1)
        {
            lavaText.text = string.Empty;
            index = 0; 
            okButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }
        
        else
        {
            if (index < sentences.Length - 1)
            {
                index++;
                lavaText.text = string.Empty;
                StartCoroutine(TypeDialogue());
            }
        }
    }



}
