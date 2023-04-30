using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Shelter : MonoBehaviour
{
    public List<Cat> ShelterCats = new List<Cat>();

    public void OneDayOver()
    {
        Debug.Log("one day over: get new cats in shelter");
        Global.Day += 1;
        GenerateCatsForShelter(3);
    }

    public void GenerateCatsForShelter(int numberOfCats)
    {
        ShelterCats.Clear();

        for (int i = 0; i < numberOfCats; i++)
        {

            Sprite sprite = DeliveryManager.Instance.GetNewCatSprite();
            Cat c = new Cat(Global.MaxCatPointList[Global.Day - 1], sprite);
            Debug.Log(c);
            ShelterCats.Add(c);
        }

        Debug.Log(ShelterCats);
    }

    public Cat BuyCat()
    {
        return null;
    }
}
