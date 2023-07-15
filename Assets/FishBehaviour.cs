using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    //Generated with Ai
    //Prompts:
    /*
     #now we write a new script 'FishBehaviour'. 
     We take the boxCollider2D component of the gameObject the script is attached to. 
     Then if there is a trigger collision with that collider, we disable the collider and disable the spriteRenderer too

    #the collision in the OnTriggerEnter must have tag "Bullet" as the if condition
    */

    //no manual changes
    private BoxCollider2D boxCollider;     // Reference to the BoxCollider2D component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private int hits = 0;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Check if the trigger collision occurred with the attached BoxCollider2D component
        if (collision.CompareTag("Bullet"))
        {
            hits++;
            if(hits>=6)
			{

                // Disable the BoxCollider2D component
                boxCollider.enabled = false;

                // Disable the SpriteRenderer component
                spriteRenderer.enabled = false;

            }
            Destroy(collision.gameObject);
        }
    }
}
