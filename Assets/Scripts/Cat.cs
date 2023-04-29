using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat
{
    public string Name { get; set; }

    public string Bio { get; set; }

    public Sprite Picture { get; set; }

    // Perks
    public int Hunger { get; set; }

    // Stats
    public int WeightCapacity { get; set; }

    public int EnergyStatus { get; set; }

    public Activity CurrentActivity { get; set; }

}
