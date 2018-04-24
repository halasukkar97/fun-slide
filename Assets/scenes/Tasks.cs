using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tasks : MonoBehaviour {

    private SaveAndLoad saveandload;


    //tasks boolens to check if completed
    #region the booleans to check if the task is completed or not
    public static bool Task_1_completed = false;
    public static bool Task_2_completed = false;
    public static bool Task_3_completed = false;
    public static bool Task_4_completed = false;
    public static bool Task_5_completed = false;
    public static bool Task_6_completed = false;
    public static bool Task_7_completed = false;
    public static bool Task_8_completed = false;
    public static bool Task_9_completed = false;
    public static bool Task_10_completed = false;
    public static bool Task_11_completed = false;
    public static bool Task_12_completed = false;
    public static bool Task_13_completed = false;
    public static bool Task_14_completed = false;
    public static bool Task_15_completed = false;
    public static bool Task_16_completed = false;
    public static bool Task_17_completed = false;
    public static bool Task_18_completed = false;
    public static bool Task_19_completed = false;
    public static bool Task_20_completed = false;
    public static bool Task_21_completed = false;
    public static bool Task_22_completed = false;
    public static bool Task_23_completed = false;
    public static bool Task_24_completed = false;
    public static bool Task_25_completed = false;
    public static bool Task_26_completed = false;
    public static bool Task_27_completed = false;
    public static bool Task_28_completed = false;
    public static bool Task_29_completed = false;
    public static bool Task_30_completed = false;
    public static bool Task_31_completed = false;
    public static bool Task_32_completed = false;
    public static bool Task_33_completed = false;
    public static bool Task_34_completed = false;
    public static bool Task_35_completed = false;
#endregion

    //result text

    #region the text that will tell me if the task is completed or not
    public TMP_Text Task_1;
    public TMP_Text Task_2;
    public TMP_Text Task_3;
    public TMP_Text Task_4;
    public TMP_Text Task_5;
    public TMP_Text Task_6;
    public TMP_Text Task_7;
    public TMP_Text Task_8;
    public TMP_Text Task_9;
    public TMP_Text Task_10;
    public TMP_Text Task_11;
    public TMP_Text Task_12;
    public TMP_Text Task_13;
    public TMP_Text Task_14;
    public TMP_Text Task_15;
    public TMP_Text Task_16;
    public TMP_Text Task_17;
    public TMP_Text Task_18;
    public TMP_Text Task_19;
    public TMP_Text Task_20;
    public TMP_Text Task_21;
    public TMP_Text Task_22;
    public TMP_Text Task_23;
    public TMP_Text Task_24;
    public TMP_Text Task_25;
    public TMP_Text Task_26;
    public TMP_Text Task_27;
    public TMP_Text Task_28;
    public TMP_Text Task_29;
    public TMP_Text Task_30;
    public TMP_Text Task_31;
    public TMP_Text Task_32;
    public TMP_Text Task_33;
    public TMP_Text Task_34;
    public TMP_Text Task_35;
#endregion
    private void Start()
    {

        if (saveandload == null) saveandload = GameObject.FindObjectOfType<SaveAndLoad>();
        SaveAndLoad.Load();

            #region type how much or completed if the bool is true
        if (Task_1_completed)
            Task_1.text = "COMPLETED";
        else
            Task_1.text = "200 GOLD";

        if (Task_2_completed)
            Task_2.text = "COMPLETED";
        else
            Task_2.text = "200 GOLD";


        if (Task_3_completed)
            Task_3.text = "COMPLETED";
        else
            Task_3.text = "200 GOLD";


        if (Task_4_completed)
            Task_4.text = "COMPLETED";
        else
            Task_4.text = "200 GOLD";


        if (Task_5_completed)
            Task_5.text = "COMPLETED";
        else
            Task_5.text = "200 GOLD";


        if (Task_6_completed)
            Task_6.text = "COMPLETED";
        else
            Task_6.text = "200 GOLD";


        if (Task_7_completed)
            Task_7.text = "COMPLETED";
        else
            Task_7.text = "200 GOLD";


        if (Task_8_completed)
            Task_8.text = "COMPLETED";
        else
            Task_8.text = "200 GOLD";


        if (Task_9_completed)
            Task_9.text = "COMPLETED";
        else
            Task_9.text = "200 GOLD";


        if (Task_10_completed)
            Task_10.text = "COMPLETED";
        else
            Task_10.text = "200 GOLD";

        if (Task_11_completed)
            Task_11.text = "COMPLETED";
        else
            Task_11.text = "500 GOLD";

        if (Task_12_completed)
            Task_12.text = "COMPLETED";
        else
            Task_12.text = "500 GOLD";

        if (Task_13_completed)
            Task_13.text = "COMPLETED";
        else
            Task_13.text = "500 GOLD";

        if (Task_14_completed)
            Task_14.text = "COMPLETED";
        else
            Task_14.text = "500 GOLD";

        if (Task_15_completed)
            Task_15.text = "COMPLETED";
        else
            Task_15.text = "500 GOLD";

        if (Task_16_completed)
            Task_16.text = "COMPLETED";
        else
            Task_16.text = "500 GOLD";

        if (Task_17_completed)
            Task_17.text = "COMPLETED";
        else
            Task_17.text = "500 GOLD";

        if (Task_18_completed)
            Task_18.text = "COMPLETED";
        else
            Task_18.text = "500 GOLD";

        if (Task_19_completed)
            Task_19.text = "COMPLETED";
        else
            Task_19.text = "500 GOLD";

        if (Task_20_completed)
            Task_20.text = "COMPLETED";
        else
            Task_20.text = "1000 GOLD";

        if (Task_21_completed)
            Task_21.text = "COMPLETED";
        else
            Task_21.text = "1000 GOLD";

        if (Task_22_completed)
            Task_22.text = "COMPLETED";
        else
            Task_22.text = "1000 GOLD";

        if (Task_23_completed)
            Task_23.text = "COMPLETED";
        else
            Task_23.text = "1000 GOLD";

        if (Task_24_completed)
            Task_24.text = "COMPLETED";
        else
            Task_24.text = "1000 GOLD";

        if (Task_25_completed)
            Task_25.text = "COMPLETED";
        else
            Task_25.text = "1000 GOLD";

        if (Task_26_completed)
            Task_26.text = "COMPLETED";
        else
            Task_26.text = "1000 GOLD";

        if (Task_27_completed)
            Task_27.text = "COMPLETED";
        else
            Task_27.text = "1000 GOLD";

        if (Task_28_completed)
            Task_28.text = "COMPLETED";
        else
            Task_28.text = "1000 GOLD";

        if (Task_29_completed)
            Task_29.text = "COMPLETED";
        else
            Task_29.text = "1000 GOLD";

        if (Task_30_completed)
            Task_30.text = "COMPLETED";
        else
            Task_30.text = "1000 GOLD";

        if (Task_31_completed)
            Task_31.text = "COMPLETED";
        else
            Task_31.text = "2000 GOLD";

        if (Task_32_completed)
            Task_32.text = "COMPLETED";
        else
            Task_32.text = "2000 GOLD";

        if (Task_33_completed)
            Task_33.text = "COMPLETED";
        else
            Task_33.text = "2000 GOLD";

        if (Task_34_completed)
            Task_34.text = "COMPLETED";
        else
            Task_34.text = "2000 GOLD";

        if (Task_35_completed)
            Task_35.text = "COMPLETED";
        else
            Task_35.text = "2000 GOLD";

#endregion


    }

    public void back()
    {
        //go to main menu scene
        SceneManager.LoadScene(0);
        SaveAndLoad.Save();

    }

    // Use this for Task_35initialization
    private void Update()
    {

        if (Task_33_completed)
            Task_33.text = "COMPLETED";
        else
            Task_33.text = "2000 GOLD";

        //one of the tasks is if all tasks are all done
        if (Task_1_completed && Task_2_completed && Task_3_completed && Task_3_completed && Task_4_completed && Task_5_completed
            && Task_6_completed && Task_7_completed && Task_8_completed && Task_9_completed && Task_10_completed && Task_11_completed
            && Task_12_completed && Task_13_completed && Task_14_completed && Task_15_completed && Task_16_completed && Task_17_completed
            && Task_18_completed && Task_19_completed && Task_20_completed && Task_21_completed && Task_22_completed && Task_23_completed
            && Task_24_completed && Task_25_completed && Task_26_completed && Task_27_completed && Task_28_completed && Task_29_completed
            && Task_30_completed && Task_31_completed && Task_32_completed && Task_34_completed && Task_35_completed && Task_33_completed == false)
        {
            Task_33_completed = true;
            Scores.GoldAmount += 2000;
            SaveAndLoad.Save();
        }
        
    }
	
	
}
