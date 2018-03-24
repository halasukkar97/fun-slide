using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class EndScene : MonoBehaviour {


    private Scores score;
    public TMP_Text ScoreText;
    public TMP_Text GoldText;



    private void Start()
    {

        if (score == null) score = GameObject.FindObjectOfType<Scores>();

        ScoreText.text = "SCORE: "+ Mathf.Round(Scores.ScoreCount);
        GoldText.text = "GOLD: " + Scores.GoldCount;



    }


    public void Restart()  //when the restart button is pressed
    {
        Scores.incresScore = true;  //start incresing the score
        Scores.TotalGames += 1;    //add more game to the total played games
        //set everything back to 0
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;

        //open the gae scene
        SceneManager.LoadScene(1);
        SaveAndLoad._SaveandLoad.Save();

    }

    public void MainMenu()   //go to main menu scene
    {
        SceneManager.LoadScene(0);
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        SaveAndLoad._SaveandLoad.Save();

    }

    public void Shop()    //go to shop scene
    {
        SceneManager.LoadScene(2);
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        SaveAndLoad._SaveandLoad.Save();

    }


}
