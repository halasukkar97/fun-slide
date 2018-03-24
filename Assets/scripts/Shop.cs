using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour {

    private Scores score;

    //coast values
    public static int SpeedCost = 1000;
    public static int ShieldCost = 1000;
    public static int MagnetCost = 1000;
  
    //how long the powerup will be activated in seconds
    public static int SpeedShow = 2;
    public static int ShieldShow = 2;
    public static int MagnetShow = 2;

    //disable buttons
    public GameObject SpeedButton;
    public GameObject ShieldButton;
    public GameObject MagnetButton;

    //disabple Buttons texts
    public TMP_Text SpeedButtonText;
    public TMP_Text ShieldButtonText;
    public TMP_Text MagnetButtonText;

    //to check if the user got all the values
    public static bool SpeedComplited = false;
    public static bool  ShieldComplited = false;
    public static bool  MagnetComplited = false;

    //the new values of the powerups
    public TMP_Text SpeedText;
    public TMP_Text ShieldText;
    public TMP_Text MagnetText;

    public TMP_Text GoldText;
    public TMP_Text WarningText;
    

    // Use this for initialization
    void Start () {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        SaveAndLoad._SaveandLoad.Load();
        
            //show values

            if (SpeedComplited)
            {
                SpeedText.text = "COMPLETED";

            }
            else
                SpeedText.text = "MORE SPEED TIME FOR " + SpeedCost;


            if (ShieldComplited)
            {
                ShieldText.text = "COMPLETED";

            }
            else
                ShieldText.text = "MORE SHIELD TIME FOR " +ShieldCost;


            if (MagnetComplited)
            {
                MagnetText.text = "COMPLETED";

            }
            else
                MagnetText.text = "MORE MAGNET TIME FOR " + MagnetCost;

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GoldText.text = "" + Mathf.Round(Scores.GoldAmount);

    }

   public void back() 
    {
        //go to main menu scene
        SceneManager.LoadScene(0);
        SaveAndLoad._SaveandLoad.Save();

    }

    public void BuySpeed()
    {
       if (Scores.GoldAmount >= SpeedCost )
        {
             
            Scores.GoldAmount -= SpeedCost;
             WarningText.text = "";
            SpeedCost += 2000;
            SpeedShow += 2;
            SaveAndLoad._SaveandLoad.Save();
            if (SpeedCost==9000)
            {
                //disable buttton and type completed
                SpeedComplited = true;
                SpeedText.text = "COMPLETED";
                SpeedButton.SetActive(false);
                SpeedButtonText.text="";
                SaveAndLoad._SaveandLoad.Save();
            }
            else
            {
                
                //type that on the screen
                SpeedText.text = "MORE SPEED TIME FOR " +SpeedCost;
                SaveAndLoad._SaveandLoad.Save();
            }
            

        }
        else
        {
            
            WarningText.text = "WARNING: NOT ENOUGH GOLD!!";
        }


    }

    public void BuyShield()
    {
        if (Scores.GoldAmount >= ShieldCost)
        {
            Scores.GoldAmount -= ShieldCost;
           
            WarningText.text = "";
            ShieldCost += 2000;
            
            ShieldShow += 2;
            SaveAndLoad._SaveandLoad.Save();
            //type that on the screen
            if (ShieldCost == 9000)
            {
                //disable buttton and type completed
                ShieldComplited = true;
               
                ShieldText.text = "COMPLETED";
                ShieldButton.SetActive(false);
                ShieldButtonText.text = "";
                SaveAndLoad._SaveandLoad.Save();
            }
            else
            {

                ShieldText.text = "MORE SHIELD TIME FOR " + ShieldCost;
                SaveAndLoad._SaveandLoad.Save();
            }
        }
        else
        {

            WarningText.text = "WARNING: NOT ENOUGH GOLD!!";
        }

    }


    


    public void BuyMagnet()
    {
        if (Scores.GoldAmount >= MagnetCost)
        {
            Scores.GoldAmount -= MagnetCost;
            
            WarningText.text = "";
            MagnetCost += 2000;
          
            MagnetShow += 2;
            SaveAndLoad._SaveandLoad.Save();
            //type that on the screen
            if (MagnetCost == 9000)
            {
                //disable buttton and type completed
                MagnetComplited = true;
                
                MagnetText.text = "COMPLETED";
                MagnetButton.SetActive(false);
                MagnetButtonText.text = "";
                SaveAndLoad._SaveandLoad.Save();
            }
            else
            {

                MagnetText.text = "MORE MAGNET TIME FOR " + MagnetCost;
                SaveAndLoad._SaveandLoad.Save();
            }

        }
        else
        {

            WarningText.text = "WARNING: NOT ENOUGH GOLD!!";
        }

    }
}
