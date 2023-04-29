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



    // BASE
    // passive Energy gain when Cats are in Base

    public void energyManagement()
    {
        foreach (Cat cat in MyCats) 
        {
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



    // TIME MANAGEMENT
    public Timer Timer;

    public void afterFiveSeconds()
    {
        Debug.Log("interpolating");

        energyManagement();
    }

    // SHELTER
    public Shelter Shelter;

    public void openShelter()
    {

    }
}
