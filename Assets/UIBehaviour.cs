using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    public TextMeshProUGUI timer;   // Public TextMeshProUGUI variable
    public TextMeshProUGUI fish_missed;   // Public TextMeshProUGUI variable
    public GameObject screen;
    public GameObject texts;

    public FishSpawner fishesInfo;

    private float timeElapsed = 0f;       // Time elapsed
    private float timeRemaining = 0f;       // Time elapsed another

    private void Update()
    {
        // Update the time elapsed
        timeElapsed += Time.deltaTime;
        timeRemaining = 91f - timeElapsed;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
        }
        if(timeElapsed>105)
		{
            screen.SetActive(true);
            texts.SetActive(true);
		}
		else
		{
            screen.SetActive(false);
            texts.SetActive(false);
        }
        // Update the text with the time elapsed
        timer.text = "Time Elapsed: " + timeRemaining.ToString("F2");

        fish_missed.text = "You missed " + fishesInfo.GetFishesDestroyed().ToString() + " fishes";
    }
}
