using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    // Time
    public static int SecondsOfDay = 10;
    public static int NumberOfGameDays = 7;

    // Day Points
    public static int[] MaxCatPointList = { 50, 60, 70, 80, 90, 100, 100 };
    public static int Day = 1;

    // Cats
    public const float CatPriceFactor = 6f;

    public const float CatWeightFactor = 20f;


    // Deliveries
    public const float DeliveryPaymentFactor = 4f;

    public const float DeliveryWeightFactor = 18f;

    public const float DeliveryDurationFactor = 0.4f;

    public const float DeliveryDeadlineFactor = 0.4f;




    public static int RoundToNearestX(float number, int x)
    {
        return (int)System.Math.Round(number / 100, 0) * x;
    }
}
