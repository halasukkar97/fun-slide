using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour {

    
    private Scores score;
    public Text High_Score;
    public Text Most_Coinst;

    public Text Total_Games;
    public Text Total_Coins;
    
    // Use this for initialization
    void Start ()
    {     if (score == null) score = GameObject.FindObjectOfType<Scores>();
        
        //show the high scores
          High_Score .text=""+PlayerPrefs.GetFloat("Highscore");
          Most_Coinst.text= ""+ PlayerPrefs.GetFloat("MostCoins");

        //show the scores of all times
        Total_Games.text= "" + PlayerPrefs.GetFloat("TotalGames");
        Total_Coins.text = ""+ PlayerPrefs.GetFloat("TotalCoins");

    }
	

    public void Back()    //go back to main menu
    {
        SceneManager.LoadScene(0);
    }
}
