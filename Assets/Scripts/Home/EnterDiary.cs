using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterDiary : MonoBehaviour
{
    private bool inTriggerZone = false; // Whether the player is in the trigger zone

    void Update()
    {
        /*if (inTriggerZone && Input.GetKeyDown(interactKey))
        {
            if (SerialScript.Instance.PlayerName == "Brother")
            {
                SceneManager.LoadScene("Diary");
            }
            
            else if (SerialScript.Instance.PlayerName == "Mom")
            {
                Debug.Log("Mom doesn't have a diary");
            }
        }*/

    }

    void EnterTheDiary()
    {
        SceneManager.LoadScene("Diary");
    }
}
