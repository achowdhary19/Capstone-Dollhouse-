using System.Collections;
using System.Collections.Generic;
using Fungus;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool sceneLoaded = false; // Flag to keep track of whether the (main)scene has been loaded
    public Flowchart flowchart; 
    
    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource error;

    void Start()
    {
        flowchart.SetBooleanVariable("loadLevel", false);
    }

    void Update()
    {
        if (!sceneLoaded) //if we're in the title screen 
        {
            if (SerialScript.Instance.HasScannedValid) 
            {
                
                LoadLevel();
               //flowchart.SetBooleanVariable("loadLevel", false);

            
                // Set the flag to true so the scene is only loaded once
                sceneLoaded = true;
            }
            else if (!SerialScript.Instance.HasScannedValid && Input.anyKey) //error noise when player tries to move but hasn't entered the dollhouse 
            {
                ErrorNoise();
            }
        }
    }
    
    public void LoadLevel()
    {
        SceneManager.LoadScene("Home");
    }

    void ErrorNoise()
    {
        error.Play(); 
        Debug.Log("Invalid tag or nothing scanned.");
    }
}
