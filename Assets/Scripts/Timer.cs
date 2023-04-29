using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0.0f;
    public float interpolationPeriod = 5;

    private float timeOfDay = 60;
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    public int days = 7;

    // Classes affected by Interpolation Period
    public GameObject gameManager;

    private void Start()
    {
        // Starts the Timer automatically
        timeRemaining = timeOfDay;
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                // Interpolation Period
                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;

                    // every 5 seconds
                    gameManager.BroadcastMessage("AfterFiveSeconds");
                }
            }
            else if (days > 0)
            {
                Debug.Log("Day " + (days - 7) + " is over!");
                timeRemaining = timeOfDay;
                days -= 1;

                // every day
                gameManager.BroadcastMessage("OneDayOver");
            }
            else
            {
                Debug.Log("Week is over! The end.");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }


}
