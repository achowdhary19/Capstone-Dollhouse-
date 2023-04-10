using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class DeskDialogue : MonoBehaviour
{
    
    [SerializeField] private float typingSpeed = 0.05f;
    
    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI deskText;
    
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
        if (SerialScript.Instance.PlayerName == "Dad")
        {
            StartCoroutine(StartDialogue());
        }

        else
        {
            Debug.Log("Locked. ");
        }
    }
    
    IEnumerator StartDialogue()
    {
        
        SpeechBubbleAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(speechBubbleAnimationDelay);
        StartCoroutine(TypeDialogue());
    }
    
    IEnumerator TypeDialogue()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            deskText.text += letter; 
            yield return new WaitForSeconds(typingSpeed);
        }
        okButton.SetActive(true);
    }
    
    public void okButtonMethod()
    {
        uIAudioSource.Play();
        if( index >= sentences.Length -1)
        {
            deskText.text = string.Empty;
            index = 0; 
            okButton.SetActive(false);
            SpeechBubbleAnimator.SetTrigger("Close");
        }
        
        else
        {
            if (index < sentences.Length - 1)
            {
                index++;
                deskText.text = string.Empty;
                StartCoroutine(TypeDialogue());
            }
        }
    }
}
