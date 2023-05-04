using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0f;
    public int levelToGoTo; 
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            Time.timeScale = 1f;
            SwitchScene();
        }
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(levelToGoTo));
    }
    
    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
    
    //emergency switch to home scene 
    public void SwitchScene()
    {
        SceneManager.LoadScene(1); 
    }
    
   
    
}
