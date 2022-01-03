using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSounds : MonoBehaviour
{
    public Slider backgroundMusicControl;
    GameObject gameMusic;
    AudioSource backgroundMusic;


    public GameObject wrongAnswerSfx;
    public GameObject correctAnswerSfx;

    private void Start()
    {
        gameMusic = GameObject.FindGameObjectWithTag("GameMusic");
        backgroundMusic = gameMusic.GetComponent<AudioSource>();
    }

    private void Update()
    {
        backgroundMusic.volume = backgroundMusicControl.value;
    }



}
