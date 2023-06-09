using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    //THIS WORKS BUT YOU HAVE TO HAVE THE PHONE CALL CONTAINER ON AT THE START OF THE GAME 
    public float ringInterval = 120f; // time interval in seconds between each ring
    public float clickInterval = 10f; // time interval in seconds to click the phone after it rings

    private float timer = 0f; // keeps track of the time since the last phone ring
    private bool isRinging = false;

    public static GameObject PhoneMessage;

    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource uIAudioSource;
    
    public KeyCode interactKey = KeyCode.E; // The key the player needs to press to interact
    
    [SerializeField] private Animator PhoneMessageAnimator; 
    [SerializeField] private Animator PhoneAnimator; 
    
    [Header("Messages")]
    [SerializeField] private List<string> phoneMessages = new List<string>();

    

    private void Start()
    {
        PhoneMessage = GameObject.Find("PhoneCallContainer");
    }
    
    private void Update()
    {
        // Increase timer
        timer += Time.deltaTime;

        // Check if it's time to ring the phone
        if (timer >= ringInterval && !isRinging)
        {
            //start thing 
            RingPhone();
        }
        
    }

    private void RingPhone()
    {
        
        // Set isRinging flag to true
        isRinging = true;
        
        StartCoroutine(StopAnimation());
        // Play phone ringing sound or animation
        uIAudioSource.Play();
       
        
        // next thing 
        StartCoroutine(WaitForClick());

    }

    private IEnumerator StopAnimation()
    {
        PhoneAnimator.SetBool("IsRinging", true);
        yield return new WaitForSeconds(2.5f);
        PhoneAnimator.SetBool("IsRinging", false);
    } 
    private IEnumerator WaitForClick() 
    //Waits for the clickInterval seconds (10 s) or until the phone is clicked, whichever comes first, to check if the phone was answered 
    {
        yield return new WaitForSeconds(clickInterval);

        // If 10 seconds has gone by and the phone is still ringing, like the flag is true not that the audio is actually ringing 
        if (isRinging)
        {
            Debug.Log("Timer up, nothing happens. ");

            // then Reset timer and isRinging flag
            timer = 0f;
            isRinging = false;

            // Close the phone message display
            PhoneMessageAnimator.SetTrigger("Close");
        }
    }
    
    /*
    private void PlayerInteract()
    {

        //i think this is where i need ot put the on mouse down stuff and call this in the wait for click function. 
       uncomment this stuff out and edit it once i have a way to get upstairs. 
        if (inTriggerZone && Input.GetKeyDown(interactKey))
        {
            Debug.Log("INteract key pressed ");
            
        }
    }
    
    */

    private void OnMouseDown()
    {  //works with wait for click, its hard to see because technically this doesn't need to be called 
        
        // Check if the phone is ringing and the click is within clickInterval
        if (isRinging && timer < clickInterval)
        {
         
            // Get a random message from the list
            int randomIndex = Random.Range(0, phoneMessages.Count);
            string message = phoneMessages[randomIndex];

            // Set the message on the phone display
            PhoneMessageAnimator.SetTrigger("Open");
            PhoneMessageAnimator.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
            
            // Reset timer and isRinging flag
            timer = 0f;
            isRinging = false;
            PhoneAnimator.SetBool("IsRinging", false);
        }
        
        else   // If the phone is not ringing or the click is too late
        {
            Debug.Log("Phone is not ringing or the click is too late");
        }
    }

    public void CloseMessage()
    {
       // PhoneMessage.SetActive(false);
        PhoneMessageAnimator.SetTrigger("Close");

    }
    
}
