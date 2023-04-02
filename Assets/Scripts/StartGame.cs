using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool sceneLoaded = false; // Flag to keep track of whether the (main)scene has been loaded
    
    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource error;

    void Start()
    {
    }

    void Update()
    {
        if (!sceneLoaded) //if we're in the title screen 
        {
            if (SerialScript.Instance.HasScannedValid) 
            {
                LoadLevel();
            
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
