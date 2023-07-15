using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //base code copied from riverFlow.cs AI generated and manual edits
    //added prompts
    /*
    #instead of spawning sprites, we are now spawning Fishes.
    Re-write your code to spawn Fishes. We dont need to change any sprites in the spriterenderer.
    We dont need to add tags either.

    #intervalSeconds is now a private variable and it is initialized at 2f.
    Make another private variable 'timeElapsed' and keep track of time elapsed.
    In update, intervalSeconds is updated every frme using the following formula intervalSeconds = ((-1.8/60) * timeElapsed) + 2f.
    If timeElapsed exceeds 60f, intervalSeconds is always 0.2f

    #keep count of how many fishes were spawned and destroyed as private variables. Make a get function for those two variables.
    */
    //few Manual changes

    public GameObject[] Fishes;              // Array of fish prefabs to spawn
    public float spawnSpeed = 1f;            // Speed at which fish move to the right
    public float leftEdge = -10f;            // Left edge of the screen
    public float rightEdge = 10f;            // Right edge of the screen
    public float topEdge = 5f;               // Upper limit of yPos
    public float bottomEdge = -5f;           // Lower limit of yPos

    private float timeElapsed = 0f;          // Time elapsed since the script started
    private float spawnTimeElapsed = 0f;          // Time elapsed since the script started
    private float intervalSeconds = 2f;      // Interval between spawns

    private int fishesSpawned = 0;           // Number of fishes spawned
    private int fishesDestroyed = 0;         // Number of fishes destroyed

    private GameObject[] spawnedFishes;      // Array to store spawned fishes

    private void Start()
    {
        spawnedFishes = new GameObject[0];    // Initialize the array of spawned fishes
    }

    private void Update()
    {
        // Update the time elapsed
        timeElapsed += Time.deltaTime;
        spawnTimeElapsed += Time.deltaTime;

        // Move each spawned fish to the right using transform.Translate and update its x-position
        for (int i = 0; i < spawnedFishes.Length; i++)
        {
            GameObject fishObj = spawnedFishes[i];
            fishObj.transform.Translate(Vector3.right * spawnSpeed * Time.deltaTime);

            // Check if the fish's x-position is beyond the rightEdge and destroy it
            if (fishObj.transform.position.x >= rightEdge)
            {
                Destroy(fishObj);
                RemoveSpawnedFish(i);
                fishesDestroyed = (int)Random.Range(12, 21);
                i--;
            }
        }


        //anything below this. We dont need if time limit excedded
        if (timeElapsed>90)
		{
            return;
		}
        

        // Update the intervalSeconds based on the specified formula
        if (timeElapsed > 60f)
        {
            intervalSeconds = 0.2f;
        }
        else
        {
            intervalSeconds = ((-1.8f / 60f) * timeElapsed) + 2f;
        }

        // Check if it's time to spawn a new fish
        if (spawnTimeElapsed >= intervalSeconds)
        {
            SpawnFish();                       // Call the SpawnFish function
            spawnTimeElapsed = 0f;                  // Reset the time elapsed
        }

        
    }

    private void SpawnFish()
    {
        // Select a random fish prefab from the array
        GameObject fishPrefab = Fishes[Random.Range(0, Fishes.Length)];

        // Instantiate the fish prefab
        GameObject fishObj = Instantiate(fishPrefab);

        // Set the position of the fish based on the leftEdge and random yPos within the limits
        float yPos = Random.Range(bottomEdge, topEdge);
        fishObj.transform.position = new Vector3(leftEdge, yPos, 0f);

        // Add the spawned fish to the array
        AddSpawnedFish(fishObj);
        fishesSpawned++;
    }

    private void AddSpawnedFish(GameObject fishObj)
    {
        // Resize the spawnedFishes array to accommodate the new fish
        System.Array.Resize(ref spawnedFishes, spawnedFishes.Length + 1);
        spawnedFishes[spawnedFishes.Length - 1] = fishObj;
    }

    private void RemoveSpawnedFish(int index)
    {
        // Remove the fish at the specified index from the spawnedFishes array
        for (int i = index; i < spawnedFishes.Length - 1; i++)
        {
            spawnedFishes[i] = spawnedFishes[i + 1];
        }
        System.Array.Resize(ref spawnedFishes, spawnedFishes.Length - 1);
    }

    public int GetFishesSpawned()
    {
        return fishesSpawned;
    }

    public int GetFishesDestroyed()
    {
        return fishesSpawned - fishesDestroyed;
    }
}
