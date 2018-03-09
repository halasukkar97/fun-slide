using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    private static LandManager _self;     // this script
    public Land startPoint;                   //land script 
    private Transform PlayerTransform;            // player position
    private static bool isCreating = false;         //to check if new blocks are adding
    private static bool _isRunning = false;            //to knwo if the game is running 
    private static bool _prep = true;                         //

    
    // Use this for initialization
    private void Start()
    {
        _self = this;           //loade this script
        Land.SetEndPoint(LandManager.CreateNext(LandManager.CreateNext(LandManager.CreateNext(LandManager.CreateNext(LandManager.CreateNext(startPoint, 0)[0],0)[0],0)[0], 0)[0], 0)[0]);   //add 5 straight blocks when the game starts
        _prep = false;            //set the  ?? bool to false
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform; //adding positions to the player 

    }

    private void OnTriggerEnter(Collider other)    //if the player enters the collider
    {
        if (other.tag == "Player")
            _isRunning = true;   //set the bool to true
      
    }
    public static void CheckForMultipleRoots()  //to knwo if we have more then one roade
    {
        List<Land> roots = new List<Land>(); //create a list named roots
        for (int i = 0; i < _self.transform.childCount; i++)      //??
        {
            Land l = _self.transform.GetChild(i).GetComponent<Land>();         //??
            if (l.Root == null)         //if there is no land script 
                roots.Add(l);         //add one
        }

        if(roots.Count >= 2)         //if there is more or two land scripts
        {
            while (roots.Count > 1)         // as long as there is more then one
            {
                int block = roots[0].lastActivId < roots[1].lastActivId ? 0 : 1;   //??
                Destroy(roots[block].gameObject);         //remove the block
                roots.RemoveAt(roots[0].lastActivId < roots[1].lastActivId ? 0 : 1);         //??
            }
        }
    }
    public static List<Land> CreateNext(Land land, int _dir=-1)   //function to create new blocks
    {
        if (land == null || (!_isRunning && !_prep))         //if there is no new blocks or the running bool is false and prep??  is false
        {
            List<Land> block = new List<Land>();         //add land list named block
            block.Add(land);         //add a new block
            return block;         
        }
        isCreating = true;   //set the bool to true
        List<GameObject> next = new List<GameObject>();   // create a new list called next
        int dir = _dir == -1? Random.Range(0,4) : _dir; //make a random selection from the 4 directions

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
        for(int i=0; i < next.Count; i++)          //??
        {
            next[i].transform.SetParent(land.transform);    //??
            landList.Add(next[i].GetComponent<Land>());   //add a new point to land list from land script
            landList[landList.Count - 1].Root = land;  //select the last block

            if (dir != 0) //if the direction is not straight 
            {
                Land.FindObjectsOfType<BoxCollider>()[2].enabled = true;  //
                landList[i]._nextStraight = true;  //add the next block straight
            }
        }

        isCreating = false;  //set the bool to false
        return landList;         
    }

    public static void DeleteLand(Land land, Land child)  //remove a script land
    {
        child.transform.SetParent(_self.transform); //remove the block
        Destroy(land.gameObject); // delete script land
    }
    
    
}


