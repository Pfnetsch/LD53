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
        //if (cat.CurrentActivity == null)
        //{
        //    AddMoney(delivery.Payment);
        //}


        // Loop do Cats
        foreach (Cat cat in MyCats)
        {
            if (cat.CurrentActivity.Finished)
            {
                switch (cat.CurrentActivity)
                {
                    case Delivering:
                        AddMoney(((Delivering)cat.CurrentActivity).Delivery.Payment);
                        break;
                    default:
                        break;
                }

                cat.CurrentActivity = new Resting();
            }
            cat.DoActivity();
        }
    }

    // BUTTONS - getcomponent verwenden?!
    public void FeedCat(int cat)
    {
        if (MyCats[cat].CurrentActivity is Resting)
        {
            MyCats[cat].CurrentActivity = new GettingFood();
        }
    }

    public void SendCatOnDelivery(int cat)
    {
        if (MyCats[cat].CurrentActivity is Resting)
        {
            MyCats[cat].CurrentActivity = new Delivering(SelectedDelivery);
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

    public Delivery SelectedDelivery { get; set; }



    // BASE & CAT STATS
    // passive Energy gain when Cats are in Base

    public void StatusManagement()
    {
        foreach (Cat cat in MyCats)
        {
            cat.Hunger -= 1;

            if (cat.CurrentActivity is Resting)
            {
                // Upgrades for Base will give more recreation for energy
                cat.EnergyStatus += 1;
            }
            else if (cat.CurrentActivity is Delivering)
            {
                cat.EnergyStatus -= 1;
            }
            Debug.Log(cat.Name + ": " + cat.EnergyStatus);
            Debug.Log(cat.Name + ": " + cat.Hunger);
        }
    }


    // TIME MANAGEMENT

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
