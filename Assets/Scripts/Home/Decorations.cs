using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorations : MonoBehaviour
{
    public GameObject BoyDecorations;
    public GameObject DadDecorations;
    public GameObject SisterDecorations;
    public GameObject MomDadDecorations;
    public GameObject MomDecorations;

    

    void Start()
    {
        if (SerialScript.Instance.PlayerName == "Brother")
        {
            BoyDecorations.SetActive(true);
            
            DadDecorations.SetActive(false);
            MomDecorations.SetActive(false);
            MomDadDecorations.SetActive(false);
            SisterDecorations.SetActive(false);
        }
        
        
        if (SerialScript.Instance.PlayerName == "Dad")
        {
            DadDecorations.SetActive(true);
            MomDadDecorations.SetActive(true);
            
            
            MomDecorations.SetActive(false);
            BoyDecorations.SetActive(false);
            SisterDecorations.SetActive(false);
        }
        
        if (SerialScript.Instance.PlayerName == "Sister")
        {
            SisterDecorations.SetActive(true);
            
            DadDecorations.SetActive(false);
            MomDecorations.SetActive(false);
            BoyDecorations.SetActive(false);
            MomDadDecorations.SetActive(false);
        }
        
        if (SerialScript.Instance.PlayerName == "Mom")
        {
            MomDecorations.SetActive(true);
            MomDadDecorations.SetActive(true);
            
            SisterDecorations.SetActive(false);
            DadDecorations.SetActive(false);
            BoyDecorations.SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
