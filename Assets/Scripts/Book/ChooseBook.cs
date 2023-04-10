using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBook : MonoBehaviour
{
    
    public GameObject SisterBook;
    public GameObject BrotherBook; 
    
    // Start is called before the first frame update
    void Start()
    {
        OpenBook();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OpenBook()
    {
        if (SerialScript.Instance.PlayerName == "Sister")
        {
            SisterBook.SetActive(true);
        }
        
        else if (SerialScript.Instance.PlayerName == "Brother")
        {
            BrotherBook.SetActive(true);
        }
        
    }
}
