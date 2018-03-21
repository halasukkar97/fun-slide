using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour {

    
    private Scores score;

    public TMP_Text High_Score;
    public TMP_Text Most_Coinst;
    public TMP_Text Total_Games;
    
    // Use this for initialization
    void Start ()
    {     if (score == null) score = GameObject.FindObjectOfType<Scores>();

    }

    private void Update()
    {
        //show the high scores
        High_Score.text = "" + PlayerPrefs.GetFloat("Highscore");
        Most_Coinst.text = "" + PlayerPrefs.GetFloat("MostCoins");
        Total_Games.text = "" + PlayerPrefs.GetFloat("TotalGames");
    }


}
