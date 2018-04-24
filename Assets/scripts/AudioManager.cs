using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

    //needed variabels
    public Sound[] sounds;
    //public static AudioManager instance;

    void Awake ()
    {
        //if (instance == null)
        //    instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //}
        //DontDestroyOnLoad(gameObject);
     

		foreach(Sound _sound in sounds) //connect sound script with audioSource
        {
           _sound.source= gameObject.AddComponent<AudioSource>();
            _sound.source.clip = _sound.clip;
            _sound.source.volume = _sound.volume;
            _sound.source.pitch = _sound.pitch;
            _sound.source.loop = _sound.loop;
            _sound.source.mute = _sound.mute;
        }
	}



    private void Start()  //start with playing backgroung music and sound effects
    {
      PlayMusic("Background");
        PlayEffects("Skate");
    }

   //control music and mute it and unmute it when the button in the settings is pressed 
    public void PlayMusic (string name)
    {
        Sound _sound=Array.Find(sounds, sound => sound.name == name);
        _sound.source.Play();
        if (Settings.muteMusic)
            _sound.source.mute = true;
        else
            _sound.source.mute = false;

	}

    //control soundeffects and mute it and unmute it when the button in the settings is pressed 
    public void PlayEffects(string name)
    {
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        _sound.source.Play();
        if (Settings.muteEffects)
            _sound.source.mute = true;
        else
            _sound.source.mute = false;

    }



}
