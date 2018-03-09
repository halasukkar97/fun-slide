using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

    public static List<Land> EndPoints;    //create a list for this script

    public Transform[] PathSpawnPoints;     //create an array for the points that can have a new block road

    public GameObject Path;     //path is the game object block that is used to create a path 

    public Land Root;    //this script 

    private static bool _rotate = false;  //bool to make the player rotate

    private static bool _isCrossway = false;   //bool to know if it is a croos road

    internal bool _nextStraight = false; //to make the next block straight

    public uint lastActivId = 0;   //setting the last block to ID 0

    private static uint lastActivCounter = 0;   //to add up to the last activated block

    
    void OnTriggerEnter(Collider collider) //when the player enters the collider
    {
        Land standing = this;            //to start with the one the player stands on
        while (standing.Root != null)  // keep counting one block backwards
            standing = standing.Root;   // till it finds the first block and set it 
        standing.lastActivId = lastActivCounter++;  //give id to the last activated block

       
        if (_isCrossway)  //if the roade is crossy
        {
            _isCrossway = false;  //set the bool to false
        }


        if (transform.childCount >= 5)    //if there are more then 5 blocks
            _isCrossway = true;           //that means it is a croos Roade

        
        if (collider.gameObject.tag == "Player")     //if the player enters the collider
        {
            if (EndPoints != null)     //if there is an end point
            {
               
                List<Land> temp = new List<Land>();      //create temperarly list     //what si Temp??
                while (EndPoints.Count > 0)            //as long as there is an end point
                {
                    if (EndPoints[0]._nextStraight)  //if the end point is....??
                    {
                       
                        temp.AddRange(LandManager.CreateNext(EndPoints[0], 0));  //add a block with a straight case 
                    }
                    else    //if not
                    {
                        temp.AddRange(LandManager.CreateNext(EndPoints[0]));  //add another block
                        
                    }

                    EndPoints.RemoveAt(0);  //?? 
                }

                EndPoints = temp;      //  ??
            }
            else     //if the list is empty
            {
                EndPoints = LandManager.CreateNext(GetComponent<Land>());  //add a land script to add a block
            }
            
            if (Root != null && Root.Root != null)   //if the last block is there and the one before
                LandManager.DeleteLand(Root.Root, Root);  //delet and remove the one befor the last one
        }

        LandManager.CheckForMultipleRoots();  //check if there is more then one roade 
    }
    public static void SetEndPoint(Land l)   //function to set the end point
    {
        if (EndPoints == null)          //if the end point is not there
            EndPoints = new List<Land>();    //make the end point a land list
        EndPoints.Add(l);  // add one end point 
    }

      



}
