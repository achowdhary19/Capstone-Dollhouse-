using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseBrowsers : MonoBehaviour
{
    public GameObject SisterContainer;
    public GameObject BrotherContainer; 
    public GameObject DadContainer; 
    
    // Start is called before the first frame update
    void Start()
    {
        OpenBrowser();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenBrowser()
    {
        if (SerialScript.Instance.PlayerName == "Sister")
        {
            SisterContainer.SetActive(true);
        }
        
        else if (SerialScript.Instance.PlayerName == "Dad")
        {
            DadContainer.SetActive(true);
        }
        
        else if (SerialScript.Instance.PlayerName == "Brother")
        {
            BrotherContainer.SetActive(true);
        }
        
    }
}
