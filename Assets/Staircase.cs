using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staircase : MonoBehaviour
//to be continued, i changed things in the herarci ybut not the scripts. i got tired .
{
    private bool playerOnStaircase;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnStaircase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnStaircase = false;
        }
    }

    public bool IsPlayerOnStaircase()
    {
        return playerOnStaircase;
    }
}
