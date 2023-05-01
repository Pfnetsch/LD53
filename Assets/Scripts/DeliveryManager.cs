using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;

    public List<Cat> CatForce { get; set; } = new List<Cat>();

    public SpriteAtlas CatAtlas;
    private List<int> _notUsedSprites = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27 };

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Add Starter Cats to List
        Cat starterCat1 = new Cat("Gin", "Gin is very lively and loves to play with other cats.", GetNewCatSprite(), 2000, 100);
        Cat starterCat2 = new Cat("Tonic", "Tonic is a little shy with strangest but loves to cuddle.", GetNewCatSprite(), 2000, 100);
        starterCat1.CurrentActivity = new Resting();
        starterCat2.CurrentActivity = new Resting();
        CatForce = new List<Cat>();
        CatForce.Add(starterCat1);
        CatForce.Add(starterCat2);

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
        foreach (Cat cat in CatForce)
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
        if (CatForce[cat].CurrentActivity is Resting)
        {
            CatForce[cat].CurrentActivity = new GettingFood();
        }
    }

    public void SendCatOnDelivery(int cat)
    {
        if (CatForce[cat].CurrentActivity is Resting)
        {
            CatForce[cat].CurrentActivity = new Delivering(SelectedDelivery);
        }
    }

    // MONEY
    private int Money = Global.StartingMoney;
    private int FoodCost = Global.FoodCost;

    public void AddMoney(int income)
    {
        Money += income;
    }

    public void SpendMoney(int price)
    {
        Money -= price;
    }

    // CAT Stuff

    public Sprite GetNewCatSprite()
    {
        var rand = Random.Range(0, (_notUsedSprites.Count - 1));
        string nameOfSprite = "Cats24_" + _notUsedSprites[rand];
        _notUsedSprites.RemoveAt(rand);

        return CatAtlas.GetSprite(nameOfSprite);
    }


    // DELIVERIES
    // list of available deliveries
    // list of active deliveries
    // list of finished deliveriesunit
    public List<Delivery> AvailableDeliveries { get; set; } = new List<Delivery>();
    public List<Delivery> ActiveDeliveries { get; set; } = new List<Delivery>();
    public List<Delivery> FinishedDeliveries { get; set; } = new List<Delivery>();

    public Delivery SelectedDelivery { get; set; }

    public void GenerateDelivery()
    {
        Delivery d = new Delivery(Global.MaxCatPointList[Global.Day - 1]);
        Debug.Log(d);
        AvailableDeliveries.Add(d);
    }

    public void AfterTwentySeconds()
    {
        GenerateDelivery();
    }


    // BASE & CAT STATS
    // passive Energy gain when Cats are in Base

    public void StatusManagement()
    {
        foreach (Cat cat in CatForce)
        {
            cat.Hunger -= 1;

            if (cat.CurrentActivity is Resting)
            {
                // Upgrades for Base will give more recreation for energy
                cat.Energy += 1;
            }
            else if (cat.CurrentActivity is Delivering)
            {
                cat.Energy -= 1;
            }
            Debug.Log(cat.Name + ": " + cat.Energy);
            Debug.Log(cat.Name + ": " + cat.Hunger);
        }
    }


    // TIME MANAGEMENT

    public void AfterFiveSeconds()
    {
        Debug.Log("interpolating");

        StatusManagement();
    }
}
