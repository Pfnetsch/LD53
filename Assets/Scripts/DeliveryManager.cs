using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    void Start()
    {

        // Add Starter Cats to List
        Cat starterCat1 = new Cat("Gin", "Gin is very lively and loves to play with other cats.", Sprites[0], 2000, 100);
        Cat starterCat2 = new Cat("Tonic", "Tonic is a little shy with strangest but loves to cuddle.", Sprites[1], 2000, 100);
        starterCat1.CurrentActivity = new Resting();
        starterCat2.CurrentActivity = new Resting();
        MyCats = new List<Cat>();
        MyCats.Add(starterCat1);
        MyCats.Add(starterCat2);

    }

    // Update is called once per frame
    void Update()
    {

        // check Inputs
        // Input.GetMouseButtonDown(0)

        //if (cat.Hunger < 100 && Money >= FoodCost)
        // {
        //     SpendMoney(FoodCost);
        // }










        // Loop do Cats
        foreach (Cat cat in MyCats)
        {
            cat.DoActivity();
        }

    }

    
    // MONEY
    public int Money = 100;
    public int FoodCost = 10;

    public void AddMoney(int income)
    {
        Money += income;
    }

    public void SpendMoney(int price)
    {
        Money -= price;
    }

    // CAT LIST
    public List<Sprite> Sprites;
    public List<Cat> MyCats { get; set; }
    // cats on delivery tour: cats with activity delivering

    // DELIVERIES
    // list of available deliveries
    // list of active deliveries
    // list of finished deliveriesunit
    public List<Delivery> AvailableDeliveries { get; set; }
    public List<Delivery> ActiveDeliveries { get; set; }
    public List<Delivery> FinishedDeliveries { get; set; }

    public void SendCatOnDelivery(Cat cat, Delivery delivery)
    {
        if (cat.CurrentActivity == null) 
        {
            AddMoney(delivery.Payment);
        }
    }

    // method for finished delivery (addMoney etc)


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

    }


    // TIME MANAGEMENT
    public Timer Timer;

    public void AfterFiveSeconds()
    {
        Debug.Log("interpolating");

        StatusManagement();
    }


    // SHELTER
    public Shelter Shelter;

    public void OpenShelter()
    {

    }
}
