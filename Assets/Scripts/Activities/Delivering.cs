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

    public override void DoIt(Cat cat)
    {
        if (NeededTime > 0)
        {
            ExpiredTime += Time.deltaTime;

            if (ExpiredTime >= 1)
            {
                ExpiredTime = 0.0f;

                NeededTime -= 1;
            }
        }
        else
        {
            Finished = true;
        }
    }
}
