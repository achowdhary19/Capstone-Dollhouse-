using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private Vector2 followSpot;
    public Rigidbody2D rb;
    public float perspectiveScale; 
    public float scaleRatio; 
    public float speed;

    private Animator animator; 

    private NavMeshAgent agent;

    private SpriteRenderer spriteRenderer; 
    void Start()
    {
        //tell folow spot to be where the player is right now 
        followSpot = transform.position;
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        animator = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

   
    void Update()
    {

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            followSpot = new Vector2(mousePosition.x, mousePosition.y);
        }

        //set our position to follow spot 
        //transform.position = Vector2.MoveTowards(transform.position, followSpot, speed * Time.deltaTime);
        
        agent.SetDestination(new Vector3(followSpot.x, followSpot.y, transform.position.z));
        //AdjustPerspective();

        UpdateAnimation();
        AdjustSortingLayer();
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
    private void AdjustPerspective()
    {
        Vector3 scale = transform.localScale;
        scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = scale; 
        Debug.Log(perspectiveScale / transform.position.y * scaleRatio);


    }
}
