using UnityEngine.SceneManagement;
using UnityEngine;

public class Death : MonoBehaviour {

    [SerializeField]
    private Scores score;
    private PlayerMovment Player;

    //start with checking other scripts
    private void Start()
    {
        if (Player == null) Player = GameObject.FindObjectOfType<PlayerMovment>();
        if (score == null) score = GameObject.FindObjectOfType<Scores>();

    }


    void OnTriggerEnter(Collider col)   //when the player enters the death colider
    {
        if (col.tag.Contains("Player"))
        {
            Scores.GoldAmount += Scores.GoldCount;
            Scores.incresScore = false;   // stop increasing the score
            PlayerMovment.speed = 15;
            SceneManager.LoadScene(3);   //change scene

          
        }
    }

   
}
