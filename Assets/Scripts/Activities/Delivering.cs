using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivering : Activity
{
    public Delivery Delivery { get; set; }

    public Delivering(Delivery delivery)
            : base("Delivering", delivery.Duration)
    {
        Delivery = delivery;
    }

    public override bool DoIt()
    {
        float time = 0.0f;
        float interpolationPeriod = 1;

        int durationLeft = Delivery.Duration;

        if (durationLeft > 0)
        {
            time += Time.deltaTime;

            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                durationLeft -= 1;
            }
        }
        else
        {

        }
    }
}
