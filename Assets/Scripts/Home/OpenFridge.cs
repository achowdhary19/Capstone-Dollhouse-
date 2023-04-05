using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridge : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;
    
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
            
                Vector3 furniturePosition = gameObject.transform.position;
                furniturePosition.x -= positionOffset;
                gameObject.transform.position = furniturePosition;
                
                spriteRenderer.sprite = closedSprite;
                close.Play();
                
            
        }
    }
    
}
