using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Death : MonoBehaviour {

    private Scores score;
    private PlayerMovment Player;

    private void Start()
    {
        if (Player == null) Player = GameObject.FindObjectOfType<PlayerMovment>();
        if (score == null) score = GameObject.FindObjectOfType<Scores>();

    }
    void OnTriggerEnter(Collider col)   //when the player enters the death colider
    {
        if (col.tag.Contains("Player"))
        {
            Scores.incresScore = false;   // stop increasing the score
            OnDeath();
            PlayerMovment.speed = 10;
            SceneManager.LoadScene(3);   //change scene
          
        }
    }

   
    public void OnDeath()
    {
        //save all the nummbers when player dies
        PlayerPrefs.SetFloat("Highscore", Mathf.Round(Scores.Highscore));
        PlayerPrefs.SetFloat("MostCoins", Mathf.Round(Scores.MostCoins));
        PlayerPrefs.SetFloat("TotalGames", Mathf.Round(Scores.TotalGames));
        PlayerPrefs.SetInt("Gold", (Scores.Gold));


    }
}
