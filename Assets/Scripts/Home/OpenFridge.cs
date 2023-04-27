using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class OpenFridge : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;

    private GameObject cigarettes;
    
    public float positionOffset; 

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    
    private Collider2D Collider;

    public Flowchart flowchart; 

    [Header("UIAudioSource")] 
    [SerializeField] private AudioSource open; 
    [SerializeField] private AudioSource close; 
    
    /*public GameObject mainCabinet; 
    */
    
    private void Start()
    {
        
        // Get a reference to the cigarettes GameObject using Transform.Find()
        if (gameObject.name == "Desk")
        {
            cigarettes = transform.Find("Cigarettes").gameObject;
            // Turn off the cigarettes by default
            cigarettes.SetActive(false);
        }
        
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();

    }

    private void Update()
    {
       
        
    }

    public void OpenThing()
    {
        isOpen = !isOpen;

        
        if (isOpen)
        {
                if (gameObject.name == "Stove")
                {
                    flowchart.SetBooleanVariable("stoveOpen", true);
                }
                
                if (gameObject.name == "Cabinet")
                {
                    flowchart.SetBooleanVariable("cabinetOpen", true);
                }
               
                if (gameObject.name == "CabinetTop")
                {
                    flowchart.SetBooleanVariable("cabinetTop", true);
                    GameObject mainCabinet = transform.parent.gameObject;
                    mainCabinet.GetComponent<SpriteRenderer>().sprite = openSprite;
                }
                
                if (gameObject.name == "Fridge")
                {
                    flowchart.SetBooleanVariable("fridgeOpen", true);
                }
                
                
                if (gameObject.name == "ClosetDrawer")
                {
                    flowchart.SetBooleanVariable("closetDrawer", true);
                    GameObject mainCloset = transform.parent.gameObject;
                    mainCloset.GetComponent<SpriteRenderer>().sprite = openSprite;
                }
                
                if (gameObject.name == "ClosetCabinet")
                {
                    flowchart.SetBooleanVariable("closetCabinet", true);
                    //StartCoroutine(StartDialogue());
                }


                if (gameObject.name == "Desk")
                {
                    cigarettes.SetActive(true);
                }

                
                
                Vector3 furniturePosition = gameObject.transform.position;
                furniturePosition.x += positionOffset;
                gameObject.transform.position = furniturePosition;
                
                spriteRenderer.sprite = openSprite;
                open.Play();
        }
        
        else
        {
            if (gameObject.name == "Stove")
            {
                flowchart.SetBooleanVariable("stoveOpen", false);
            }
            
            if (gameObject.name == "Cabinet")
            {
                flowchart.SetBooleanVariable("cabinetOpen", false);
            }
            
            if (gameObject.name == "CabinetTop")
            {
                flowchart.SetBooleanVariable("cabinetTop", false);
                GameObject mainCabinet = transform.parent.gameObject;
                mainCabinet.GetComponent<SpriteRenderer>().sprite = closedSprite;
            }
            
            if (gameObject.name == "Fridge")
            {
                flowchart.SetBooleanVariable("fridgeOpen", false);
            }
            
            if (gameObject.name == "ClosetCabinet")
            {
                flowchart.SetBooleanVariable("closetCabinet", false);
            }
            
            
            if (gameObject.name == "ClosetDrawer")
            {
                flowchart.SetBooleanVariable("closetDrawer", false);
                GameObject mainCloset = transform.parent.gameObject;
                mainCloset.GetComponent<SpriteRenderer>().sprite = closedSprite;
            }
            
            if (gameObject.name == "Desk")
            {
                cigarettes.SetActive(false);
            }
            Vector3 furniturePosition = gameObject.transform.position;
                furniturePosition.x -= positionOffset;
                gameObject.transform.position = furniturePosition;
                
                spriteRenderer.sprite = closedSprite;
                close.Play();
        }
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(2f);
        flowchart.SetBooleanVariable("closetOpen", true);
    }
    
}
