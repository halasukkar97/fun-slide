using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour {

    private Scores score;
    private PlayerMovment Player;


    public TMP_Text ScoreText;
    public TMP_Text GoldText;

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
        PlayerMovment.Pause = true;
       

    }

    public void Restart()  //when the restart button is pressed
    {
        Scores.incresScore = true;  //start incresing the score

        //set everything back to 0
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
       
        //returen speed so the player can move
        PlayerMovment.Pause = false;
        PlayerMovment.speed = 10;
        PlayerMovment.timer = 0;

        //open the gae scene
        SceneManager.LoadScene(1);

    }

    public void MainMenu()   //go to main menu scene
    {
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;

        //returen speed so the player can move
        PlayerMovment.speed = 10;
        PlayerMovment.Pause = false;
        PlayerMovment.timer = 0;

        SceneManager.LoadScene(0);

    }


    public void Resume() //if the resume button is pressed
    {
        //hide the panel
        Panel.SetActive(false);
        
        //resume the game watch and timer to calculate score and distance   
        Scores.incresScore = true;

        //resume player and camera movements
        PlayerMovment.Pause = false;
      
    }

}
