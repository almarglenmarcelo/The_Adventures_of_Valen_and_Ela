using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonsPageControl : MonoBehaviour
{
    
    GameObject[] lessonPage;
    GameObject reviewerbackgroundMusic;
    public GameObject animationLoader;
    public GameObject back;
    public GameObject hintOV;
    public GameObject reviewer;
    public GameObject speakerButton;

    int counterNext = 1;
    int counterPrev = 0;

    AudioSource reviewerVoiceOver;

    public Sprite speakerOnState;
    public Sprite speakerOffState;

    private void Awake()
    {
        // Get the Reviewer Background Music
        reviewerbackgroundMusic = GameObject.FindGameObjectWithTag("ReviewerSFX");
        reviewerbackgroundMusic.GetComponent<AudioSource>().Play();

       
        lessonPage = GameObject.FindGameObjectsWithTag("LessonPage");
        animationLoader.SetActive(true);


        Debug.Log("LessonsPage Length: " + lessonPage.Length);

        foreach (GameObject c in lessonPage)
        {
            c.SetActive(false);
        }


        
        lessonPage[counterPrev].SetActive(true); // counterPrev : 0

        Debug.Log("Next:" + counterNext);
        Debug.Log("Prev:" + counterPrev);
    }


    private void Update()
    {
        DetermineSpeakerButtonAppearance();


        //Below is the code for toggling VoiceOver Sounds
        GameObject voiceOver = GameObject.FindGameObjectWithTag("VoiceOver");
        reviewerVoiceOver = voiceOver.GetComponent<AudioSource>();
        ToggleReviewerSound();
        //End
    }

    public void ToggleReviewerSound()
    {

       // GameObject speaker = GameObject.FindGameObjectWithTag("SpeakerSprite");

        if (speakerButton.gameObject.GetComponent<Button>().image.sprite == speakerOnState)
        {
            reviewerVoiceOver.mute = false;
        }
        else
        {
            speakerButton.gameObject.GetComponent<Button>().image.sprite = speakerOffState;
            reviewerVoiceOver.mute = true;
        }

    }
    public void DetermineSpeakerButtonAppearance()
    {
        //Continue code; this checks if voiceover is active
        GameObject voiceOver = GameObject.FindGameObjectWithTag("VoiceOver");
       
        if (counterPrev == 0)
        {
            speakerButton.SetActive(false);
        }
        else
        {
            speakerButton.SetActive(true);
        }
    }


    public void ShowNextPage()
    {
        GameObject sound = GameObject.FindGameObjectWithTag("ButtonSound");
        sound.GetComponent<AudioSource>().Play();

        lessonPage[counterPrev].SetActive(false);
        lessonPage[counterNext].SetActive(true);

        counterNext += 1;
        counterPrev += 1;

        Debug.Log("Next:" + counterNext);
        Debug.Log("Prev:" + counterPrev);
    }

    public void ShowPreviousPage()
    {
        GameObject sound = GameObject.FindGameObjectWithTag("ButtonSound");
        sound.GetComponent<AudioSource>().Play();
        lessonPage[counterPrev - 1].SetActive(true);
        lessonPage[counterNext - 1].SetActive(false);

        counterNext -= 1; 
        counterPrev -= 1;

        if(counterPrev < 0)
        {
            counterNext = 1;
            counterPrev = 0;
        }

        Debug.Log("Next:" + counterNext);
        Debug.Log("Prev:" + counterPrev);
    }


    public void hideReviewer()
    {
        //counter = 0;
        reviewer.SetActive(false);
        hintOV.SetActive(false);
        //Debug.Log(counter);
    }



}
