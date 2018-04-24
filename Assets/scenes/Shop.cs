using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour {

    private SaveAndLoad saveandload;

    private Scores score;

    //coast values
    public static int SpeedCost = 500;
    public static int ShieldCost = 500;
    public static int MagnetCost = 500;
  
    //how long the powerup will be activated in seconds
    public static int ShieldShow = 3;
    public static int MagnetShow = 3;
    public static int SpeedShow = 4;

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
    public GameObject WarningImage;
    

    // Use this for initialization
    void Start () {
        WarningImage.SetActive(false);
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (saveandload == null) saveandload = GameObject.FindObjectOfType<SaveAndLoad>();
        SaveAndLoad.Load();
        
            //show values

            if (SpeedComplited)
            {
                SpeedText.text = "COMPLETED";

            }
            else
            SpeedText.text = "PAY " + SpeedCost + " and upgrade for more Slow PowerUp time";


        if (ShieldComplited)
            {
                ShieldText.text = "COMPLETED";

            }
            else
            ShieldText.text = "PAY " + ShieldCost + " and upgrade for more Shield PowerUp time";


        if (MagnetComplited)
            {
                MagnetText.text = "COMPLETED";

            }
            else
            MagnetText.text = "PAY " + MagnetCost + " and upgrade for more Magnet PowerUp time";


    }
	
	// Update is called once per frame
	void Update ()
    {
        GoldText.text = "" + Mathf.Round(Scores.GoldAmount);

        //tasks to buy powerUps
        if (SpeedComplited && Tasks.Task_7_completed == false)
        {
            Tasks.Task_7_completed = true;
            Scores.GoldAmount += 200;
            SaveAndLoad.Save();
        }
        if (ShieldComplited && Tasks.Task_14_completed == false)
        {
            Tasks.Task_14_completed = true;
            Scores.GoldAmount += 5000;
            SaveAndLoad.Save();
        }
        if (MagnetComplited && Tasks.Task_20_completed == false)
        {
            Tasks.Task_20_completed = true;
            Scores.GoldAmount += 1000;
            SaveAndLoad.Save();
        }
        if (MagnetComplited&& ShieldComplited && SpeedComplited && Tasks.Task_32_completed == false)
        {
            Tasks.Task_32_completed = true;
            Scores.GoldAmount += 2000;
            SaveAndLoad.Save();
        }

    }

   public void back() 
    {
       
        //go to main menu scene
        SceneManager.LoadScene(0);
        SaveAndLoad.Save();

    }

    //buy more time for the speedpowerups 
    public void BuySpeed()
    {
       if (Scores.GoldAmount >= SpeedCost )  //if i have enough money 
        {
            WarningImage.SetActive(false);
            Scores.GoldAmount -= SpeedCost;  //remove gold
             
            SpeedCost += 1500;               //add more to the cost for the next upgrade
            SpeedShow += 2;                 //add more speed show to get more of the power up
            SaveAndLoad.Save();                 //save it

            if (SpeedCost==8000)                //if i have it all
            {
                //disable buttton and type completed and save at the end
                SpeedComplited = true;
                SpeedText.text = "COMPLETED";
                SpeedButton.SetActive(false);
                SpeedButtonText.text="";
                SaveAndLoad.Save();
            }
            else
            {
                
                //type that on the screen
                SpeedText.text = "PAY " +SpeedCost+ " and upgrade for more Slow PowerUp time";
                SaveAndLoad.Save();
            }
            

        }
        else  //if there isnt enough money then type this
        {
            
         
            WarningImage.SetActive(true);
        }


    }
    public void BuyShield()
    {
        if (Scores.GoldAmount >= ShieldCost)  //if i have enough money 
        {
            WarningImage.SetActive(false);
            Scores.GoldAmount -= ShieldCost;    //remove gold
      
            ShieldCost += 1500;                  //add more to the cost for the next upgrade
            ShieldShow += 2;                     //add more shield show to get more of the power up        
            SaveAndLoad.Save();                  //save it
            //type that on the screen          
            if (ShieldCost == 8000)                  //if i have it all
            {
                //disable buttton and type completed and save at the end
                ShieldComplited = true;
                ShieldText.text = "COMPLETED";
                ShieldButton.SetActive(false);
                ShieldButtonText.text = "";
                SaveAndLoad.Save();
            }
            else
            {
                //type that on the screen
                ShieldText.text = "PAY " + ShieldCost + " and upgrade for more Shield PowerUp time";
                SaveAndLoad.Save();
            }
        }
        else //if there isnt enough money then type this
        {

           
            WarningImage.SetActive(true);
        }

    }
    public void BuyMagnet()
    {
        if (Scores.GoldAmount >= MagnetCost)
        {
            WarningImage.SetActive(false);
            Scores.GoldAmount -= MagnetCost; //remove gold
       
            MagnetCost += 1500;               //add more to the cost for the next upgrade
            MagnetShow += 2;                  //add more magnet show to get more of the power up        
            SaveAndLoad.Save();               //save it
            //type that on the screen
            if (MagnetCost == 8000)               //if i have it all
            {
                //disable buttton and type completed
                MagnetComplited = true;
                MagnetText.text = "COMPLETED";
                MagnetButton.SetActive(false);
                MagnetButtonText.text = "";
                SaveAndLoad.Save();
            }
            else
            {
                //type that on the screen
                MagnetText.text = "PAY " + MagnetCost + " and upgrade for more Magnet PowerUp time";
                SaveAndLoad.Save();
            }

        }
        else
        {
            //if there isnt enough money then type this
            
            WarningImage.SetActive(true);
        }

    }
}
