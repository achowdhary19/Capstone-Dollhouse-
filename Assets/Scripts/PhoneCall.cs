using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    //This kind of works but i think the click interval 
    public float ringInterval = 120f; // time interval in seconds between each ring
    public float clickInterval = 10f; // time interval in seconds to click the phone after it rings

    private float timer = 0f; // keeps track of the time since the last phone ring
    private bool isRinging = false;

    public static GameObject PhoneMessage;  
    
    [Header("Buttons")]
    [SerializeField] private GameObject ContinueButton;

    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource uIAudioSource;
    
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

    private void Start()
    {
        PhoneMessage = GameObject.Find("PhoneCallContainer");
        PhoneMessage.SetActive(false);
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
        
        // Play phone ringing sound or animation
        uIAudioSource.Play();
        
        // next thing 
        StartCoroutine(WaitForClick());

    }

    private IEnumerator WaitForClick() 
    //Waits for the clickInterval seconds (10 s) or until the phone is clicked, whichever comes first, to check if the phone was answered 
    {
        yield return new WaitForSeconds(clickInterval);

        // If the phone is still ringing, like the flag is true not that the audio is actually ringing 
        if (isRinging)
        {
            Debug.Log("Timer up, nothing happens. ");

            // Reset timer and isRinging flag
            timer = 0f;
            isRinging = false;
        }
    }
    
    /*
    private void PlayerInteract()
    {

        TODO:  think this is where i need ot put the on mouse down stuff and call this in the wait for click function. 
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
            //Debug.Log("Phone answered, do the special message.");
            PhoneMessage.SetActive(true);

            // Reset timer and isRinging flag
            timer = 0f;
            isRinging = false;
        }
        
        else   // If the phone is not ringing or the click is too late
        {
            Debug.Log("Phone is not ringing or the click is too late");
        }
    }

    public void CloseMessage()
    {
        PhoneMessage.SetActive(false);
    }
}
