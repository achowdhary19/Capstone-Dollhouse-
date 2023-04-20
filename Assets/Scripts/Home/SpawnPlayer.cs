using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    //should this be on an object in the title screen or in the home, i think the home. 
    [SerializeField] private Transform startPos;

    [Header("Other sprites")] 
    public SpriteRenderer spriteRenderer;
    public Sprite brotherSprite;
    public Sprite momSprite;
    public Sprite dadSprite;
    public Sprite sisterSprite;

    void Awake()
    {
        gameObject.transform.position = startPos.position; 
    }
    
    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChangeSprite(); 
        //AllowPlayerMove(); 
    }
    
    void ChangeSprite()
        {
            if (SerialScript.Instance.PlayerName == "Mom")
            {
                spriteRenderer.sprite = momSprite;
            }
        
            else if (SerialScript.Instance.PlayerName == "Brother")
            {
                    spriteRenderer.sprite = brotherSprite;
            }
            else if (SerialScript.Instance.PlayerName == "Sister")
            {
                spriteRenderer.sprite = sisterSprite;
            }
            
            else if (SerialScript.Instance.PlayerName == "Dad")
            {
                spriteRenderer.sprite = dadSprite;
            }  
              
        }
        
    /*void AllowPlayerMove(){
        if (SerialScript.Instance.HasScannedValid)
        {
            Move.Instance.HandleMovement();
        }
    }*/
    
}
