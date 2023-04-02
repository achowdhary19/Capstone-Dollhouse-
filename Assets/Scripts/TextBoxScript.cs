using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TextBoxScript : MonoBehaviour
{
    public static GameObject textBox;
    public static GameObject speechBubble; 
    public static Text text;

    private void Start()
    {
        textBox = GameObject.Find("TextBox"); //using text(TMP) with a normal text component inside, not a text UI component.
        speechBubble = GameObject.Find("SpeechBubbleImage");
        
        text = textBox.GetComponentInChildren<Text>();
        //text = GetComponentInChildren<TextMeshProUGUI>(); 
        textBox.SetActive(false);
        speechBubble.SetActive(false);
    }

    public static void ShowTextBox(string message)
    {
        text.text = message;
        textBox.SetActive(true);
        speechBubble.SetActive(true);
        
    }

    public static void HideTextBox()
    {
        textBox.SetActive(false);
        speechBubble.SetActive(false);
    }
}

