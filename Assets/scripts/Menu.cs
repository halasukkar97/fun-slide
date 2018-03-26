using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {


    private SaveAndLoad saveandload;

    private Scores score;

    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (saveandload == null) saveandload = GameObject.FindObjectOfType<SaveAndLoad>();
        SaveAndLoad.Load();

    }

    // main menu buttons
    public void Play()   //start playing game
    {
       
            Scores.incresScore = true;   //start increasing score
            Scores.TotalGames += 1;     //count how many times the user playes
        SaveAndLoad.Save();
        SceneManager.LoadScene(1);
          



    }


    public void back()
    {
        //go to main menu scene
        SceneManager.LoadScene(0);
        SaveAndLoad.Save();

    }

    public void Shop()    //open shop scene
    {
        SceneManager.LoadScene(2);
    }

  
    public void Quit()      //close the game
    {
       
        Application.Quit();
    }
    


}
