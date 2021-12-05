using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    // public static AudioManager instance;
    public SoundData[] sounds;
    
    void Awake()
    {
        // if(instance == null)
        // {
        //     instance = this;
        // }else
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        // DontDestroyOnLoad(gameObject);
        foreach (SoundData s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        PlaySound("Theme");
    }
    public void PlaySound(string soundName)
    {
        SoundData s = Array.Find(sounds, sounds => sounds.soundName == soundName);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
    public void StopSound(string soundName)
    {
        SoundData s = Array.Find(sounds, sounds => sounds.soundName == soundName);
        if(s == null)
        {
            return;
        }
        s.source.Stop();
    }
}
