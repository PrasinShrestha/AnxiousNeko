using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoBehaviour : MonoBehaviour
{
    //Generated with AI
    //added prompts
    /*
    #new script, NekoBehaviour. 
    Two public gameobjects. HandOrigin and BulletOrigin.
    Based on horizontal input of mouse, the hand origin will rotate on z axis. Use Input.GetAxis

    #restrict the rotation of handOrigin between -75 and 70 deg on z axis. No need to rotate BulletOrigin

    #declare a public GameObject BulletOrigin.
    
    #rewrite without using  Quaternion. Stick to localEulerAngles

    #no need to restrict the rotation. default the rotationSpeed to 950f. 
    If right mouse is pressed, rotation speed is equal to precisionSpeed. 
    precisionSpeed is a new public float variable default to 500f

    #if the left mouse is pressed, it instantiates a GameObject 'Bullet'. It is a public variable. T
    he instance point is the position of BulletOrigin. the rotation of the instanced is 0,0,0

    */
    //few Manual changes

    public GameObject HandOrigin;        // Public GameObject for the hand origin
    public GameObject BulletOrigin;      // Public GameObject for the bullet origin
    public GameObject BulletPrefab;      // Public GameObject prefab for the bullet
    public float rotationSpeed = 950f;   // Default rotation speed of the hand origin
    public float precisionSpeed = 500f;  // Rotation speed when right mouse button is pressed

    private void Update()
    {
        // Check if the right mouse button is pressed
        bool isRightMousePressed = Input.GetMouseButton(1);

        // Set the rotation speed based on the mouse button
        float currentRotationSpeed = isRightMousePressed ? precisionSpeed : rotationSpeed;

        // Get the horizontal input of the mouse
        float horizontalInput = Input.GetAxis("Mouse X");

        // Calculate the rotation amount based on the input and rotation speed
        float rotationAmount = horizontalInput * currentRotationSpeed * Time.deltaTime;

        // Get the current rotation of the hand origin
        Vector3 currentRotation = HandOrigin.transform.localEulerAngles;

        // Calculate the new rotation after applying the rotation amount
        float newZRotation = currentRotation.z + rotationAmount;

        // Apply the new rotation to the hand origin
        HandOrigin.transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, newZRotation);

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate a new Bullet at the position of BulletOrigin with rotation (0, 0, 0)
            Instantiate(BulletPrefab, BulletOrigin.transform.position, HandOrigin.transform.rotation);
        }
    }
}

