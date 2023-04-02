using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BookScript : MonoBehaviour
{
    public string bookText;

    private void OnMouseDown()
    {
        // Show the text box with the book text
        TextBoxScript.ShowTextBox(bookText);
    }
}
