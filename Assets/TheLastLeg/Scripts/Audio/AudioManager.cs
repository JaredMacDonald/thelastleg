using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
        static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }
    }

    public Sound[] sounds;

	// Use this for initialization
	void Awake ()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.looping;
        }
	}
	
	public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s != null)
        {
            s.audioSource.Play();
        }
    }
}
