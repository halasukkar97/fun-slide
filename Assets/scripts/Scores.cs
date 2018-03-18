using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    private EndScene endScene;
  

    //game score
    public Text ScoreText;
    public Text GoldText;

    public static float ScoreCount;
    public static float GoldCount;

    public static float PointPerSeconds = 5;
    public static bool incresScore =true;

    //scores
    public static float Highscore  =0;
    public static float MostCoins = 0;

    public static float TotalGames = 0;
    public static float TotalCoins = 0;

    private void Start()
    {
        if (endScene == null) endScene = GameObject.FindObjectOfType<EndScene>();
    }



    // Update is called once per frame
    void Update () {

        if(incresScore)  //if the bool is true increase the score amount
        { 
            ScoreCount += PointPerSeconds * Time.deltaTime ;
        
            if(ScoreCount > Highscore)   //if the score is more then the high score add it to the high score
                {
                Highscore = ScoreCount;
                }

        }

        //show the texts to show the score and gold amount
        ScoreText.text = "score: " +Mathf.Round( ScoreCount);
        GoldText.text = "Gold: " + GoldCount;





    }


}
