using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MultiLevelMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float buffer = 0.1f; // buffer distance from edge of bounding box
    public BoxCollider2D firstFloorBounds; // bounding box for first floor
    public BoxCollider2D secondFloorBounds; // bounding box for second floor
    public BoxCollider2D ladderCollider; // collider for ladder between floors

    private BoxCollider2D playerCollider;

    private bool onFirstFloor = true;
    private bool onSecondFloor = false;
    private bool onLadder = false; 


    

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xInput, yInput).normalized * moveSpeed * Time.deltaTime;
        
        /*if (firstFloorBounds.bounds.Contains(transform.position))
        {
            onFirstFloor = true;
        }*/
        
        if (onFirstFloor)
        {
            MoveOnFirstFloor();
        }

        if (ladderCollider.bounds.Contains(transform.position) && yInput > 0)
        {
            onLadder = true; 
        }

        if (onLadder)
        {
            MoveOnLadder(); 
        }

        if (secondFloorBounds.bounds.Contains(transform.position))
        {
             onSecondFloor = true;
        }

        if (onSecondFloor)
        {
            MoveOnSecondFloor();
        }
    }


    void MoveOnFirstFloor()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xInput, yInput).normalized * moveSpeed * Time.deltaTime;
        // calculate edge positions
        float leftEdge = playerCollider.bounds.min.x;
        float rightEdge = playerCollider.bounds.max.x;
        float bottomEdge = playerCollider.bounds.min.y;
        float topEdge = playerCollider.bounds.max.y;
        
        // restrict movement if too close to edge of bounding box
        if (leftEdge + movement.x < firstFloorBounds.bounds.min.x + buffer) 
        {
            movement.x = firstFloorBounds.bounds.min.x + buffer - leftEdge;
        }
        else if (rightEdge + movement.x > firstFloorBounds.bounds.max.x - buffer)
        {
            movement.x = firstFloorBounds.bounds.max.x - buffer - rightEdge;
        }

        if (bottomEdge + movement.y < firstFloorBounds.bounds.min.y + buffer)
        {
            movement.y = firstFloorBounds.bounds.min.y + buffer - bottomEdge;
        }
        else if (topEdge + movement.y > firstFloorBounds.bounds.max.y - buffer)
        {
            movement.y = firstFloorBounds.bounds.max.y - buffer - topEdge;
        }
    }

    void MoveOnLadder()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(xInput, yInput).normalized * moveSpeed * Time.deltaTime;

        float ladderTop = ladderCollider.bounds.max.y;
        float ladderBottom = ladderCollider.bounds.min.y;
            
        // allow vertical movement only on ladder
        if (playerCollider.bounds.min.y + movement.y < ladderBottom + buffer)
        {
            movement.y = ladderBottom + buffer - playerCollider.bounds.min.y;
        }
        else if (playerCollider.bounds.max.y + movement.y > ladderTop - buffer)
        {
            movement.y = ladderTop - buffer - playerCollider.bounds.max.y;
        }

        // disable horizontal movement on ladder
        movement.x = 0f;
        if (!ladderCollider.bounds.Intersects(playerCollider.bounds))
        {
            onLadder = false;
        }
        
    }

    void MoveOnSecondFloor()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xInput, yInput).normalized * moveSpeed * Time.deltaTime;
        // calculate edge positions
        float leftEdge = playerCollider.bounds.min.x;
        float rightEdge = playerCollider.bounds.max.x;
        float bottomEdge = playerCollider.bounds.min.y;
        float topEdge = playerCollider.bounds.max.y;
        
        // restrict movement if too close to edge of second floor bounds
        if (leftEdge + movement.x < secondFloorBounds.bounds.min.x + buffer) 
        {
            movement.x = secondFloorBounds.bounds.min.x + buffer - leftEdge;
        }
        else if (rightEdge + movement.x > secondFloorBounds.bounds.max.x - buffer)
        {
            movement.x = secondFloorBounds.bounds.max.x - buffer - rightEdge;
        }

        if (bottomEdge + movement.y < secondFloorBounds.bounds.min.y + buffer)
        {
            movement.y = secondFloorBounds.bounds.min.y + buffer - bottomEdge;
        }
        else if (topEdge + movement.y > secondFloorBounds.bounds.max.y - buffer)
        {
            movement.y = secondFloorBounds.bounds.max.y - buffer - topEdge;
        }

        // move player within second floor bounds
        transform.position += (Vector3)movement;
    
    /*
    else
        {
        // move player within first floor bounds
        transform.position += (Vector3)movement;
        }*/
    }
}
