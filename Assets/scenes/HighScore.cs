using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour {
    private Scores score;

    private SaveAndLoad saveandload;
    public TMP_Text High_Score;
    public TMP_Text Most_Coinst;
    public TMP_Text Total_Games;
    
    // Use this for initialization
    void Start ()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (saveandload == null) saveandload = GameObject.FindObjectOfType<SaveAndLoad>();
        SaveAndLoad.Load();

    }

    //show the scores when the plyer open the score scenes
    private void Update()
    {
        //show the high scores
        High_Score.text = "" + Mathf.Round(Scores.Highscore);
        Most_Coinst.text = "" + Scores.MostCoins;
        Total_Games.text = "" + Scores.TotalGames;
    }


}
