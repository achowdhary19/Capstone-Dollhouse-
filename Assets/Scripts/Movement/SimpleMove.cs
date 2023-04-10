using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float buffer = 0.1f; // buffer distance from edge of bounding box
    public BoxCollider2D FirstFloorBounds; // bounding box
    public BoxCollider2D SecondFloorBounds; // bounding box


    public bool canUp;
    public BoxCollider2D playerCollider;
    public BoxCollider2D ladderCollider;

    public KeyCode interactKey = KeyCode.E;

    void Start()
    {
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
        if (leftEdge + movement.x < FirstFloorBounds.bounds.min.x + buffer) 
        {
            movement.x = FirstFloorBounds.bounds.min.x + buffer - leftEdge;
        }
        else if (rightEdge + movement.x > FirstFloorBounds.bounds.max.x - buffer)
        {
            movement.x = FirstFloorBounds.bounds.max.x - buffer - rightEdge;
        }

        if (bottomEdge + movement.y < FirstFloorBounds.bounds.min.y + buffer)
        {
            movement.y = FirstFloorBounds.bounds.min.y + buffer - bottomEdge;
        }
        else if (topEdge + movement.y > FirstFloorBounds.bounds.max.y - buffer)
        {
            movement.y = FirstFloorBounds.bounds.max.y - buffer - topEdge;
        }
        
        transform.position += (Vector3)movement;
        if (canUp && Input.GetKeyDown(interactKey))
        {
            FirstFloorBounds.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("canUp is true ");
        if (other.gameObject.name == "Ladder")
        {
            canUp = true;
            Debug.Log("canUp is true ");
        }
    }
    
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Ladder")
        {
            canUp = false;
            Debug.Log("canUp is false");
        }
    }

}
