using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour {

    //   public GameObject[] tilePrefabs;
    //   private Transform PlayerTransform;

    //   private float spawnZ = 0.0f;
    //   private float spawnX = 0.0f;


    //   private float tilelength = 4f;
    //   private float safeZone = 15.0f;
    //   private int amnTilesOnScreen = 7;
    //   private int lastPrefabIndex = 0;


    //   private List<GameObject> activeTiles;
    //// Use this for initialization
    //private void Start ()
    //   {
    //       activeTiles = new List<GameObject>();
    //       PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    //       for(int i=0; i< amnTilesOnScreen;i++)
    //       {
    //           if( i < 2)
    //           {
    //               SpawnTileZ(0);
    //               SpawnTileX(0);

    //           }
    //           else
    //           {
    //               SpawnTileZ();
    //               SpawnTileX();

    //           } 
    //       }
    //   }

    //// Update is called once per frame
    //private void Update ()
    //   {
    //	if(PlayerTransform.position.z - safeZone  > (spawnZ - amnTilesOnScreen * tilelength))
    //       {
    //           SpawnTileZ();
    //           DeleteTileZ();
    //       }
    //       else if(PlayerTransform.position.x - safeZone > (spawnX - amnTilesOnScreen * tilelength))
    //       {
    //           SpawnTileX();
    //           DeleteTileX();
    //       }


    //   }

    //   private void SpawnTileZ(int prefabIndex = -1)
    //   {
    //       GameObject go;
    //       if(prefabIndex == -1)
    //       {
    //           go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
    //       }
    //      else
    //       {
    //           go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
    //       }
    //       go.transform.SetParent(transform);
    //       go.transform.position = Vector3.forward * spawnZ;
    //       spawnZ += tilelength;
    //       activeTiles.Add(go);

    //   }
    //   private void DeleteTileZ()
    //   {
    //       Destroy(activeTiles[0]);
    //       activeTiles.RemoveAt(0);
    //   }


    //   private void SpawnTileX(int prefabIndex = -1)
    //   {
    //       GameObject go;
    //       if (prefabIndex == -1)
    //       {
    //           go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
    //       }
    //       else
    //       {
    //           go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
    //       }
    //       go.transform.SetParent(transform);
    //       go.transform.position = Vector3.right * spawnX;
    //       spawnX += tilelength;
    //       activeTiles.Add(go);

    //   }
    //   private void DeleteTileX()
    //   {
    //       Destroy(activeTiles[0]);
    //       activeTiles.RemoveAt(0);
    //   }



    //   private int RandomPrefabIndex()
    //   {
    //       if (tilePrefabs.Length <= 1)
    //           return 0;

    //       int randomIndex = lastPrefabIndex;
    //       while(randomIndex == lastPrefabIndex)
    //       {
    //           randomIndex = Random.Range(0, tilePrefabs.Length);
    //       }

    //       lastPrefabIndex = randomIndex;
    //       return randomIndex;

    //   }

    public GameObject Floor;
    public float FloorLength = 4.0f;
    public int xSize = 12;
    public int zSize = 12;

    private Vector3 initialPos;
    private GameObject FloorHolder;
     void Start()
    {
        Create_floors();


    }

    void Create_floors()
    {
        FloorHolder = new GameObject();
        FloorHolder.name = "Maze";
        initialPos = new Vector3((-xSize/2)+FloorLength/2,0,(-zSize/2)+FloorLength/2);
        Vector3 myPos = initialPos;
        GameObject TempFloor;

        //for x Axis
        for(int i=0;i<zSize;i++)
        {
            for(int j=0; j<=xSize;j++)
            {
                myPos = new Vector3(initialPos.x+(j*FloorLength)-FloorLength/2,0.0f,initialPos.z+(i*FloorLength)-FloorLength/2);
                TempFloor= Instantiate(Floor, myPos, Quaternion.identity) as GameObject;
                TempFloor.transform.parent = FloorHolder.transform;
            }
        }


        ////for Z Axis
        //for (int i = 0; i <= zSize; i++)
        //{
        //    for (int j = 0; j < xSize; j++)
        //    {
        //        myPos = new Vector3(initialPos.x + (j * FloorLength) , 0.0f, initialPos.z + (i * FloorLength) - FloorLength);
        //        TempFloor=Instantiate(Floor, myPos, Quaternion.Euler(0.0f,90.0f,0.0f)) as GameObject;
       //        TempFloor.transform.parent = FloorHolder.transform;
        //    }
        //}
    }

    private void Update()
    {
        
    }
}

