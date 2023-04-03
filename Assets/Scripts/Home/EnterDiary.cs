using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterDiary : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // The key the player needs to press to interact
    private bool inTriggerZone = false; // Whether the player is in the trigger zone


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
            Debug.Log("player in trigger zone");
            //interactText.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false;
            //interactText.gameObject.SetActive(false);
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (inTriggerZone && Input.GetKeyDown(interactKey))
        {
            if (SerialScript.Instance.PlayerName == "Brother")
            {
                SceneManager.LoadScene("Diary");
            }
            
            else if (SerialScript.Instance.PlayerName == "Mom")
            {
                Debug.Log("mom doesn't have a diary");
            }
        }

    }
}
