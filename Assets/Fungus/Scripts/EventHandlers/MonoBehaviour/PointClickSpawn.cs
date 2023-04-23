using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickSpawn : MonoBehaviour
{
    [Header("Other sprites")] 
    public SpriteRenderer spriteRenderer;
    public Sprite brotherSprite;
    public Sprite momSprite;
    public Sprite dadSprite;
    public Sprite sisterSprite;
    
    public Vector2 followSpot;
    public Rigidbody2D rb;
    public float perspectiveScale; 
    public float scaleRatio; 
    public float speed;

    public Animator animator; 

    
    private NavMeshAgent agent;
    
    public bool inDialogue; 
    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        //tell folow spot to be where the player is right now 
        followSpot = transform.position;
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        animator = GetComponent<Animator>(); 
        ChangeSprite();
    }

    void Update()
    {

        if (!inDialogue)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                followSpot = new Vector2(mousePosition.x, mousePosition.y);
            }

            agent.SetDestination(new Vector3(followSpot.x, followSpot.y, transform.position.z));
            UpdateAnimation();
        }
        AdjustSortingLayer();
        //AdjustPerspective();
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
    
    private void UpdateAnimation()
    {
        //Determines the angle between where we clicked on the screen and our player 
        Vector3 direction = transform.position - new Vector3(followSpot.x, followSpot.y, transform.position.z);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        animator.SetFloat("angle", angle);
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        followSpot = transform.position;
        // followSpot = rb.transform.position;

    }*/

    private void AdjustSortingLayer()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -100);
    }

    public void ExitDialogue()
    {
        inDialogue = false;
    }
    
    private void AdjustPerspective()
    {
        Vector3 scale = transform.localScale;
        scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = scale; 
        Debug.Log(perspectiveScale / transform.position.y * scaleRatio);


    }
}
