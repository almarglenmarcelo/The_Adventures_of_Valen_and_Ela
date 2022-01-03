using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Toggle : MonoBehaviour
{
    //Speaker Button
    Button speakerButton;
    public Sprite speakerOnState;
    public Sprite speakerOffState;


    public GameObject[] puzzlePieces;

    public GameObject animationLoader;
    //public AudioSource backgroundMusic;

    GameObject reviewerbackgroundMusic;
    
    public GameObject lobbyMusic_;

    AudioSource reviewerVoiceOver;
    WardrobeToggle wardrobe;

    private void Start()
    {
        //Destroy
        GameObject musicObject = GameObject.FindGameObjectWithTag("GameMusic");
        Destroy(musicObject);


        // Check if character is selected and who
        Debug.Log("Is Character Selected? " + ((PlayerPrefs.GetInt("characterSelected") == 1) ? "Yes." : "Not Yet.") + " Who? " + ((PlayerPrefs.GetInt("isValen") == 1) ? "Valen" : "Ela"));

        //Get Audio Source Component
        
        

        //Activate Animation Fader
        animationLoader.SetActive(true);
    }
    
    public void ToggleSpeaker()
    {

        GameObject speaker = GameObject.FindGameObjectWithTag("SpeakerSprite");
        speakerButton = speaker.GetComponent<Button>();

        if (speakerButton.image.sprite == speakerOnState)
        {
            speakerButton.image.sprite = speakerOffState;
        }
        else
        {
            speakerButton.image.sprite = speakerOnState;
        }
    }


    public void ShowThisOverlay(GameObject overviewOverlay)
    {
        GameObject buttonSound = GameObject.FindGameObjectWithTag("ButtonSound");
        buttonSound.GetComponent<AudioSource>().Play();
        if (overviewOverlay.tag == "LESSONSCONTENTS")
        {
            reviewerbackgroundMusic = GameObject.FindGameObjectWithTag("ReviewerSFX");
            lobbyMusic_.GetComponent<AudioSource>().mute = true;
            reviewerbackgroundMusic.GetComponent<AudioSource>().mute = false;
        }
        overviewOverlay.SetActive(true);

    }

    public void HideThisOverlay(GameObject overviewOverlay)
    {
        GameObject buttonSound = GameObject.FindGameObjectWithTag("ButtonSound");
        buttonSound.GetComponent<AudioSource>().Play();
        if (overviewOverlay.tag == "LESSONSCONTENTS")
        {
            reviewerbackgroundMusic = GameObject.FindGameObjectWithTag("ReviewerSFX");
            reviewerbackgroundMusic.GetComponent<AudioSource>().mute = true;
            lobbyMusic_.GetComponent<AudioSource>().mute = false;
        }

        overviewOverlay.SetActive(false);

    }
}

