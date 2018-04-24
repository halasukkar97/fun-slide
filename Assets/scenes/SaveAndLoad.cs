using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour {

    //public  SaveAndLoad _SaveandLoad;
    private Scores score;
    private Shop shop;
    private Tasks tasks;
    private Settings settings;

    private void Awake()
    {
     
        Load();

    }

    public void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (shop == null) shop = GameObject.FindObjectOfType<Shop>();
        if (tasks == null) tasks = GameObject.FindObjectOfType<Tasks>();
        if (settings == null) settings = GameObject.FindObjectOfType<Settings>();
    }


    //save in the class we made data and create a binary file
    public static void Save()
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

        //tasks bool
        data.Task_1_completed  = Tasks.Task_1_completed ;
        data.Task_2_completed  = Tasks.Task_2_completed ;
        data.Task_3_completed  = Tasks.Task_3_completed ;
        data.Task_4_completed  = Tasks.Task_4_completed ;
        data.Task_5_completed  = Tasks.Task_5_completed ;
        data.Task_6_completed  = Tasks.Task_6_completed ;
        data.Task_7_completed  = Tasks.Task_7_completed ;
        data.Task_8_completed  = Tasks.Task_8_completed ;
        data.Task_9_completed  = Tasks.Task_9_completed ;
        data.Task_10_completed = Tasks.Task_10_completed;
        data.Task_11_completed = Tasks.Task_11_completed;
        data.Task_12_completed = Tasks.Task_12_completed;
        data.Task_13_completed = Tasks.Task_13_completed;
        data.Task_14_completed = Tasks.Task_14_completed;
        data.Task_15_completed = Tasks.Task_15_completed;
        data.Task_16_completed = Tasks.Task_16_completed;
        data.Task_17_completed = Tasks.Task_17_completed;
        data.Task_18_completed = Tasks.Task_18_completed;
        data.Task_19_completed = Tasks.Task_19_completed;
        data.Task_20_completed = Tasks.Task_20_completed;
        data.Task_21_completed = Tasks.Task_21_completed;
        data.Task_22_completed = Tasks.Task_22_completed;
        data.Task_23_completed = Tasks.Task_23_completed;
        data.Task_24_completed = Tasks.Task_24_completed;
        data.Task_25_completed = Tasks.Task_25_completed;
        data.Task_26_completed = Tasks.Task_26_completed;
        data.Task_27_completed = Tasks.Task_27_completed;
        data.Task_28_completed = Tasks.Task_28_completed;
        data.Task_29_completed = Tasks.Task_29_completed;
        data.Task_30_completed = Tasks.Task_30_completed;
        data.Task_31_completed = Tasks.Task_31_completed;
        data.Task_32_completed = Tasks.Task_32_completed;
        data.Task_33_completed = Tasks.Task_33_completed;
        data.Task_34_completed = Tasks.Task_34_completed;
        data.Task_35_completed = Tasks.Task_35_completed;

        //mute
        data.muteMusic = Settings.muteMusic;
        data.muteEffects = Settings.muteEffects;

        //activate tutorials
        data.tutorial= Settings.tutorial;

        bf.Serialize(file, data);
        file.Close();


    }


    //public void delete()
    //{
    //    File.Delete(Application.persistentDataPath + "/PlayerData.dat");

    //}


    //load the info we saved in the data class
    public static void Load()
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

            //tasks bool
            Tasks.Task_1_completed = data.Task_1_completed;
            Tasks.Task_2_completed = data.Task_2_completed;
            Tasks.Task_3_completed = data.Task_3_completed;
            Tasks.Task_4_completed = data.Task_4_completed; 
            Tasks.Task_5_completed = data.Task_5_completed;
            Tasks.Task_6_completed= data.Task_6_completed;
            Tasks.Task_7_completed = data.Task_7_completed;
            Tasks.Task_8_completed = data.Task_8_completed;
            Tasks.Task_9_completed = data.Task_9_completed;
            Tasks.Task_10_completed = data.Task_10_completed;
            Tasks.Task_11_completed = data.Task_11_completed;
            Tasks.Task_12_completed = data.Task_12_completed;
            Tasks.Task_13_completed = data.Task_13_completed;
            Tasks.Task_14_completed = data.Task_14_completed;
            Tasks.Task_15_completed = data.Task_15_completed;
            Tasks.Task_16_completed = data.Task_16_completed;
            Tasks.Task_17_completed = data.Task_17_completed;
            Tasks.Task_18_completed = data.Task_18_completed;
            Tasks.Task_19_completed = data.Task_19_completed;
            Tasks.Task_20_completed = data.Task_20_completed;
            Tasks.Task_21_completed = data.Task_21_completed;
            Tasks.Task_22_completed = data.Task_22_completed;
            Tasks.Task_23_completed = data.Task_23_completed;
            Tasks.Task_24_completed = data.Task_24_completed;
            Tasks.Task_25_completed = data.Task_25_completed;
            Tasks.Task_26_completed = data.Task_26_completed;
            Tasks.Task_27_completed = data.Task_27_completed;
            Tasks.Task_28_completed = data.Task_28_completed;
            Tasks.Task_29_completed = data.Task_29_completed;
            Tasks.Task_30_completed = data.Task_30_completed;
            Tasks.Task_31_completed = data.Task_31_completed;
            Tasks.Task_32_completed = data.Task_32_completed;
            Tasks.Task_33_completed = data.Task_33_completed;
            Tasks.Task_34_completed = data.Task_34_completed;
            Tasks.Task_35_completed= data.Task_35_completed ;

            //settings
            Settings.muteEffects = data.muteEffects;
            Settings.muteMusic = data.muteMusic;

            //activate tutorials
            Settings.tutorial = data.tutorial;

            file.Close();


        }
    }
}


//the class that will save the info in
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

    //tasks
    public bool Task_1_completed ;
    public bool Task_2_completed ;
    public bool Task_3_completed ; 
    public bool Task_4_completed ;
    public bool Task_5_completed ;
    public bool Task_6_completed ;
    public bool Task_7_completed ;
    public bool Task_8_completed ;
    public bool Task_9_completed ;
    public bool Task_10_completed;
    public bool Task_11_completed;
    public bool Task_12_completed;
    public bool Task_13_completed;
    public bool Task_14_completed;
    public bool Task_15_completed;
    public bool Task_16_completed;
    public bool Task_17_completed;
    public bool Task_18_completed;
    public bool Task_19_completed;
    public bool Task_20_completed;
    public bool Task_21_completed;
    public bool Task_22_completed;
    public bool Task_23_completed;
    public bool Task_24_completed;
    public bool Task_25_completed;
    public bool Task_26_completed;
    public bool Task_27_completed;
    public bool Task_28_completed;
    public bool Task_29_completed;
    public bool Task_30_completed;
    public bool Task_31_completed;
    public bool Task_32_completed;
    public bool Task_33_completed;
    public bool Task_34_completed;
    public bool Task_35_completed;

    //mute
    public bool muteEffects;
    public bool muteMusic;

    //tutorial activation
    public bool tutorial;
}
