using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    // MONEY
    public int Money = 100;
    public int FoodCost = 10;

    void Start()
    {

        // Add Starter Cats to List
        Cat starterCat1 = new Cat("Gin", "Gin is very lively and loves to play with other cats.", Sprites[0], 2000, 100);
        Cat starterCat2 = new Cat("Tonic", "Tonic is a little shy with strangest but loves to cuddle.", Sprites[1], 2000, 100);
        MyCats = new List<Cat>();
        MyCats.Add(starterCat1);
        MyCats.Add(starterCat2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    // CAT LIST
    public List<Sprite> Sprites;
    public List<Cat> MyCats { get; set; }

    // DELIVERIES
    // list of available deliveries
    // list of active deliveries
    // list of finished deliveriesunit
    public List<Delivery> AvailableDeliveries { get; set; }
    public List<Delivery> ActiveDeliveries { get; set; }
    public List<Delivery> FinishedDeliveries { get; set; }



    // BASE & CAT STATS
    // passive Energy gain when Cats are in Base

    public void StatusManagement()
    {
        foreach (Cat cat in MyCats)
        {
            cat.Hunger -= 1;

            if (cat.CurrentActivity == null)
            {
                // Upgrades for Base will give more recreation for energy
                cat.EnergyStatus += 1;
            }
            else if (cat.CurrentActivity is Delivering)
            {
                cat.EnergyStatus -= 1;
            }
            Debug.Log(cat.Name + ": " + cat.EnergyStatus);
        }
    }

    public void FeedCat(Cat cat)
    {
        // costs something
        // can only be clicked if cat.Hunger < 100 && Money > 10
        if (cat.Hunger < 100 && Money >= FoodCost)
        {
            float time = 0.0f;
            float interpolationPeriod = 1;

            while (cat.Hunger < 100)
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


    // TIME MANAGEMENT
    public Timer Timer;

    public void afterFiveSeconds()
    {
        Debug.Log("interpolating");

        StatusManagement();
    }


    // SHELTER
    public Shelter Shelter;

    public void openShelter()
    {

    }
}
