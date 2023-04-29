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
}
