using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLetter : MonoBehaviour
{
    public static GameObject LetterMessage;  
    

    [SerializeField] private GameObject CloseButton;
    
    
    [SerializeField] private Animator LetterAnimator; 
    private void Start()
    {
        LetterMessage = GameObject.Find("LetterMessageContainer");
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (SerialScript.Instance.PlayerName == "Dad")
        {
            ReadLetter();
        }
    }
    
    public void ReadLetter()
    {
        LetterAnimator.SetTrigger("Open");
    }

    public void CloseLetter()
    {
        LetterAnimator.SetTrigger("Close");
    }
}
