using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;

public class ClickMove : MonoBehaviour
{

    public float speed = 10f;
    public bool moving;
    public UnityEngine.Vector2 lastClicked; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            lastClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        */
            lastClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true; 
        }

        if (moving && (UnityEngine.Vector2)transform.position != lastClicked)
        {
            float step = speed * Time.deltaTime;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, lastClicked, step);
        }
        else
        {
            moving = false; 
        }
        
        
    }
}
