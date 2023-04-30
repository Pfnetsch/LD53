using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    // CAT
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

    public Cat(int points)
    {
        // 100 Points = max. Cat
        int randC = Random.Range(1, points);
        // int randS = Random.Range(1, 3);
        // Speed = randS;

        // int randP = (randC + (randS * 3)) / 2;

        WeightCapacity = Global.RoundToNearestX((randC * Global.CatWeightFactor), 100);
        Price = Global.RoundToNearestX((randC * Global.CatPriceFactor), 10);

        // Stats
        Hunger = 100;
        EnergyStatus = 100;
    }

    public void DoActivity()
    {
        CurrentActivity.DoIt(this);
    }

    public override string ToString()
    {
        string s = $"CAT: {Name}\nPerks: WeightCapacity {WeightCapacity}, Price {Price} - Stats: Hunger {Hunger}, Engergy {EnergyStatus}";
        return s;
    }

}
