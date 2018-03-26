using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour {

    private Scores score;
    private AudioManager audioManager;

    private void Start()
    {
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (audioManager == null) audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    public void Music()  //switch music on and off
    {
        bool onOfSwitchMusic = gameObject.GetComponent<Toggle>().isOn;
        if(onOfSwitchMusic)
        {
            //music on
            FindObjectOfType<AudioManager>().Play("Background");
        }
        else
        {
            // music off
            FindObjectOfType<AudioManager>().Stop("Background");
            
        }
    }

    public void SounEffects()   //switch sound effects on and off
    {
        bool onOfSwitchEffects = gameObject.GetComponent<Toggle>().isOn;
        if (onOfSwitchEffects)
        {
            //effects on
        }
        else
        {
            // effects off
        }
    }


}
