using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riverFlow : MonoBehaviour
{
    //Generated with AI
    //Prompts were as follows:
    /*
    #pretend you are a intermediate Unity C# developer. Write a code that takes an array of 2D sprites as a public variable. 
    Then randomly spawn those sprites from left side of the screen. The spawned sprites will travel to the right side, and their speed is controlled by a public variable. 
    Once they reach right side of the screen, the spawned object will be drstroyed

    #instead of left side and right side of the screen, those spawn and destroy points will be determined by two public variables 'leftEdge' and 'rightEdge'. 
    The sprites are spawned at co-ordinates where leftEdge is the x component of its world space location. 
    The sprites are destroyed if the sprites' x component of the world space location is more then rightEdge

    #rewrite your code, and do not use Rigidbody. 
    Instead write a simple transform.translate and update the x component of world space location each frame. 
    Also, dont forget to add tag "Sprite" when you make the GameObject

    #add two public variables, 'topEdge' and 'bottomEdge'. 
    These two variables are the upper and lower limit of yPos in the Random.Range function you used

    #right now, your script only spawns one object. Call your SpawnSprite function an interval of 'intervalSeconds' in seconds. 
    intervalSeconds is a public variable with default value at 2.f. 
    Keep track of multiple spawns in an array
    */
    //some manual changes

    public Sprite[] sprites;                // Array of 2D sprites to spawn
    public float spawnSpeed = 1f;           // Speed at which sprites move to the right
    public float leftEdge = -10f;           // Left edge of the screen
    public float rightEdge = 10f;           // Right edge of the screen
    public float topEdge = 5f;              // Upper limit of yPos
    public float bottomEdge = -5f;          // Lower limit of yPos
    public float intervalSeconds = 2f;      // Interval between spawns
    public string assignedTag, spawnedName;

    private float timeSinceLastSpawn = 0f;  // Time since the last spawn
    private GameObject[] spawnedSprites;    // Array to store spawned sprites

    private void Start()
    {
        spawnedSprites = new GameObject[0]; // Initialize the array of spawned sprites
    }

    private void Update()
    {
        // Check if it's time to spawn a new sprite
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= intervalSeconds)
        {
            SpawnSprite();                    // Call the SpawnSprite function
            timeSinceLastSpawn = 0f;          // Reset the time since last spawn
        }

        // Move each spawned sprite to the right using transform.Translate and update its x-position
        for (int i = 0; i < spawnedSprites.Length; i++)
        {
            GameObject spriteObj = spawnedSprites[i];
            spriteObj.transform.Translate(Vector3.right * spawnSpeed * Time.deltaTime);

            // Check if the sprite's x-position is beyond the rightEdge and destroy it
            if (spriteObj.transform.position.x >= rightEdge)
            {
                Destroy(spriteObj);
                RemoveSpawnedSprite(i);
                i--;
            }
        }
    }

    private void SpawnSprite()
    {
        // Select a random sprite from the array
        Sprite sprite = sprites[Random.Range(0, sprites.Length)];

        // Create a new GameObject with a SpriteRenderer component and assign the "Sprite" tag
        GameObject spriteObj = new GameObject(spawnedName);
        spriteObj.tag = assignedTag;

        SpriteRenderer spriteRenderer = spriteObj.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.renderingLayerMask = 3;
        // Set the position of the sprite based on the leftEdge and random yPos within the limits
        float yPos = Random.Range(bottomEdge, topEdge);
        spriteObj.transform.position = new Vector3(leftEdge, yPos, 0f);

        // Add the spawned sprite to the array
        AddSpawnedSprite(spriteObj);
    }

    private void AddSpawnedSprite(GameObject spriteObj)
    {
        // Resize the spawnedSprites array to accommodate the new sprite
        System.Array.Resize(ref spawnedSprites, spawnedSprites.Length + 1);
        spawnedSprites[spawnedSprites.Length - 1] = spriteObj;
    }

    private void RemoveSpawnedSprite(int index)
    {
        // Remove the sprite at the specified index from the spawnedSprites array
        for (int i = index; i < spawnedSprites.Length - 1; i++)
        {
            spawnedSprites[i] = spawnedSprites[i + 1];
        }
        System.Array.Resize(ref spawnedSprites, spawnedSprites.Length - 1);
    }
}
