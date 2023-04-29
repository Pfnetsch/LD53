using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    public List<Cat> ShelterCats { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void oneDayOver()
    {
        Debug.Log("one day over: get new cats in shelter");
        addCatsToShelter();
    }

    public void addCatsToShelter()
    {

    }

    public Cat buyCat()
    {
        return null;
    }
}
