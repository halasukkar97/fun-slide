using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndScene : MonoBehaviour {


    private Scores score;
    public Text ScoreText;
    public Text GoldText;



    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();


        ScoreText.text = "score: "+ Mathf.Round(Scores.ScoreCount);
        GoldText.text = "Gold: " + Scores.GoldCount;


    }


    public void Restart()  //when the restart button is pressed
    {
        Scores.incresScore = true;  //start incresing the score
        Scores.TotalGames += 1;    //add more game to the total played games

        //set everything back to 0
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;

        //open the gae scene
        SceneManager.LoadScene(1);

    }

    public void MainMenu()   //go to main menu scene
    {
        SceneManager.LoadScene(0);
        Scores.ScoreCount = 0;
    }

    public void Shop()    //go to shop scene
    {
        SceneManager.LoadScene(3);
        Scores.ScoreCount = 0;
    }


}
