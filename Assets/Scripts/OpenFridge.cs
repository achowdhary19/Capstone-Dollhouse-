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
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();

    }

    private void Update()
    {
        if (!CharacterControl.Instance.m_Grounded)
        {
            Collider.enabled = false;
        }
        else
        {
            Collider.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            
                Vector3 furniturePosition = gameObject.transform.position;
                furniturePosition.x += positionOffset;
                gameObject.transform.position = furniturePosition;
                
                spriteRenderer.sprite = openSprite;
                open.Play();
                
            
        }
        else
        {
                Vector3 furniturePosition = gameObject.transform.position;
                furniturePosition.x -= positionOffset;
                gameObject.transform.position = furniturePosition;
                
                spriteRenderer.sprite = closedSprite;
                close.Play();
                
            
        }
    }
}
