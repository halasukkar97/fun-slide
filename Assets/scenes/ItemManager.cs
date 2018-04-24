using UnityEngine;

public class ItemManager : MonoBehaviour {

    static ItemManager _self;

    [SerializeField]
    public GameObject SpawnPositions;
    Transform Left { get { return SpawnPositions.transform.GetChild(1); } }
    Transform Center { get { return SpawnPositions.transform.GetChild(0); } }
    Transform Right { get { return SpawnPositions.transform.GetChild(2); } }

    public GameObject _SpawnPos;

    public GameObject Coin;
    public GameObject[] PowerUps;
    public GameObject[] Block;

    [SerializeField]
    [Range(0.5f, 30)]
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




    private void Awake()
    {
        _self = this;
    }

    // Use this for initialization
    void Start () {
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
       // print("make something " + _self.createSometthing);
        var SpawnPositions = _self.SpawnPositions;
        // Create the prefabs for the positions
        var _Instantiate= Instantiate(SpawnPositions, go.transform.position, go.transform.rotation);

        // set go parent to the positions we just created
        _Instantiate.transform.SetParent(go.transform);


        // Create the items (coins, power ups, blocks)
        GameObject stuff;
        stuff = ItemManager._self.Coin;
      //  print("item nummber "+_self.createSometthing+"is created");
        switch (_self.createSometthing)
        {
            case 2:
                stuff = ItemManager._self.Block[Random.Range(0, _self.Block.Length)];
                break;
            case 1:
              stuff = ItemManager._self.PowerUps[Random.Range(0,_self.PowerUps.Length)];
                break;
           
        }
        var _instantiateStuff= Instantiate(stuff, Vector3.zero, _Instantiate.transform.rotation);


        // items  parent ( one of the three positions)
        _instantiateStuff.transform.SetParent(_Instantiate.transform.GetChild(Random.Range(0,3)));
        _instantiateStuff.transform.localPosition = Vector3.zero;


        _self.createSometthing = -1;
    }
}
