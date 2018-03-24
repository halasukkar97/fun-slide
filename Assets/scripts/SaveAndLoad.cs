using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour {

    public static SaveAndLoad _SaveandLoad;
    private Scores score;
    private Shop shop;

    private void Awake()
    {
        //delete();
        if (_SaveandLoad==null)
        {
            DontDestroyOnLoad(gameObject);
            _SaveandLoad = this;
            Load();
        }
        else if(_SaveandLoad!=this)
        {
            Destroy(gameObject);
            Load();
        }


        
    }

    public void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (shop == null) shop = GameObject.FindObjectOfType<Shop>();
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PlayerData data = new PlayerData();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        
        //scores
        data.Highscore = Scores.Highscore;
        data.MostCoins = Scores.MostCoins;
        data.TotalGames = Scores.TotalGames;

        //gold amount
        data.GoldAmount = Scores.GoldAmount;

        //coast values
        data.SpeedCost = Shop.SpeedCost;
        data.ShieldCost = Shop.ShieldCost;
        data.MagnetCost = Shop.MagnetCost;

        //how long the powerup will be activated in seconds
        data.SpeedShow = Shop.SpeedShow;
        data.ShieldShow = Shop.ShieldShow;
        data.MagnetShow = Shop.MagnetShow;

        //to check if the user got all the values
        data.SpeedComplited = Shop.SpeedComplited;
        data.ShieldComplited = Shop.ShieldComplited;
        data.MagnetComplited = Shop.MagnetComplited;

        bf.Serialize(file, data);
        file.Close();


    }
    //public void delete()
    //{
    //    File.Delete(Application.persistentDataPath + "/PlayerData.dat");
    //    
    //}
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            //scores
             Scores.Highscore = data.Highscore;
             Scores.MostCoins = data.MostCoins;
             Scores.TotalGames = data.TotalGames;

            //gold amount
            Scores.GoldAmount = data.GoldAmount;

            //coast values
            Shop.SpeedCost = data.SpeedCost;
            Shop.ShieldCost = data.ShieldCost;
            Shop.MagnetCost = data.MagnetCost;

            //how long the powerup will be activated in seconds
             Shop.SpeedShow = data.SpeedShow;
             Shop.ShieldShow = data.ShieldShow;
             Shop.MagnetShow = data.MagnetShow;

            //to check if the user got all the values
             Shop.SpeedComplited = data.SpeedComplited;
             Shop.ShieldComplited = data.ShieldComplited;
             Shop.MagnetComplited = data.MagnetComplited;

            file.Close();


        }
    }
}


[Serializable]
public class PlayerData
    {

    //scores                         
    public  float Highscore;
    public  float MostCoins;
    public  float TotalGames;

    //gold amount
    public  int GoldAmount;


    //coast values
    public  int SpeedCost;
    public  int ShieldCost;
    public  int MagnetCost;

    //how long the powerup will be activated in seconds
    public  int SpeedShow;
    public  int ShieldShow;
    public  int MagnetShow;


    //to check if the user got all the values
    public  bool SpeedComplited;
    public  bool ShieldComplited;
    public  bool MagnetComplited;
}
