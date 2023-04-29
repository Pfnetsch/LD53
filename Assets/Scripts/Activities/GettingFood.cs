using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingFood : Activity
{
    public int Cost { get; set; }

    public GettingFood()
        : base("GettingFood", 0)
    {
        Cost = 10;
    }

    public override bool DoIt()
    {
        throw new System.NotImplementedException();
    }
}
