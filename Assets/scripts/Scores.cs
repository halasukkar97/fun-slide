using System.Collections;
using UnityEngine;
using TMPro;


public class Scores : MonoBehaviour {

    private EndScene endScene;
    //public GameObject NewScorePanel;

    //game score
    public TMP_Text ScoreText;
    public TMP_Text GoldText;

    public static float ScoreCount;
    public static int GoldCount;
    public static int GoldAmount;

    public static float PointPerSeconds = 5;
    public static bool incresScore =true;

    //scores                         
    public static float Highscore = 0;
    public static float MostCoins = 0;
    public static float TotalGames = 0;


    private void Start()
    {
        if (endScene == null) endScene = GameObject.FindObjectOfType<EndScene>();
        
    }



    // Update is called once per frame
    void Update () {

        if(incresScore)  //if the bool is true increase the score amount
        {
            ScoreCount += PointPerSeconds * Time.deltaTime ;
            
            if (ScoreCount > Highscore)   //if the score is more then the high score add it to the high score
                {
                Highscore = ScoreCount;

            }

            if (GoldCount > MostCoins)   //if the gold is more then the MostCoins add it to the MostCoins
            {
                MostCoins = GoldCount;

            }

        }

        //show the texts to show the score and gold amount
        ScoreText.text = "SCORE: " +Mathf.Round( ScoreCount);
        GoldText.text = "GOLD: " + GoldCount+ ",," + GoldAmount;





    }


}
