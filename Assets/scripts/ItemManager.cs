using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    static ItemManager _self;

    public static GameObject SpawnPositions;
    Transform Left { get { return SpawnPositions.transform.GetChild(1); } }
    Transform Center { get { return SpawnPositions.transform.GetChild(0); } }
    Transform Right { get { return SpawnPositions.transform.GetChild(2); } }

    public GameObject _SpawnPos;

    public GameObject Coin;
    public GameObject[] PowerUps;
    public  GameObject Block;

    [SerializeField]
    [Range(1, 30)]
    float CoinFrequency;

    [SerializeField]
    [Range(1, 60)]
    float PowerUpFrequency;

    [SerializeField]
    [Range(1, 30)]
    float BlockFrequency;


    float nextCoin;
    float nextBlock;
    float nextPowerUp;

    int createSometthing = -1;
    // Use this for initialization
    void Start () {
        _self = this;
        nextBlock = BlockFrequency;
	}
	
	// Update is called once per frame
	void Update () {
        nextBlock -= Time.deltaTime;

        if(nextBlock <= 0)
        {
            nextBlock = BlockFrequency;
            createSometthing = 2; // let 2 be a block xP
        }

        nextCoin -= Time.deltaTime;

        if (nextCoin <= 0)
        {
            nextCoin = CoinFrequency;
            createSometthing =0; // let 0 be a coin xP
        }


        nextPowerUp -= Time.deltaTime;

        if (nextPowerUp <= 0)
        {
            nextPowerUp = PowerUpFrequency;
            createSometthing = 1; // let 1 be a PowerUp xP
        }

    }

    public static bool IsAddItem()
    {
        return _self.createSometthing != -1;
    }


    /// <summary>
    /// add items to game gold, blocks, Power ups
    /// </summary>
    /// <param name="go">go is the last new block</param>
    public static void AddItem(GameObject go)
    {
        // Create the prefabs for the positions
        Instantiate(SpawnPositions, SpawnPositions.transform.position, SpawnPositions.transform.rotation);

        // set go parent to the positions we just created
        SpawnPositions.transform.SetParent(go.transform);


        // Create the items (coins, power ups, blocks)
        GameObject stuff;
        stuff = ItemManager._self.Coin;
        switch (_self.createSometthing)
        {
            case 1:
                stuff = ItemManager._self.Block;
                break;
            case 2:
              stuff = ItemManager._self.PowerUps[2];
                break;
           
        }
        Instantiate(stuff, stuff.transform.position, stuff.transform.rotation);


        // items  parent ( one of the three positions)
        stuff.transform.SetParent(SpawnPositions.transform.GetChild(Random.Range(0,2)));



        _self.createSometthing = -1;
    }
}
