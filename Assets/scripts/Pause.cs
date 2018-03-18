using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour {

    private Scores score;
    private PlayerMovment Player;
    public Text ScoreText;
    public Text GoldText;

    public GameObject Panel;

    // Use this for initialization
    void Start () {

        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (Player == null) Player = GameObject.FindObjectOfType<PlayerMovment>();

        //hide panel
        Panel.SetActive(false);

    }

    private void Update()
    {
        ScoreText.text = "score: " + Mathf.Round(Scores.ScoreCount);
        GoldText.text = "Gold: " + Scores.GoldCount;

    }

    public void Pausepress() //if paused is pressed
    {

        //stop the game watch and timer to calculate score and distance
        Scores.incresScore = false;


        //bring the panel
        Panel.SetActive(true);

        //stop player and camera movements
        PlayerMovment.speed = 0;

    }

    public void Restart()  //when the restart button is pressed
    {
        Scores.incresScore = true;  //start incresing the score

        //set everything back to 0
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;

        //open the gae scene
        SceneManager.LoadScene(1);

        //returen speed so the player can move
        PlayerMovment.speed = 10;


    }

    public void MainMenu()   //go to main menu scene
    {
        SceneManager.LoadScene(0);
        Scores.ScoreCount = 0;


        //returen speed so the player can move
        PlayerMovment.speed = 10;
    }


    public void Resume() //if the resume button is pressed
    {
        //hide the panel
        Panel.SetActive(false);


        //resume the game watch and timer to calculate score and distance   
        Scores.incresScore = true;


        //resume player and camera movements
        PlayerMovment.speed = 10;
    }

}
