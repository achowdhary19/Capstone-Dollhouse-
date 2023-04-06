using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorations : MonoBehaviour
{
    public GameObject BoyDecorations;
    public GameObject DadDecorations;
    public GameObject SisterDecorations;
    public GameObject MomDecorations;

    //maybe later i can do empty groups/containers 
    

    // Start is called before the first frame update
    void Start()
    {
        if (SerialScript.Instance.PlayerName == "Brother")
        {
            BoyDecorations.SetActive(true);
        }
        
        
        if (SerialScript.Instance.PlayerName == "Dad")
        {
            DadDecorations.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
