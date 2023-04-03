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
        ChangeSprite(); //this works, only issue is that the ground and ceiling oclliders stay the same whihc is only a problem if our sprites are differnet sizes. Not a huge problem. 
        AllowPlayerMove(); 
    }
    
    void ChangeSprite()
        {
            if (SerialScript.Instance.PlayerName == "Mom")
            {
                Debug.Log("this should be mome sprite");
                spriteRenderer.sprite = momSprite;
            }
        
            else if (SerialScript.Instance.PlayerName == "Brother")
            {
                    Debug.Log("this should be brother sprite");
                    spriteRenderer.sprite = brotherSprite;
            }
            else if (SerialScript.Instance.PlayerName == "Sister")
            {
                Debug.Log("this should be sister sprite");
                spriteRenderer.sprite = sisterSprite;
            }
            
            else if (SerialScript.Instance.PlayerName == "Dad")
            {
                Debug.Log("this should be dad sprite");
                spriteRenderer.sprite = dadSprite;
            }  
              
        }
        
    void AllowPlayerMove(){
        if (SerialScript.Instance.HasScannedValid)
        {
            Debug.Log("Welcome to the Dollhouse");
            Move.Instance.HandleMovement();
        }
    }
    
}
