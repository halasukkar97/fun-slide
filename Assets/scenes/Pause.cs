using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour {

    private Scores score;
    private PlayerMovment Player;
    private Settings settings;
    private SaveAndLoad saveAndLoad;
    
    public TMP_Text ScoreText;
    public TMP_Text GoldText;

    public GameObject PausePanel;
    public GameObject tutorialPanel;
    public GameObject tutorialPanel2;

    // Use this for initialization
    void Start () {
        SaveAndLoad.Load();

        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (Player == null) Player = GameObject.FindObjectOfType<PlayerMovment>();
        if (settings == null) settings = GameObject.FindObjectOfType<Settings>();
        if (saveAndLoad == null) saveAndLoad = GameObject.FindObjectOfType<SaveAndLoad>();

        if (Settings.tutorial==true)
        {
            //stop the game watch and timer to calculate score and distance
            Scores.incresScore = false;

            //bring the panel
            tutorialPanel.SetActive(true);

            //stop player and camera movements
            PlayerMovment.Pause = true;
            
            //set the bool back to false
            Settings.tutorial = false;

        }

        //hide panel
        PausePanel.SetActive(false);

    }

    private void Update()
    {
        ScoreText.text = ": " + Mathf.Round(Scores.ScoreCount);
        GoldText.text = ": " + Scores.GoldCount;

    }

    public void Pausepress() //if paused is pressed
    {

        //stop the game watch and timer to calculate score and distance
        Scores.incresScore = false;

        //bring the panel
        PausePanel.SetActive(true);

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
        PlayerMovment.speed = 15;
        PlayerMovment.timer = 0;

        //open the gae scene
        SceneManager.LoadScene(1);

    }

    public void startAfterTutorial()
    {
        //hide the panel
        tutorialPanel2.SetActive(false);

        //resume the game watch and timer to calculate score and distance   
        Scores.incresScore = true;

        //resume player and camera movements
        PlayerMovment.Pause = false;

    }



    public void MainMenu()   //go to main menu scene
    {
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;

        //returen speed so the player can move
        PlayerMovment.speed = 15;
        PlayerMovment.Pause = false;
        PlayerMovment.timer = 0;

        SceneManager.LoadScene(0);

    }


    public void Resume() //if the resume button is pressed
    {
        //hide the panel
        PausePanel.SetActive(false);
        
        //resume the game watch and timer to calculate score and distance   
        Scores.incresScore = true;

        //resume player and camera movements
        PlayerMovment.Pause = false;
      
    }

}
