using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControls : MonoBehaviour
{
    
    public Slider backgroundMusic;
    
    public AudioSource backgroundSong;
   
    float volumeMaster;

    private void Awake()
    {
        
        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            backgroundMusic.value = PlayerPrefs.GetFloat("musicVolume");
            backgroundSong.volume = PlayerPrefs.GetFloat("musicVolume");

            Debug.Log("First Time!");
            // backgroundSong.volume = PlayerPrefs.GetFloat("musicVolume");
            

        }
        else
        {
            backgroundMusic.value = PlayerPrefs.GetFloat("musicVolume");

        }
    }


    void Update()
    {
        PlayerPrefs.SetFloat("musicVolume", backgroundMusic.value);
        backgroundSong.volume = PlayerPrefs.GetFloat("musicVolume");

    }
    public void RemoveFirstTime()
    {
        PlayerPrefs.SetInt("isFirstTime", 1);
    }
}
