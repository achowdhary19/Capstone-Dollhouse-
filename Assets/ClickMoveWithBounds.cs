using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveWithBounds : MonoBehaviour
{
    public float speed = 10f;
    public float buffer = 0.1f; 
    public bool isMoving = false;
    public Vector2 targetPosition; 
    public Vector2 newPosition; 
    
    
   
    public BoxCollider2D FirstFloorBounds; // bounding box
    public BoxCollider2D SecondFloorBounds; // bounding box
    private Rigidbody2D rb;
    public BoxCollider2D playerCollider;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;

            targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            if (FirstFloorBounds.bounds.Contains(targetPosition))
            {
                isMoving = true;
            }
        }
        
        if (isMoving)
        {
            Vector2 movement = targetPosition - (Vector2)transform.position;
            float distance = movement.magnitude;

            if (distance < buffer)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
            else
            {
                movement = movement.normalized * speed * Time.deltaTime;

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

               // transform.position += (Vector3)movement;
                transform.position = Vector2.MoveTowards(transform.position, movement, speed * Time.deltaTime);

            }
        }
        
    }
}
