using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour {

    private Scores score;

    //coast values
    public static int SpeedCost ;
    public static int ShieldCost;
    public static int MagnetCost;
  
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
    public static bool ShieldComplited = false;
    public static bool MagnetComplited = false;

    //the new values of the powerups
    public TMP_Text SpeedText;
    public TMP_Text ShieldText;
    public TMP_Text MagnetText;

    public TMP_Text GoldText;
    public TMP_Text WarningText;
    

    // Use this for initialization
    void Start () {
        SpeedCost = 1000;
        ShieldCost = 1000;
        MagnetCost = 1000;

        PlayerPrefs.SetInt("SpeedCost", (SpeedCost));
        PlayerPrefs.SetInt("ShieldCost", (ShieldCost));
        PlayerPrefs.SetInt("MagnetCost", (MagnetCost));
   

        //type gold amount
        GoldText.text = "" + PlayerPrefs.GetInt("Gold");
        if (score == null) score = GameObject.FindObjectOfType<Scores>();


        //show values

        if (SpeedComplited)
        { 
            SpeedText.text = "COMPLETED";

        }
        else
        SpeedText.text = "MORE SPEED TIME FOR" + PlayerPrefs.GetInt("SpeedCost");


        if (ShieldComplited)
        { 
            ShieldText.text = "COMPLETED";

        }
        else
            ShieldText.text = "MORE SHIELD TIME FOR" + PlayerPrefs.GetInt("ShieldCost");


        if (MagnetComplited)
        { 
            MagnetText.text = "COMPLETED";

        }
        else
            MagnetText.text = "MORE MAGNET TIME FOR" + PlayerPrefs.GetInt("MagnetCost");
    }
	
	// Update is called once per frame
	void Update ()
    {
        GoldText.text = "" + PlayerPrefs.GetInt("Gold");


    }

   public void back() 
    {
        //go to main menu scene
        SceneManager.LoadScene(0);

    }

    public void BuySpeed()
    {
       if (PlayerPrefs.GetInt("Gold")> PlayerPrefs.GetInt("SpeedCost"))
        {
             
            Scores.Gold -= SpeedCost;
            //save new gold amount
            PlayerPrefs.SetInt("Gold", (Scores.Gold));
            WarningText.text = "";
            SpeedCost += 2000;
            //save the costs
            PlayerPrefs.SetInt("SpeedCost", (SpeedCost));
            SpeedShow += 2;
            //save activation time
            PlayerPrefs.SetInt("SpeedShow", (SpeedShow));

            if(SpeedCost==9000)
            {
                //disable buttton and type completed
                SpeedComplited = true;
                PlayerPrefs.SetInt("SpeedComplited", (SpeedComplited ? 1 : 0));
                SpeedText.text = "COMPLETED";
                SpeedButton.SetActive(false);
                SpeedButtonText.text="";
            }
            else
            {
                
                //type that on the screen
                SpeedText.text = "MORE SPEED TIME FOR" + PlayerPrefs.GetInt("SpeedCost");
            }
            

        }
        else
        {
            
            WarningText.text = "WARNING: NOT ENOUGH GOLD!!";
        }


    }

    public void BuyShield()
    {
        if (PlayerPrefs.GetInt("Gold") > ShieldCost)
        {
            Scores.Gold -= ShieldCost;
            //save new gold amount
            PlayerPrefs.SetInt("Gold", (Scores.Gold));
            WarningText.text = "";
            ShieldCost += 2000;
            //save the costs
            PlayerPrefs.SetInt("ShieldCost", (ShieldCost));
            ShieldShow += 2;
            //save activation time
            PlayerPrefs.SetInt("ShieldShow", (ShieldShow));
            //type that on the screen
            if (ShieldCost == 9000)
            {
                //disable buttton and type completed
                ShieldComplited = true;
                PlayerPrefs.SetInt("ShieldComplited", (ShieldComplited ? 1 : 0));
                ShieldText.text = "COMPLETED";
                ShieldButton.SetActive(false);
                ShieldButtonText.text = "";
            }
            else
            {

                ShieldText.text = "MORE SHIELD TIME FOR" + PlayerPrefs.GetInt("ShieldCost");
            }
        }
        else
        {

            WarningText.text = "WARNING: NOT ENOUGH GOLD!!";
        }

    }


    


    public void BuyMagnet()
    {
        if (PlayerPrefs.GetInt("Gold") > MagnetCost)
        {
            Scores.Gold -= MagnetCost;
            //save new gold amount
            PlayerPrefs.SetInt("Gold", (Scores.Gold));
            WarningText.text = "";
            MagnetCost += 2000;
            //save the costs
            PlayerPrefs.SetInt("MagnetCost", (MagnetCost));
            MagnetShow += 2;
            //save activation time
            PlayerPrefs.SetInt("MagnetShow", (MagnetShow));
            //type that on the screen
            if (MagnetCost == 9000)
            {
                
                //MagnetComplited = (PlayerPrefs.GetInt("MagnetComplited") != 0);

                //disable buttton and type completed
                MagnetComplited = true;
                PlayerPrefs.SetInt("MagnetComplited", (MagnetComplited ? 1 : 0));
                MagnetText.text = "COMPLETED";
                MagnetButton.SetActive(false);
                MagnetButtonText.text = "";
            }
            else
            {

                MagnetText.text = "MORE MAGNET TIME FOR" + PlayerPrefs.GetInt("MagnetCost");
            }

        }
        else
        {

            WarningText.text = "WARNING: NOT ENOUGH GOLD!!";
        }

    }
}
