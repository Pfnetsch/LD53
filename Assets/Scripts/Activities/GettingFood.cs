using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingFood : Activity
{

    public GettingFood()
        : base("GettingFood", 0)
    {
    }

    public override void DoIt(Cat cat)
    {
        float time = 0.0f;
        float interpolationPeriod = 1;

        if (cat.Hunger < 100)
        {

            time += Time.deltaTime;

            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                cat.Hunger += 2;
            }
        }
    }
}
