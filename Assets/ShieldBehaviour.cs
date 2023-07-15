using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    //Generated with Ai
    //Prompts:
    /*
    #a new script ShieldBehaviour. if there is a trigger collision and the collision has 'Bullet' tag, the collided gameObject is destroyed
    
    #the script now takes all the GameObjects it has as children and vibrates them. 
    The vibration effect is achieved by using a sine function and translating GameObject on Y axis over time. 
    There will be a public variable 'globalSpeed' that controls the speed of the vibrations. 

    #instead of using 0.1f, use a random between 0.001 and 0.007
    */
    //no manual changes

    public float globalSpeed = 1f;     // Speed of the vibrations

    private void Update()
    {
        // Iterate through all child GameObjects
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Calculate the Y-axis displacement using a sine function
            float yDisplacement = Random.Range(0.001f, 0.007f) * Mathf.Sin(Time.time * globalSpeed);

            // Apply the displacement to the child GameObject
            child.Translate(0f, yDisplacement, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the trigger collision occurred with a collider tagged as "Bullet"
        if (collision.CompareTag("Bullet"))
        {
            // Destroy the collided game object
            Destroy(collision.gameObject);
        }
    }
}
