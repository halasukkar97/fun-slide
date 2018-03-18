﻿using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private Scores score;

    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();

    }

    // main menu buttons
    public void Play()   //start playing game
    {
        SceneManager.LoadScene(1);
        Scores.incresScore = true;   //start increasing score
        Scores.TotalGames += 1;     //count how many times the user playes
    }

    public void Settings()   //open setting scene
    {
        SceneManager.LoadScene(2);
    }

    public void Shop()    //open shop scene
    {
        SceneManager.LoadScene(3);
    }

    public void Score()    //open score scene
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()      //close the game
    {
        Application.Quit();
    }
    
    // Back to main menu
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

}
