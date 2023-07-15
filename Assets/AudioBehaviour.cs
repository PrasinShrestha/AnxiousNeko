using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehaviour : MonoBehaviour
{
    //Generated with AI
    //Prompt
    /*
    create a new script, AudioBehaviour, that takes a audioSouce public variable.It keeps track of time elapsed.
    If time elapsed is between 1 and 91, then the volume is set to half.ELse, it is 1
    
    */
    public AudioSource audioSource;   // Public AudioSource variable

    private float timeElapsed = 0f;   // Time elapsed

    private void Update()
    {
        // Update the time elapsed
        timeElapsed += Time.deltaTime;

        // Check if the time elapsed is between 1 and 91 seconds
        if (timeElapsed >= 1f && timeElapsed <= 91f)
        {
            // Set the volume to half
            audioSource.volume = 1f;
        }
        else
        {
            // Set the volume to maximum (1.0)
            audioSource.volume = 0.5f;

        }
    }
}
