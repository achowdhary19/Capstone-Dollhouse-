using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    //should this be on an object in the title screen or in the home, i think the home. 
    /*
    [SerializeField] private Transform startPos;
    */

    [Header("Other sprites")] 
    public SpriteRenderer spriteRenderer;
    public Sprite brotherSprite;
    public Sprite momSprite;
    public Sprite dadSprite;
    public Sprite sisterSprite;

  
    public Flowchart flowchart; 

    void Awake()
    {
        /*
        gameObject.transform.position = startPos.position; 
    */
    }
    
    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        
        ChangeSprite();
        
    }
    
    void ChangeSprite()
        {
            if (SerialScript.Instance.PlayerName == "Mom")
            {
                spriteRenderer.sprite = momSprite;
                flowchart.SetBooleanVariable("isMom", true);
                //bool isMom = flowchart.GetBooleanVariable("isMom");
              //  Debug.Log("this is mom sprite an mom variable flowchart is " + isMom);
            }
        
            else if (SerialScript.Instance.PlayerName == "Brother")
            {
                    spriteRenderer.sprite = brotherSprite;
                    flowchart.SetBooleanVariable("isBrother", true);
            }
            else if (SerialScript.Instance.PlayerName == "Sister")
            {
                spriteRenderer.sprite = sisterSprite;
                flowchart.SetBooleanVariable("isSister", true);
            }
            
            else if (SerialScript.Instance.PlayerName == "Dad")
            {
                spriteRenderer.sprite = dadSprite;
                flowchart.SetBooleanVariable("isDad", true);
            }  
              
        }
}
