using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeOfDay = 60;
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    public int days = 7;

    private void Start()
    {
        // Starts the timer automatically
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
            }
            else if (days > 0)
            {
                Debug.Log("Day " + (days - 7) + " is over!");
                timeRemaining = timeOfDay;
                days -= 1;

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
