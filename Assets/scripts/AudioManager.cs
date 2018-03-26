using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
	// Use this for initialization
	void Awake () {
		foreach(Sound _sound in sounds)
        {
           _sound.source= gameObject.AddComponent<AudioSource>();
            _sound.source.clip = _sound.clip;

            _sound.source.volume = _sound.volume;
            _sound.source.pitch = _sound.pitch;
            _sound.source.loop = _sound.loop;
        }
	}
	
	// Update is called once per frame
	public void Play (string name) {
        Sound _sound=Array.Find(sounds, sound => sound.name == name);
        _sound.source.mute = false;
        _sound.source.Play();
        print("music is on ");
	}

    public void Stop(string name)
    {
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        _sound.source.Play();
        _sound.source.mute = true;
        print("music is off");
    }
}
