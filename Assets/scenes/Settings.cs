using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour {
    
    private Scores score;
    private AudioManager audioManager;
    private SaveAndLoad saveAndLoad;

    public static bool muteMusic=false;
    public static bool muteEffects = false;
    public static bool tutorial = true;

    //buttons
    public Button BMusicOn;
    public Button BMusicOff;
    public Button BEffectsOn;
    public Button BEffectsOff;

    public TMP_Text info;

    private void Start()
    {
        info.text = "";
        if (score == null) score = GameObject.FindObjectOfType<Scores>();
        if (audioManager == null) audioManager = GameObject.FindObjectOfType<AudioManager>();
        if (saveAndLoad == null) saveAndLoad = GameObject.FindObjectOfType<SaveAndLoad>();
        SaveAndLoad.Load();

        if(muteMusic)
        {
            BMusicOn.interactable = true;
            BMusicOff.interactable = false;

        }
        else
        {
            BMusicOn.interactable = false;
            BMusicOff.interactable = true;
        }


        if(muteEffects)
        {
            BEffectsOn.interactable = true;
            BEffectsOff.interactable = false;
        }
        else
        {
            BEffectsOn.interactable = false;
            BEffectsOff.interactable = true;
        }
    }

    public void ActivateTutorials()
    {
        //activate the tutorial for the player
        tutorial = true;
        info.text = "you will see the instructions the next time you play the game";  //tell him when will he sees it 
        SaveAndLoad.Save(); //save
    }
    public void removeText()
    {
        info.text = "";  //remove the text
    }

    public void MusicOn()  //switch music on and off
    {
            muteMusic = false;

        BMusicOn.interactable = false;
        BMusicOff.interactable = true;

        SaveAndLoad.Save();
            

    }

    public void MusicOff()  //switch music on and off
    {   //music on
            muteMusic = true;

        BMusicOn.interactable = true;
        BMusicOff.interactable = false;

        SaveAndLoad.Save();
        
    }

    public void SounEffectsOn()   //switch sound effects on and off
    {
            // effects off
            muteEffects = false;

        BEffectsOn.interactable = false;
        BEffectsOff.interactable = true;

        SaveAndLoad.Save();
       
    }

    public void SounEffectsOff()   //switch sound effects on and off
    {
          //effects on
            muteEffects = true;

        BEffectsOn.interactable = true;
        BEffectsOff.interactable = false;

        SaveAndLoad.Save();

       
    }


}
