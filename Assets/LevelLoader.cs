using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //LOAD TITLE TO HOME 
    
    public Animator transition;
    public float transitionTime = 0f;
    public int levelToGoTo; 
    
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
    
    /*public void EnterScene()
    {
        StartCoroutine(WaitForTransition(sceneName));
    }
    
    
    IEnumerator WaitForTransition( string name)
    {
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
        SceneManager.LoadScene(this.sceneName);

    }*/
}
