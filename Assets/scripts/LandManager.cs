using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
 
    public Land startPoint;  //land script 
    private Transform PlayerTransform; // player position
    private static bool isCreating = false; //to check if new blocks are adding

    // Use this for initialization
    private void Start()
    {
        foreach (Land x in LandManager.CreateNext(startPoint))
            foreach (Land y in LandManager.CreateNext(x))
                foreach (Land z in LandManager.CreateNext(y))
                    LandManager.CreateNext(z);                     //??

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform; //adding positions to the player 

    }


    public static List<Land> CreateNext(Land land)   //function to create new blocks
    {
        print(isCreating);
        
        isCreating = true;   //set the bool to true
        List<GameObject> next = new List<GameObject>();   // create a new list called next
        int dir = Random.Range(0,4);   //make a random selection from the positions
        switch (dir)  //how to change directions
        {
            case 0:  //straight 
                next.Add(Instantiate(land.Path, land.PathSpawnPoints[0].position, land.PathSpawnPoints[0].rotation) as GameObject);
                break;
            case 1:  //Left 
                next.Add(Instantiate(land.Path, land.PathSpawnPoints[1].position, land.PathSpawnPoints[1].rotation) as GameObject);
                break;
            case 2:  //Right 
                next.Add(Instantiate(land.Path, land.PathSpawnPoints[2].position, land.PathSpawnPoints[2].rotation)as GameObject);
                break;
            case 3:  //Left and Right 
                next.Add(Instantiate(land.Path, land.PathSpawnPoints[1].position, land.PathSpawnPoints[1].rotation) as GameObject);
                next.Add(Instantiate(land.Path, land.PathSpawnPoints[2].position, land.PathSpawnPoints[2].rotation) as GameObject);
                break;
        }

        List<Land> landList = new List<Land>();  //create a new list
        foreach (var x in next)    //    whaaattt isss xxx? is it the directions in next
        {
            landList.Add(x.GetComponent<Land>());   //add a new point to land list from land script
            landList[landList.Count - 1].Root = land;  //??
        }

        isCreating = false;  //set the bool to false
        return landList;

    }

    public static void DeleteLand(Land land)  //remove a script land
    {
        Destroy(land); // delete script land
    }

    public static void DeleteLandAfterTurn(Land land)
    {
    }
    
}


