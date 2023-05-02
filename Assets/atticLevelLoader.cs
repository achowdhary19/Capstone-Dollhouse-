using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class atticLevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0f;
    
    
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel("Attic"));
    }
    
    IEnumerator LoadLevel(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Attic");
    }

}
