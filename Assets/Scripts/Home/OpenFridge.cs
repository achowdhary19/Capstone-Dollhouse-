using System.Collections;
using System.Collections.Generic;
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

    private void OnMouseDown()
    {
        isOpen = !isOpen;

        
        if (isOpen)
        {
            
                if (gameObject.name == "CabinetTop")
                {
                    GameObject mainCabinet = transform.parent.gameObject;
                    mainCabinet.GetComponent<SpriteRenderer>().sprite = openSprite;
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
            if (gameObject.name == "CabinetTop")
            {
                GameObject mainCabinet = transform.parent.gameObject;
                mainCabinet.GetComponent<SpriteRenderer>().sprite = closedSprite;
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
    
}
