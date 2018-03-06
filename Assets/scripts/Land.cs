using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

    private static List<Land> SplitPath;    //create a list for this script

    public Transform[] PathSpawnPoints;     //create an array for the points that can have a new block road
    public GameObject Path;     //path is the game object block that is used to create a path 

    public Land Root;    //this is to add the script 
    
    void OnTriggerEnter(Collider collider)
    {
        //if the player enters the collider
        if (collider.gameObject.tag == "Player")
        {
            if(SplitPath != null) //if the list is not empty 
                foreach(var land in SplitPath) //for every land script in the list 
                {
                    SplitPath = LandManager.CreateNext(land.GetComponent<Land>());  // add another land script to add a block

                    if(Root != null && Root.Root != null)   //if the lest is there and the one before
                        LandManager.DeleteLand(Root.Root);  //delet and remove the one befor the last one
                } 
            else  //if the list is empty
                {
                     SplitPath = LandManager.CreateNext(GetComponent<Land>());  //add a land script to add a block
                }
            
        }
    }
}
