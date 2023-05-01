using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class RESTARTGAME : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Time.timeScale = 1f;
            Retry();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
        //GetComponent<SerialScript>().StopThread();
    }
}
