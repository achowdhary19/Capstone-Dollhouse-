using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Animator transition;

    public float transitionTime = 1f;
    public string sceneName; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterScene()
    {
        StartCoroutine(WaitForTransition(sceneName));
    }
    
    IEnumerator WaitForTransition( string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(this.sceneName);
    }
}
