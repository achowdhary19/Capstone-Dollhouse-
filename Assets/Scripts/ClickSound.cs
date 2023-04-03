using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource click; 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayClick()
    {
        click.Play();
    }
}
