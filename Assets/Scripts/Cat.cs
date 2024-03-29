using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cat : UINotifyProperty
{
    private List<int> _notUsedBios = Enumerable.Range(0, (TextDB.CatBios.Length - 1)).ToList();
    private List<int> _notUsedNames = Enumerable.Range(0, (TextDB.CatNames.Length - 1)).ToList();

    // CAT
    private string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            NotifyValueChanged(value);
        }
    }

    public string Bio { get; set; }

    public Sprite Picture { get; set; }

    // Perks
    public int Price { get => price; 
        set 
        { 
            price = value;
            NotifyValueChanged(value);
        }
    }
    public int WeightCapacity
    {
        get => weightCapacity;
        set
        {
            weightCapacity = value;
            NotifyValueChanged(value);
        }
    }

    // Stats
    private float hunger;
    private float energy;
    private string activityText;
    private Activity currentActivity;
    private int weightCapacity;
    private int price;

    public float Energy
    {
        get { return energy; }
        set
        {
            if (value <= 100 && value >= 0)
            {
                energy = value;
                NotifyValueChanged(value);
            }
        }
    }

    public float Hunger
    {
        get => hunger;
        set
        {
            if (value <= 100 && value >= 0)
            {
                hunger = value;
                NotifyValueChanged(value);
            }
        }
    }

    public string ActivityText
    {
        get => activityText;
        set
        {
            activityText = value;
            NotifyValueChanged(value);
        }
    }

    public Activity CurrentActivity
    {
        get => currentActivity;
        set
        {
            currentActivity = value;
            if (value != null) ActivityText = value.ToString();
        }
    }


    public Cat(string name, string bio, Sprite picture, int weightCapacity, int price)
    {
        Name = name;
        Bio = bio;
        Picture = picture;
        WeightCapacity = weightCapacity;
        Hunger = 100;
        Energy = 90;
        Price = price;
    }

    public Cat(int points, Sprite sprite)
    {
        Name = GetRandomCatName();
        Bio = GetRandomCatBio();

        // 100 Points = max. Cat
        int randC = Random.Range(1, points);
        // int randS = Random.Range(1, 3);
        // Speed = randS;

        // int randP = (randC + (randS * 3)) / 2;

        WeightCapacity = Global.RoundToNearestX((randC * Global.CatWeightFactor), 100);
        Price = Global.RoundToNearestX((randC * Global.CatPriceFactor), 10);

        // Stats
        Hunger = 100;
        Energy = 100;

        Picture = sprite;

        CurrentActivity = new Resting();
    }

    private string GetRandomCatBio()
    {
        var rand = Random.Range(0, (_notUsedBios.Count - 1));
        _notUsedBios.RemoveAt(rand);

        return TextDB.CatBios[rand];
    }

    private string GetRandomCatName()
    {
        var rand = Random.Range(0, (_notUsedNames.Count - 1));
        _notUsedNames.RemoveAt(rand);

        return TextDB.CatNames[rand];
    }

    public void DoActivity()
    {
        CurrentActivity.DoIt(this);
    }

    public override string ToString()
    {
        string s = $"CAT: {Name}\nPerks: WeightCapacity {WeightCapacity}, Price {Price} - Stats: Hunger {Hunger}, Engergy {Energy}";
        return s;
    }

}
