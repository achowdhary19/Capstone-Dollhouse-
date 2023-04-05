using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float buffer = 0.1f; // buffer distance from edge of bounding box
    public BoxCollider2D MovementBounds; // bounding box

    
    private BoxCollider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
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
        if (leftEdge + movement.x < MovementBounds.bounds.min.x + buffer) 
        {
            movement.x = MovementBounds.bounds.min.x + buffer - leftEdge;
        }
        else if (rightEdge + movement.x > MovementBounds.bounds.max.x - buffer)
        {
            movement.x = MovementBounds.bounds.max.x - buffer - rightEdge;
        }

        if (bottomEdge + movement.y < MovementBounds.bounds.min.y + buffer)
        {
            movement.y = MovementBounds.bounds.min.y + buffer - bottomEdge;
        }
        else if (topEdge + movement.y > MovementBounds.bounds.max.y - buffer)
        {
            movement.y = MovementBounds.bounds.max.y - buffer - topEdge;
        }

        transform.position += (Vector3)movement;
    }
}
