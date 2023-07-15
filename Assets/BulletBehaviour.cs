using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //Generated with AI
    //Prompts were as follows:
    /*
    #a new script, BulletBehaviour. The Gameobject this script is attached to already has a rigidbody2D and a collider. 
    in Start, this will add force to the rigidbody2D. THe force is a pubic variable. 

    #this gameobject has a parent. The AddForce should be applied in the direction the parent object is facing

    #my bad. The gameObject has no parent. Find a GameObjects with the tag BulletOrigin. 
    Use the direction of the first GameObject that is returned by FInd
    */
    //few manual changes

    public float forceAmount = 10f;   // Public variable for the force amount

    private Rigidbody2D rb;           // Reference to the Rigidbody2D component

    private void Start()
    {
        // Get the reference to the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Add force to the Rigidbody2D
        rb.AddForce(-transform.up * forceAmount, ForceMode2D.Impulse);

        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Check if the trigger collision occurred with the attached BoxCollider2D component
        if (collision.CompareTag("RiverFlow"))
        {
            transform.localRotation = flippedZ();
            //mult by 2 as first one merely cancels the previous force and there is no gravity
            rb.AddForce(transform.up * forceAmount * 1.5f, ForceMode2D.Impulse);
        }
    }

    Quaternion flippedZ()
	{
        return Quaternion.Euler(0, 0, -transform.eulerAngles.z);
    }
}
