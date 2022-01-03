using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelect : MonoBehaviour
{
    public GameObject ela;
    public GameObject valen;
    public GameObject flowerAnimation;
    public GameObject startGameWord;
    public GameObject characterSelectionPanel;
    public Animator pencilAnimator;

    public Sprite elaUnselectedImage;
    public Sprite elaSelectedImage;

    public Sprite valenSelectedImage;
    public Sprite valenUnselectedImage;

    

    Animator elaAnimator;
    Animator valenAnimator;

    Button elaCharacterDisplay;
    Button valenCharacterDisplay;

    public GameObject elaNameTag;
    public GameObject valenNameTag;
    public GameObject elaPanel;
    public GameObject valenPanel;
    GameObject buttonSounds;

    AudioSource buttonClick;
    private int isCharacterSelected;
    private void Start()
    {

        //PlayerPrefs.DeleteAll();
        elaAnimator = ela.GetComponent<Animator>();
        valenAnimator = valen.GetComponent<Animator>();


        elaCharacterDisplay = ela.GetComponent<Button>();
        valenCharacterDisplay = valen.GetComponent<Button>();

        //elaNameTag = GameObject.FindGameObjectWithTag("ElaName");
        //valenNameTag = GameObject.FindGameObjectWithTag("ValenName");

        //elaPanel = GameObject.FindGameObjectWithTag("ElaPanel");
        //valenPanel = GameObject.FindGameObjectWithTag("ValenPanel");

        //Get Audio Source Component
        buttonSounds = GameObject.FindGameObjectWithTag("ButtonSound");
        buttonClick = buttonSounds.GetComponent<AudioSource>();



        ValidateCharacterSelection();

    }

    void ValidateCharacterSelection()
    {
        if (PlayerPrefs.GetInt("characterSelected") == 1)
        {
            characterSelectionPanel.SetActive(false);
        }
        else
        {
            characterSelectionPanel.SetActive(true);

            // Check if character is selected and who
            Debug.Log("Is Character Selected? " + ((PlayerPrefs.GetInt("characterSelected") == 1) ? "Yes." : "Not Yet.") + " Who? " + ((PlayerPrefs.GetInt("isValen") == 1) ? "Valen" : "Ela"));
        }
    }
    public void StartGame()
    {
        FloorLevelPrefs floorLevelPrefs = new FloorLevelPrefs();
        WardrobeToggle wardrobeToggle = new WardrobeToggle();

        floorLevelPrefs.hardReset();
        wardrobeToggle.SaveNewPlayer();
        PlayerPrefs.SetInt( "newPlayer" , 1);
        PlayerPrefs.SetString("costumePrefs", "c0");

        StartCoroutine( Proceed() );


    }

    IEnumerator Proceed()
    {
        GameObject save = GameObject.FindGameObjectWithTag( "SaveSFX" );
        save.GetComponent<AudioSource>().Play();
        

        //Disable Character Selection
        valenNameTag.GetComponent<Button>().interactable = false;
        valenCharacterDisplay.GetComponent<Button>().interactable = false;
        elaNameTag.GetComponent<Button>().interactable = false;
        elaCharacterDisplay.GetComponent<Button>().interactable = false;
        startGameWord.GetComponent<Button>().enabled = false;


        //Trigger Animation
        pencilAnimator.SetTrigger("StartGame");

        //Character Selected turns TRUE
        PlayerPrefs.SetInt("characterSelected", 1);
        Debug.Log("Is Character Selected? " + ((PlayerPrefs.GetInt("characterSelected") == 1) ? "Yes!" : "No"));

        //Wait
        yield return new WaitForSeconds(3.25f);

        //Disable
        characterSelectionPanel.SetActive(false);

    }

    public void ToggleElaSelection()
    {
        StartCoroutine(ToggleEla());
        PlayerPrefs.SetInt("isValen", 0); //Root Variable for character selected
    }

    IEnumerator ToggleEla()
    {
        buttonClick.Play();
       
        if (elaNameTag.GetComponent<Button>().image.sprite == elaUnselectedImage)
        {
            //Enabling Valen Panel
            elaNameTag.GetComponent<Button>().image.sprite = elaSelectedImage;
            elaAnimator.enabled = true;
            elaCharacterDisplay.image.color = new Color(255, 255, 255, 255);
            elaPanel.GetComponent<Image>().color = new Color(255, 255, 255, 255);


            //Set Active True and ANimation is automatically triggered
            flowerAnimation.SetActive(true);
            startGameWord.SetActive(true);

            //Disabling Valen Panel
            valenNameTag.GetComponent<Button>().image.sprite = valenUnselectedImage;
            valenCharacterDisplay.image.color = new Color(255, 255, 255, 100);
            valenPanel.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            valenAnimator.enabled = false;
            Debug.Log((PlayerPrefs.GetInt("isValen") == 1) ? "Valen is Selected!" : "Ela is Selected!");
        }
        else
        {
            startGameWord.SetActive(false);
            elaNameTag.GetComponent<Button>().image.sprite = elaUnselectedImage;
            elaPanel.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            elaCharacterDisplay.image.color = new Color(255, 255, 255, 100);
            elaAnimator.enabled = false;


            flowerAnimation.GetComponent<Animator>().SetTrigger("Outro");
            startGameWord.GetComponent<Animator>().SetTrigger("Outro");


            yield return new WaitForSeconds(0.3f);

            flowerAnimation.SetActive(false);
            startGameWord.SetActive(false);

            
        }
    }



    public void ToggleValenSelection()
    {
        StartCoroutine(ToggleValen());
        PlayerPrefs.SetInt("isValen", 1); //Root Variable for character selected
    }

    IEnumerator ToggleValen()
    {
        buttonClick.Play();
        
        
        if (valenNameTag.GetComponent<Button>().image.sprite == valenUnselectedImage)
        {
            //Enabling Valen Panel
            valenNameTag.GetComponent<Button>().image.sprite = valenSelectedImage;
            valenAnimator.enabled = true;
            valenCharacterDisplay.image.color = new Color(255, 255, 255, 255);
            valenPanel.GetComponent<Image>().color = new Color(255, 255, 255, 255);


            //Set Active True and ANimation is automatically triggered
            flowerAnimation.SetActive(true);
            startGameWord.SetActive(true);

            //Disabling Ela Panel
            elaNameTag.GetComponent<Button>().image.sprite = elaUnselectedImage;
            elaCharacterDisplay.image.color = new Color(255, 255, 255, 100);
            elaAnimator.enabled = false;
            elaPanel.GetComponent<Image>().color = new Color(255, 255, 255, 0);

            Debug.Log((PlayerPrefs.GetInt("isValen") == 1) ? "Valen is Selected!" : "Ela is Selected!");
        }
        else
        {
            startGameWord.SetActive(false);
            valenNameTag.GetComponent<Button>().image.sprite = valenUnselectedImage;
            valenAnimator.enabled = false;
            valenCharacterDisplay.image.color = new Color(255, 255, 255, 100);
           

            valenPanel.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            flowerAnimation.GetComponent<Animator>().SetTrigger("Outro");
            startGameWord.GetComponent<Animator>().SetTrigger("Outro");


            yield return new WaitForSeconds(0.3f);

            flowerAnimation.SetActive(false);
            startGameWord.SetActive(false);
        }
    }



}
