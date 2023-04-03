using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterComputer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("ComputerBrowser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
