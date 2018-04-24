using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    private static LandManager _self;     // this script
    public Land startPoint;                   //land script 
    private Transform PlayerTransform;            // player position
    private static bool isCreating = false;         //to check if new blocks are adding
    private static bool _isRunning = false;            //to knwo if the game is running 
    private static bool _prep = true;                      //set a preperation bool

    public GameObject Floor; // is the game object block that is used to create a path 

    // Use this for initialization
    private void Start()
    {
        transform.eulerAngles = Vector3.zero;
        _self = this;           //loade this script
        Land.SetEndPoint(LandManager.CreateNext(LandManager.CreateNext(LandManager.CreateNext(LandManager.CreateNext(LandManager.CreateNext(startPoint, 0)[0],0)[0],0)[0], 0)[0], 0)[0]);   //add 5 straight blocks when the game starts
        _prep = false;            //set the preperation bool to false
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

        for (int i = 0; i < _self.transform.childCount; i++)     //we searching in all the child-objects from the LandManager(_self)
        {
            Land l = _self.transform.GetChild(i).GetComponent<Land>();  //we want to look at the <Land> Component so we take it
            if (l.Root == null)         //if there is no land script 
                roots.Add(l);         //add one
        }

        if(roots.Count >= 2)         //if there is more or two land scripts like multiple roades 
        {
            while (roots.Count > 1)         // while we have more then one
            {
                //higher id == player was here last 
                //we compare the first two elemtents and remove the one with the smaller id so block is always 0 or 1
                int block = roots[0].lastActivId < roots[1].lastActivId ? 0 : 1;   //we check the id that we gave them to see an which path the player went  
               //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
               //3l aghlab hon
               //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Destroy(roots[block].gameObject);         //Destroy the block
                roots.RemoveAt(block);      //remove the block index from the list as well 
            }
        }
    }


    public static List<Land> CreateNext(Land land, int dir)
    {    //this is to add to list without having to write that thing down every time and create next b having two functions with the same name and difrent parameter(overload)
        return CreateNext(land, new int[] { dir });
    }



    public static List<Land> CreateNext(Land land, int[] dirs)   //function to create new blocks
    {

        if (land == null || (!_isRunning && !_prep) || dirs.Length == 0) //if there is no new blocks or the running bool is false and preperation is false
        {
           
            // print("do not create a new block.");
           // print("isRunning: " + _isRunning);
           // print("isprep: " + _prep);
           // print("land is null: " + (land == null));
            List<Land> block = new List<Land>();   //add land list named block
            block.Add(land); //add a new block
 
            return block; 
           

        }
        isCreating = true;   //set the bool to true
        List<GameObject> next = new List<GameObject>();   // create a new list called next a list of GameObjects

        int dir = dirs[Random.Range(0,dirs.Length)]; //make a random selection from the 4 directions

        switch (dir)  //how to change directions
        {
            case 0:  //straight 
                next.Add(Instantiate(_self.Floor, land.PathSpawnPoints[0].position, land.PathSpawnPoints[0].rotation) as GameObject);
               // land.GetComponents<BoxCollider>()[2].enabled = false;
                break;
            case 1:  //Left 
                next.Add(Instantiate(_self.Floor, land.PathSpawnPoints[1].position, land.PathSpawnPoints[1].rotation) as GameObject);
               // land.GetComponents<BoxCollider>()[2].enabled = true;
                break;
            case 2:  //Right 
                next.Add(Instantiate(_self.Floor, land.PathSpawnPoints[2].position, land.PathSpawnPoints[2].rotation)as GameObject);
               // land.GetComponents<BoxCollider>()[2].enabled = true;
                break;
            case 3:  //Left and Right 
                next.Add(Instantiate(_self.Floor, land.PathSpawnPoints[1].position, land.PathSpawnPoints[1].rotation) as GameObject);
                next.Add(Instantiate(_self.Floor, land.PathSpawnPoints[2].position, land.PathSpawnPoints[2].rotation) as GameObject);
               // land.GetComponents<BoxCollider>()[2].enabled = true;
                break;
        }
        
        List<Land> landList = new List<Land>();  //create a new list of Land objects

        for (int i = 0; i < next.Count; i++) // next is the elements for the switch things so thies are the new blocks
        {

            next[i].transform.SetParent(land.transform);    // take the Land Component from each elemnt in next and save it in landlist
            landList.Add(next[i].GetComponent<Land>());   //add a new point to land list from land script
            landList[landList.Count - 1].Root = land;  //set the last block

         
            if (dir != 0) //if the direction is not straight 
            {
                land.GetComponents<BoxCollider>()[2].enabled = true;  //activate the sweip collider
                landList[i]._nextStraight = true;  //add the next block straight
               

            }
            else   //if the roade is not straigt
            {
                land.GetComponents<BoxCollider>()[2].enabled = false;    //remove the collider 

            }
        }
        if (ItemManager.IsAddItem())
        {
           // print("create item (coins..");
            ItemManager.AddItem(landList[0].gameObject);

        }
        isCreating = false;  //set the bool to false
        if (landList.Count == 0) throw new System.Exception("no block created");
        return landList;         
    }

    public static void DeleteLand(Land land, Land child)  //remove a script land
    {
        child.transform.SetParent(_self.transform); //remove the block
        Destroy(land.gameObject); // delete script land
    }
    
    
}


