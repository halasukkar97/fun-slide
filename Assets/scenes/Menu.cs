using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private SaveAndLoad saveandload;

    public GameObject Loadingscreen;
    public Slider slider;
    public TMP_Text progressText;

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

    public void Tasks()    //open tasks scene
    {
        SceneManager.LoadScene(4);
    }


    public void Quit()      //close the game
    {
       
        Application.Quit();
    }


    //start the game
    public void PlayGame()
    {
        // transform.gameObject.GetComponent<Image>().enabled = false;
        //loadingPanel.setactive(true);
        Scores.incresScore = true;
        Scores.TotalGames += 1;
        SaveAndLoad.Save();
        StartCoroutine(loadAsync(1));
    }
    

    //start the game after the loading bar is 100%
    IEnumerator loadAsync(int number)
    {
        Loadingscreen.SetActive(true);
        AsyncOperation sync = SceneManager.LoadSceneAsync(number);
        
        while(!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress / 0.9f);
            slider.value = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            yield return null;
        }
        Loadingscreen.SetActive(false);


    }

}
