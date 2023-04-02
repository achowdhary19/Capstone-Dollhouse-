using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Typing : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float typingSpeed = 0.05f;
    private int storyIndex;
    
    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI storyText;
    
    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] momSentences;
    [TextArea]
    [SerializeField] private string[] brotherSentences;
    
    [SerializeField] private AudioSource typingSound; 
    
    void Start()
    {
        StartCoroutine(StartDialogue());    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartDialogue()
    {
        /*if (SerialScript.Instance.PlayerName == "Mom")
        {
            foreach (char letter in momSentences[storyIndex].ToCharArray())
            {
                storyText.text += letter;
                yield return new WaitForSeconds(typingSpeed);

            }
            
            
        }*/
        foreach (char letter in momSentences[storyIndex].ToCharArray())
        {
            
                typingSound.Play();
                storyText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
        }
        

    }
    
}
