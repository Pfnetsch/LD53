using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Delivery
{
    public int Weight { get; set; }

    public int Payment { get; set; }

    public int Deadline { get; set; }

    public int Duration { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Delivery(int points)
    {
        Debug.Log(points);

        int randW = Random.Range(5, points);
        int randD = Random.Range(25, points);

        Debug.Log("randoms W + D: " + randW + " " + randD);

        int randP = (randW + randD) / 2; // Mean value of weight and duration

        Weight = Global.RoundToNearestX((randW * Global.DeliveryWeightFactor), 100);
        Duration = Global.RoundToNearestX((randD * Global.DeliveryDurationFactor), 10);

        Payment = Global.RoundToNearestX((randP * Global.DeliveryPaymentFactor), 10);

        Deadline = Global.RoundToNearestX((Duration * Global.DeliveryDeadlineFactor), 10);

    }

    public override string ToString()
    {
        return $"DELIVERY: {Title}\nWeight {Weight}, Duration {Duration}, Deadline {Deadline}, Payment {Payment}";
    }

}
