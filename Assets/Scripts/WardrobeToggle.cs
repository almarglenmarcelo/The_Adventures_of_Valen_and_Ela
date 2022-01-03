using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeToggle : MonoBehaviour
{
    //Bind the character display
    public Image characterDisplay;

    //Create a GameObject variable for CostumeButtons
    GameObject[] costumes;

    //Call GameObjects For Tags
    public GameObject saveSfx;

    //Bind the Save Notice Panel
    public GameObject savePanel;
    public GameObject passwordToggle;

    public GameObject confirmSave;

    //Binds the character preview
    public Sprite[] costumeDefault;
    public Sprite[] costume1;
    public Sprite[] costume2;
    public Sprite[] costume3;
    public Sprite[] costume4;
    public Sprite[] costume5;
    public Sprite[] costume6;
    public Sprite[] costume7;

    
   
    private int isValen;                                                 //Check Selected Character

    //turns true if completing a stage : ENDPOINT *To be changed by XML endpoint
    //1 = true; 0 = false
    private int costumeSetDefault = 0;
    private int costumeSet1 = 0;
    private int costumeSet2 = 0;
    private int costumeSet3 = 0;
    private int costumeSet4 = 0;
    private int costumeSet5 = 0;
    private int costumeSet6 = 0;
    private int costumeSet7 = 0;

    //Wardrobe Preview only
    private int lockedPreview = 2;                                      //3rd element in the script Array
    private int unlockedPreview = 3;                                    //4th element in the script Array

    
    private string previewSet = "!";                                          //Temporary Memory

    //Saved Equipped Set : ENDPOINT *SAVED MEMORY*
    private string costumeSet;

    public string costumeEquipped;
    private void Start()
    {


        if (PlayerPrefs.GetInt("newPlayer") == 1)                       //This will be changed to 0 if tutorial is completed and 
        {
            costumeEquipped = "c0";
            SavePlayer();

            //PlayerPrefs.SetString("costumePrefs", "c0");
        }                                                               //*TO BE REVISED FOR XML
                
        PlayerData data = PlayerSaveSystem.LoadPlayer();
        costumeSet = data.costumeEquipped;
        //PlayerPrefs.GetString("costumePrefs");                         //Check for savepoint


        //False isNew variable 
        if (costumeEquipped == "c0")                                        //*TO BE REVISED FOR XML
        {
            PlayerPrefs.SetInt("newPlayer", 0);
        }


        isValen = PlayerPrefs.GetInt("isValen");                        //Get Character choice

        costumes = GameObject.FindGameObjectsWithTag("CostumeButton");  //Get Objects with Tag
        passwordToggle.GetComponent<AudioSource>().Play();              //password Toggle sfx

        FetchUnlockedCostume();                                         //Fetch Unlocked 
        SetCostume(data.costumeEquipped);                               //Set a costume

        string preview = previewSet;

        //Hide Save Button
        if (previewSet == preview)
        {
            confirmSave.SetActive(false);
        }
    }


    public void SavePlayer()
    {
            PlayerSaveSystem.SavePlayer(this);
    }



    public void LoadPlayer()
    {
        PlayerData data = PlayerSaveSystem.LoadPlayer();
        
        
    }
    public void SaveWardrobe()
    {
        StartCoroutine(SaveCostume());                                  //StartCoroutine to use IEnumerator methods (always pair)
    }
    
    public void SaveNewPlayer()
    {
        costumeEquipped = "c0";
        SavePlayer();
    }
    IEnumerator SaveCostume()
    {
        
        costumeEquipped = previewSet;
        costumeSet = previewSet;                                        //Set the preview to saved costume set
        previewSet = "";
        costumeEquipped = costumeSet;
        PlayerPrefs.SetString("costumePrefs", costumeSet);
        SavePlayer();


        /*PlayerPrefs.SetString("costumePrefs", previewSet);              //Set Endpoint here for costume set : This line is for sample working flow
        costumeSet = previewSet;                                        //Set the preview to saved costume set
        previewSet = "";                                                //concatenate preview variable 
        PlayerPrefs.SetString("costumePrefs", costumeSet);*/

        
        savePanel.SetActive(true);                                      //Save Notice
        yield return new WaitForSeconds(1f);                            //Wait for 1 second 
        saveSfx.GetComponent<AudioSource>().Play();
        savePanel.SetActive(false);                                     //Then execute this line after 1second

        confirmSave.SetActive(false);

        PlayerData data = PlayerSaveSystem.LoadPlayer();
        Debug.Log("Costume Saved! " + data.costumeEquipped + " is the costume set!");
    }

    private void FetchUnlockedCostume()
    {
        // This code checks for unlocked costumes
        
        costumeSet1 = PlayerPrefs.GetInt("costume1");
        costumeSet2 = PlayerPrefs.GetInt("costume2");
        costumeSet3 = PlayerPrefs.GetInt("costume3");
        costumeSet4 = PlayerPrefs.GetInt("costume4");
        costumeSet5 = PlayerPrefs.GetInt("costume5");
        costumeSet6 = PlayerPrefs.GetInt("costume6");
        costumeSet7 = PlayerPrefs.GetInt("costume7");

        //FloorData XML load
        FloorData0 data0 = SaveSystem0.LoadPlayer0();
        FloorData1 data1 = SaveSystem1.LoadPlayer1();
        FloorData2 data2 = SaveSystem2.LoadPlayer2();
        FloorData3 data3 = SaveSystem3.LoadPlayer3();
        FloorData4 data4 = SaveSystem4.LoadPlayer4();
        FloorData5 data5 = SaveSystem5.LoadPlayer5();
        FloorData6 data6 = SaveSystem6.LoadPlayer6();
        FloorData7 data7 = SaveSystem7.LoadPlayer7();
        



        //0 = false; 
        if (data0.Costume0 == false)
        {
            costumes[1].GetComponent<Button>().image.sprite = costume1[lockedPreview];
            costumes[1].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[1].GetComponent<Button>().image.sprite = costume1[unlockedPreview];
        }

        if (data1.Costume1 == false)
        {
            costumes[2].GetComponent<Button>().image.sprite = costume2[lockedPreview];
            costumes[2].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[2].GetComponent<Button>().image.sprite = costume2[unlockedPreview];
        }

        if (data2.Costume2 == false)
        {
            costumes[3].GetComponent<Button>().image.sprite = costume3[lockedPreview];
            costumes[3].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[3].GetComponent<Button>().image.sprite = costume3[unlockedPreview];
        }

        if (data3.Costume3 == false)
        {
            costumes[4].GetComponent<Button>().image.sprite = costume4[lockedPreview];
            costumes[4].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[4].GetComponent<Button>().image.sprite = costume4[unlockedPreview];
        }

        if (data4.Costume4 == false)
        {
            costumes[5].GetComponent<Button>().image.sprite = costume5[lockedPreview];
            costumes[5].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[5].GetComponent<Button>().image.sprite = costume5[unlockedPreview];
        }


        if (data5.Costume5 == false)
        {
            costumes[6].GetComponent<Button>().image.sprite = costume6[lockedPreview];
            costumes[6].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[6].GetComponent<Button>().image.sprite = costume6[unlockedPreview];
        }


        if (data6.Costume6 == false)
        {
            costumes[7].GetComponent<Button>().image.sprite = costume7[lockedPreview];
            costumes[7].GetComponent<Button>().image.raycastTarget = false;
        }
        else
        {
            costumes[7].GetComponent<Button>().image.sprite = costume7[unlockedPreview];
        }

    }

    //Endpoints for Set Costume
    private void SetCostume(string costumeEquipped) 
    {
        switch (costumeEquipped)
        {
            case "c0":
                EquipDefaultCostume();
                break;
            case "c1":
                EquipCostume1();
                break;
            case "c2":
                EquipCostume2();
                break;
            case "c3":
                EquipCostume3();
                break;
            case "c4":
                EquipCostume4();
                break;
            case "c5":
                EquipCostume5();
                break;
            case "c6":
                EquipCostume6();
                break;
            case "c7":
                EquipCostume7();
                break;
        }
    }
    
   
    void EquipToggle()
    {
        passwordToggle.GetComponent<AudioSource>().Play();
    }

    public void EquipDefaultCostume()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c0";
        if (isValen == 1)
        {
            characterDisplay.sprite = costumeDefault[0];
        }
        else
        {
            characterDisplay.sprite = costumeDefault[1];
        }
    }

    private void MakeSaveButtonAppear()
    {
        confirmSave.SetActive(true);
    }
    public void EquipCostume1()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c1";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume1[0];
            
        }
        else
        {
            characterDisplay.sprite = costume1[1];
        }
    }


    public void EquipCostume2()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c2";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume2[0];
        }
        else
        {
            characterDisplay.sprite = costume2[1];
        }
    }
    public void EquipCostume3()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c3";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume3[0];
            

        }
        else
        {
            characterDisplay.sprite = costume3[1];
        }
    }
    public void EquipCostume4()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c4";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume4[0];
            
        }
        else
        {
            characterDisplay.sprite = costume4[1];
        }
    }

    public void EquipCostume5()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c5";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume5[0];
        }
        else
        {
            characterDisplay.sprite = costume5[1];
        }
    }
    public void EquipCostume6()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c6";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume6[0];
           
        }
        else
        {
            characterDisplay.sprite = costume6[1];
        }
    }
    public void EquipCostume7()
    {
        EquipToggle();
        MakeSaveButtonAppear();
        previewSet = "c7";
        if (isValen == 1)
        {
            characterDisplay.sprite = costume7[0];
            previewSet = "c7";
        }
        else
        {
            characterDisplay.sprite = costume7[1];
        }
    }

}
