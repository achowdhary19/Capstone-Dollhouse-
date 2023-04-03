using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move Instance; 
    public float runSpeed = 20f;
    float horizontalMove = 0f;
    public CharacterControl controller;
    bool jump = false;
    bool crouch = false;
    
    private Rigidbody2D PlayerRigidBody;
    private Vector3 moveDir;

    void Awake()
    {
        Instance = this; 
        PlayerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
       //HandleMovement2(); //old, kinematic movement 
    }

    public void HandleMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
		
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    
    void FixedUpdate ()
    {
        controller.Move(horizontalMove, crouch, jump);
        jump = false;
        
       // transform.position += moveDir * runSpeed * Time.fixedDeltaTime;

    }
    
    
    private void HandleMovement2()
    {
        float moveY = 0f;
        float moveX = 0f; 

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY += 1f; 
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY -= 1f; 
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX -= 1f; 
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX += 1f; 
        }
      

        //moveDir = new Vector3(moveX, moveY).normalized;
        moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * runSpeed * Time.deltaTime;

    }
    
    
}