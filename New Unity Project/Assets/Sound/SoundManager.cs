using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject SoundOffButton;
    public GameObject SoundOnButton;
    void Start()
    {
        if (PlayerPrefs.GetString("sound") == "off")
        {
            AudioListener.pause = true;
            if(SoundOffButton == null)
            {
                return;
            }else
            {
                SoundOffButton.SetActive(true);
                SoundOnButton.SetActive(false);
            }
        }else{
            AudioListener.pause = false;
            if(SoundOnButton == null)
            {
                return;
            }else
            {
                SoundOffButton.SetActive(false);
                SoundOnButton.SetActive(true);
            }
        }
    }
    public void StopSound()
    {
        PlayerPrefs.SetString("sound", "off");
        AudioListener.pause = true;
    }
    public void PlaySound()
    {
        PlayerPrefs.SetString("sound", "on");
        AudioListener.pause = false;
    }
}
