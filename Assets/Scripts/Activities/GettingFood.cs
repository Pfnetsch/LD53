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
        if (cat.Hunger < 100)
        {
            ExpiredTime += Time.deltaTime;

            if (ExpiredTime >= 1)
            {
                ExpiredTime = 0.0f;

                cat.Hunger += 2;
            }
        }
        else
        {
            Finished = true;
        }
    }
}
