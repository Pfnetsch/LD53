using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat
{
    public string Name { get; set; }

    public string Bio { get; set; }

    public Sprite Picture { get; set; }

    // Perks
    public int Price { get; set; }
    public int WeightCapacity { get; set; }

    // Stats
    public int Hunger { get; set; }

    private int _energyStatus;

    public int EnergyStatus
    {
        get { return _energyStatus; }
        set 
        {
            if (value <= 100 && value >= 0)
            _energyStatus = value; 
        }
    }


    public Activity CurrentActivity { get; set; }


    public Cat(string name, string bio, Sprite picture, int weightCapacity, int price)
    {
        Name = name;
        Bio = bio;
        Picture = picture;
        WeightCapacity = weightCapacity;
        Hunger = 100;
        EnergyStatus = 90;
        Price = price;
    }

    public void DoActivity()
    {
        CurrentActivity.DoIt();
    }

    public void eat()
    {
        float time = 0.0f;
        float interpolationPeriod = 1;

        CurrentActivity = new GettingFood();

        while (Hunger < 100)
        {

            time += Time.deltaTime;

            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                Hunger += 2;
            }
        }
    }

}
