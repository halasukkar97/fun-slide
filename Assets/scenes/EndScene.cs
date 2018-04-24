using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour {


    private Scores score;
    private SaveAndLoad saveandload;
    public TMP_Text ScoreText;
    public TMP_Text GoldText;
    public TMP_Text NewHighscoe;
    public GameObject Loadingscreen;
    public Slider slider;
    public TMP_Text progressText;

    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (saveandload == null) saveandload = GameObject.FindObjectOfType<SaveAndLoad>();

        ScoreText.text = ": "+ Mathf.Round(Scores.ScoreCount);  // show the score
        GoldText.text = ": " + Scores.GoldCount;   //show the gold value
        //if there is a highscore show it
        if (Scores.newHighscore)
        {
            NewHighscoe.text = "!!NEW HIGHSCORE!!";
            Scores.newHighscore = false;
        }
        else
        {
            NewHighscoe.text = "";
        }
            

        //tasks with no gold and scores
        if (Scores.ScoreCount > 500 && Scores.GoldCount == 0 && Tasks.Task_5_completed == false)
        {
            Tasks.Task_5_completed = true;
            Scores.GoldAmount += 200;
            SaveAndLoad.Save();
        }
        if (Scores.ScoreCount > 1000 && Scores.GoldCount == 0 && Tasks.Task_12_completed == false)
        {
            Tasks.Task_12_completed = true;
            Scores.GoldAmount += 500;
            SaveAndLoad.Save();
        }
        if (Scores.ScoreCount > 2000 && Scores.GoldCount == 0 && Tasks.Task_19_completed == false)
        {
            Tasks.Task_19_completed = true;
            Scores.GoldAmount += 500;
            SaveAndLoad.Save();
        }
        if (Scores.ScoreCount > 3000 && Scores.GoldCount == 0 && Tasks.Task_25_completed == false)
        {
            Tasks.Task_25_completed = true;
            Scores.GoldAmount += 1000;
            SaveAndLoad.Save();
        }
        if (Scores.ScoreCount > 5000 && Scores.GoldCount == 0 && Tasks.Task_31_completed == false)
        {
            Tasks.Task_31_completed = true;
            Scores.GoldAmount += 2000;
            SaveAndLoad.Save();
        }

    }
    

    public void Restart()
    {
        Scores.incresScore = true;  //start incresing the score
        Scores.TotalGames += 1;    //add more game to the total played games
        //set everything back to 0
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        PlayerMovment.speed = 15;
        SaveAndLoad.Save();
        //open the game scene
        StartCoroutine(loadAsync(1));
    }

    IEnumerator loadAsync(int number)  //Start with loading bar and then start the scene
    {
        Loadingscreen.SetActive(true);
        AsyncOperation sync = SceneManager.LoadSceneAsync(number);

        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 0.9f);
            slider.value = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            yield return null;
        }
        Loadingscreen.SetActive(false);


    }

    public void MainMenu()   //go to main menu scene
    {
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        PlayerMovment.speed = 15;
        SaveAndLoad.Save();
        SceneManager.LoadScene(0);
      

    }

    public void Shop()    //go to shop scene
    {
        Scores.ScoreCount = 0;
        Scores.GoldCount = 0;
        PlayerMovment.timer = 0;
        PlayerMovment.speed = 15;
        SaveAndLoad.Save();
        SceneManager.LoadScene(2);
     

    }


}
