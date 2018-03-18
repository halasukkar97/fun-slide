using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Death : MonoBehaviour {

    private Scores score;


    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();

    }
    void OnTriggerEnter(Collider col)   //when the player enters the death colider
    {
        if (col.tag.Contains("Player"))
        {
            Scores.incresScore = false;   // stop increasing the score
            OnDeath();
            SceneManager.LoadScene(5);   //change scene
          
        }
    }

   
    public void OnDeath()
    {
        //save all the nummbers when player dies
        PlayerPrefs.SetFloat("Highscore", Mathf.Round(Scores.ScoreCount));
        PlayerPrefs.SetFloat("MostCoins", Mathf.Round(Scores.MostCoins));
        PlayerPrefs.SetFloat("TotalGames", Mathf.Round(Scores.TotalGames));
        PlayerPrefs.SetFloat("TotalCoins", Mathf.Round(Scores.TotalCoins));
    }
}
