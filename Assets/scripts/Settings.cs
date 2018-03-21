using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour {

    private Scores score;

    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
    }
    private void Music()  //switch music on and off
    {
        bool onOfSwitchMusic = gameObject.GetComponent<Toggle>().isOn;
        if(onOfSwitchMusic)
        {
            //music on
        }
        else
        {
            // music off
        }
    }

    private void SounEffects()   //switch sound effects on and off
    {
        bool onOfSwitchEffects = gameObject.GetComponent<Toggle>().isOn;
        if (onOfSwitchEffects)
        {
            //effects on
        }
        else
        {
            // effects off
        }
    }


    // reset all the game scores 
    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.DeleteKey("MostCoins");
        PlayerPrefs.DeleteKey("TotalGames");

        Scores.Highscore=0;
       Scores.MostCoins=0;
       Scores.TotalGames = 0;

    }
}
