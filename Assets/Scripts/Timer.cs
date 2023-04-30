using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Interpolations
    private float time1 = 0.0f;
    private float interpolationPeriod1 = 5;

    private float time2 = 0.0f;
    private float interpolationPeriod2 = 20;

    private float timeOfDay = Global.SecondsOfDay;
    public static float TimeRemaining = 0;
    public bool timerIsRunning = false;
    public static int days = Global.NumberOfGameDays;

    // Classes affected by Interpolation Period
    public GameObject gameManager;

    private void Start()
    {
        // Starts the Timer automatically
        TimeRemaining = timeOfDay;
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;

                // Interpolation Period
                time1 += Time.deltaTime;

                if (time1 >= interpolationPeriod1)
                {
                    time1 = 0.0f;

                    // every 5 seconds
                    gameManager.BroadcastMessage("AfterFiveSeconds");
                }

                time2 += Time.deltaTime;

                if (time2 >= interpolationPeriod2)
                {
                    time2 = 0.0f;

                    // every 20 seconds
                    gameManager.BroadcastMessage("AfterTwentySeconds");
                }

            }
            else if (days > 0)
            {
                Debug.Log("Day " + (Global.Day) + " is over!");
                TimeRemaining = timeOfDay;
                days -= 1;

                // every day
                gameManager.BroadcastMessage("OneDayOver");
            }
            else
            {
                Debug.Log("Week is over! The end.");
                TimeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }


}
