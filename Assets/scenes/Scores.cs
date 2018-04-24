using UnityEngine;
using TMPro;


public class Scores : MonoBehaviour {

    private EndScene endScene;
    private Tasks tasks;
    private SaveAndLoad saveAndLoad;
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

    public static bool newHighscore = false;

    private void Start()
    {
        if (endScene == null) endScene = GameObject.FindObjectOfType<EndScene>();
        if (saveAndLoad == null) saveAndLoad = GameObject.FindObjectOfType<SaveAndLoad>();
        if (tasks == null) tasks = GameObject.FindObjectOfType<Tasks>();

        //tasks checlk the total games amount
        if(TotalGames==25 && Tasks.Task_4_completed == false)
        {
            Tasks.Task_4_completed = true;
            GoldAmount += 200;
            SaveAndLoad.Save();

        }
        if (TotalGames == 35 && Tasks.Task_6_completed == false)
        {
            Tasks.Task_6_completed = true;
            GoldAmount += 200;
            SaveAndLoad.Save();

        }
        if (TotalGames == 50 && Tasks.Task_11_completed == false)
        {
            Tasks.Task_11_completed = true;
            GoldAmount +=500;
            SaveAndLoad.Save();

        }
        if (TotalGames == 100 && Tasks.Task_18_completed == false)
        {
            Tasks.Task_18_completed = true;
            GoldAmount += 500;
            SaveAndLoad.Save();

        }
        if (TotalGames == 150 && Tasks.Task_24_completed==false)
        {
            Tasks.Task_24_completed = true;
            GoldAmount += 1000;
            SaveAndLoad.Save();

        }
        if (TotalGames == 180 && Tasks.Task_26_completed == false)
        {
            Tasks.Task_26_completed = true;
            GoldAmount += 1000;
            SaveAndLoad.Save();

        }
        if (TotalGames == 200 && Tasks.Task_30_completed == false)
        {
            Tasks.Task_30_completed = true;
            GoldAmount += 1000;
            SaveAndLoad.Save();

        }

    }



    // Update is called once per frame
    void Update () {

        if(incresScore)  //if the bool is true increase the score amount
        {
            ScoreCount += PointPerSeconds * Time.deltaTime ;
            
            //high scores
            if (ScoreCount > Highscore)   //if the score is more then the high score add it to the high score
            {
                Highscore = ScoreCount;
                newHighscore = true;
            }

            if (GoldCount > MostCoins)   //if the gold is more then the MostCoins add it to the MostCoins
            {
                MostCoins = GoldCount;

            }

            //tasks to do for more gold
            #region tasks
            //gold amount tasks
            if (GoldCount > 500 && Tasks.Task_1_completed == false)
            {
                Tasks.Task_1_completed = true;
                GoldAmount += 200;
                SaveAndLoad.Save();
            }   
            if (GoldCount > 1000 && Tasks.Task_8_completed == false)
            {
                Tasks.Task_8_completed = true;
                GoldAmount += 200;
                SaveAndLoad.Save();
            }
            if (GoldCount > 1500 && Tasks.Task_13_completed == false)
            {
                Tasks.Task_13_completed = true;
                GoldAmount += 500;
                SaveAndLoad.Save();
            }
            if (GoldCount > 2000 && Tasks.Task_15_completed == false)
            {
                Tasks.Task_15_completed = true;
                GoldAmount += 500;
                SaveAndLoad.Save();
            }
            if (GoldCount > 4000 && Tasks.Task_21_completed == false)
            {
                Tasks.Task_21_completed = true;
                GoldAmount += 1000;
                SaveAndLoad.Save();
            }
            if (GoldCount >6000 && Tasks.Task_27_completed == false)
            {
                Tasks.Task_27_completed = true;
                GoldAmount += 1000;
                SaveAndLoad.Save();
            }
            if (GoldCount > 10000 && Tasks.Task_34_completed == false)
            {
                Tasks.Task_34_completed = true;
                GoldAmount += 2000;
                SaveAndLoad.Save();
            }

            //score amount tasks
            if (ScoreCount > 2000 && Tasks.Task_2_completed == false)
            {
                Tasks.Task_2_completed = true;
                GoldAmount += 200;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 4000 && Tasks.Task_9_completed == false)
            {
                Tasks.Task_9_completed = true;
                GoldAmount += 200;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 8000 && Tasks.Task_16_completed == false)
            {
                Tasks.Task_16_completed = true;
                GoldAmount += 500;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 16000 && Tasks.Task_22_completed == false)
            {
                Tasks.Task_22_completed = true;
                GoldAmount += 1000;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 32000 && Tasks.Task_28_completed == false)
            {
                Tasks.Task_28_completed = true;
                GoldAmount += 1000;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 64000 && Tasks.Task_35_completed == false)
            {
                Tasks.Task_35_completed = true;
                GoldAmount += 2000;
                SaveAndLoad.Save();
            }

            // 0 gold and score tasks
            if (ScoreCount > 500 && GoldCount==0 && Tasks.Task_3_completed == false)
            {
                Tasks.Task_3_completed = true;
                GoldAmount += 200;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 1000 && GoldCount == 0 && Tasks.Task_10_completed == false)
            {
                Tasks.Task_10_completed = true;
                GoldAmount += 200;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 2000 && GoldCount == 0 && Tasks.Task_17_completed == false)
            {
                Tasks.Task_17_completed = true;
                GoldAmount += 500;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 3000 && GoldCount == 0 && Tasks.Task_23_completed == false)
            {
                Tasks.Task_23_completed = true;
                GoldAmount += 1000;
                SaveAndLoad.Save();
            }
            if (ScoreCount > 4000 && GoldCount == 0 && Tasks.Task_29_completed == false)
            {
                Tasks.Task_29_completed = true;
                GoldAmount += 1000;
                SaveAndLoad.Save();
            }
            #endregion



        }

        //show the texts to show the score and gold amount
        ScoreText.text = Mathf.Round( ScoreCount)+"";
        GoldText.text = " " + GoldCount;





    }


}
