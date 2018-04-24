using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

    public static List<Land> EndPoints;    //create a list for this scrip
    public Transform[] PathSpawnPoints;     //create an array for the points that can have a new block road 
    public Land Root;    //this script 
    private static bool _isCrossway = false;   //bool to know if it is a croos road
    internal bool _nextStraight = false; //to make the next block straight
    public uint lastActivId = 0;   //setting the last block to ID 0
    private static uint lastActivCounter = 0;   //to add up to the last activated block


    public  bool rotate = false;  //bool to check if the player should rotate
    private static swipeTest _swipe;

    private void Start()
    {
        if (_swipe == null) _swipe = GameObject.FindObjectOfType<swipeTest>();
    }
    

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && GetComponents<BoxCollider>()[2].enabled == false)
            rotate = false;
        
    }

    void OnTriggerEnter(Collider collider) //when the player enters the collider
    {
        _swipe.land = this;
        Land standing = this;            //to start with the one the player stands on
        while (standing.Root != null)  // keep counting one block backwards
            standing = standing.Root;   // till it finds the first block and set it 
        
        standing.lastActivId = lastActivCounter++;  //give id to the last activated block
     
        

        if (collider.gameObject.tag == "Player" && GetComponents<BoxCollider>()[2].enabled == true)  //when the player enters the rotate collider
        {
            rotate = true; //set the bool to true
            
        }
       
       

            if (_isCrossway)  //if the roade is crossy
        {
            _isCrossway = false;  //set the bool to false
        }


        int counter = transform.GetComponentsInChildren<Land>().Length;
     //   print("test counter: " + counter);
        if (counter >= 7)    //if there are more then 7 blocks after this block
        {
          //stop creating new blocks
            return;

        }


        if (transform.childCount >= 5)    //if there are more then 5 blocks
        { 
            _isCrossway = true;           //that means it is a cross Roade
        

        }

        if (collider.gameObject.tag == "Player")     //if the player enters the collider
        {
           
            if (EndPoints != null)     //if there is an end point
            {
               // print(EndPoints.Count);
               
                List<Land> temp = new List<Land>();      //create temperarly list to delete later 
                while (EndPoints.Count > 0)            //as long as there is an end point
                {
                    if(EndPoints[0] == null)
                    {
                        EndPoints.RemoveAt(0);
                        continue;
                    }
                 print("after if there is" + temp.Count);
                   if (EndPoints[0]._nextStraight)  //if the straight bool is true 
                   {
                       temp.AddRange(LandManager.CreateNext(EndPoints[0], 0 ));  //add a block with a straight case
                       
                   }
                   else    //if not true
                   {
                       if (GetPossibleDirections(EndPoints[0]).Length > 0)
                           temp.AddRange(LandManager.CreateNext(EndPoints[0], GetPossibleDirections(EndPoints[0])));  //add another block
                       else
                            temp.AddRange(LandManager.CreateNext(EndPoints[0], GetPossibleDirections(EndPoints[0])));
                        print("Invalid Endpoint");
                   }

                 

                    EndPoints.RemoveAt(0);  //after we created a block after the endpoint it no longer is an endpoint, so we remove it
                }
                if (temp.Count == 0)
                    throw new System.Exception("end of endpoints");

                // if there is more then one endpoint mix the order
                if(temp.Count > 1)
                {
                    List<Land> temp_mix = new List<Land>();
                    while(temp.Count > 0)
                    {
                        var rnd = Random.Range(0, temp.Count);
                        temp_mix.Add(temp[rnd]);
                        temp.RemoveAt(rnd);
                    }
                    temp.AddRange(temp_mix);
                }

                EndPoints = temp;   // save the new enpoints in the list

            }
            else     //if the list is empty
            {
                EndPoints = LandManager.CreateNext(GetComponent<Land>(), GetPossibleDirections(this));  //add a land script to add a block
            }
            

            if (Root != null && Root.Root != null && Root.Root.Root != null)   //if the last block is there and the one before
                LandManager.DeleteLand(Root.Root.Root, Root.Root);  //delet and remove the one befor the last one
        }

        LandManager.CheckForMultipleRoots();  //check if there is more then one roade 
    }
    public static void SetEndPoint(Land l)   //function to set the end point
    {
        if (EndPoints == null)          //if the end point is not there
            EndPoints = new List<Land>();    //more like init list EndPoints is a Land < List > it just isnt initialized(if its null)
            EndPoints.Add(l);  // add one end point 
    }

    /// <summary>
    /// this is for the raycast
    /// </summary>
    /// <param name="l">the end of the path</param>
    /// <returns></returns>
    private int[] GetPossibleDirections(Land l) 
    {
        List<int> dirs = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            if (l == null || l.PathSpawnPoints[i] == null) break;
            //Debug.DrawLine(l.PathSpawnPoints[i].position, l.PathSpawnPoints[i].position + l.PathSpawnPoints[i].forward * 30, Color.cyan);
            if (Physics.Raycast(l.PathSpawnPoints[i].position, l.PathSpawnPoints[i].forward, 30f))   //if there a block in the way the raycast is going then dont add a new block
                continue;
            if (Physics.Raycast(l.PathSpawnPoints[i].position, l.PathSpawnPoints[i].right, 30f))   //if there a block in the way the raycast is going then dont add a new block
                continue;
            if (Physics.Raycast(l.PathSpawnPoints[i].position, l.PathSpawnPoints[i].right*-1, 30f))   //if there a block in the way the raycast is going then dont add a new block
                continue;
            dirs.Add(i);

        }
        if(dirs.Contains(1) && dirs.Contains(2))  //we want to check that the raycast looked at left and right dirctions so we can test the cross road
        {
            dirs.Add(3);
        }

        return dirs.ToArray();
    }
      



}
