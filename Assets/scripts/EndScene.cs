using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class EndScene : MonoBehaviour {


    private Scores score;
    private SaveAndLoad saveandload;
    public TMP_Text ScoreText;
    public TMP_Text GoldText;



    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (saveandload == null) saveandload = GameObject.FindObjectOfType<SaveAndLoad>();

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
        SaveAndLoad.Save();
        //open the gae scene
        SceneManager.LoadScene(1);
   

    }

    public void MainMenu()   //go to main menu scene
    {
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        SaveAndLoad.Save();
        SceneManager.LoadScene(0);
      

    }

    public void Shop()    //go to shop scene
    {
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        SaveAndLoad.Save();
        SceneManager.LoadScene(2);
     

    }


}
