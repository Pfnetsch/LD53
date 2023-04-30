using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int randW = Random.Range(1, points);

        Weight = randW * Global.DeliveryWeightFactor;

        Payment = randW * Global.DeliveryPaymentFactor;
    }
}
