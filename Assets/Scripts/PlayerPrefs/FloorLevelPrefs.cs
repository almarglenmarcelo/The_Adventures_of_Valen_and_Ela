using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloorLevelPrefs : MonoBehaviour
{

    public Button[] level2Floor; //Floor 1
    public Button[] level3Floor; //Floor 2
    public Button[] level4Floor; //Floor 3
    public Button[] level5Floor; //Floor 4
    public Button[] level6Floor; //Floor 5
    public Button[] level7Floor; //Floor 6
    public Button[] level8Floor; //Floor Last Floor

    public TMPro.TextMeshProUGUI Classroomtxt;
    public TMPro.TextMeshProUGUI Librarytxt;
    public TMPro.TextMeshProUGUI Canteentxt;
    public TMPro.TextMeshProUGUI Labtxt;
    public TMPro.TextMeshProUGUI Lockertxt;
    public TMPro.TextMeshProUGUI Gymtxt;
    public TMPro.TextMeshProUGUI Rooftoptxt;



    public Sprite unlockState;
    public Sprite lockState;



    private void Start()
    {

        //SetLevelPrefs("level2", "unlockLevel2");
        //SetLevelPrefs("level3", "unlockLevel3");
        //SetLevelPrefs("level4", "unlockLevel4");
        //SetLevelPrefs("level5", "unlockLevel5");
        //SetLevelPrefs("level6", "unlockLevel6");
        //SetLevelPrefs("level7", "unlockLevel7");
        //SetLevelPrefs("level8", "unlockLevel8");






        if (GetLevelPrefs("NewGame") != "2")
        {
            Number number = new Number();
            WardrobeToggle wardrobeToggle = new WardrobeToggle();
            wardrobeToggle.SaveNewPlayer();
            number.NewPlayerReset();
            hardReset();

            floorsUnlocked();
        }
        else
        {

            
            floorsUnlocked();


        }

    }

    public void hardReset()
    {
        QuizManager0 quizManager0 = new QuizManager0();
        QuizManager1 quizManager1 = new QuizManager1();
        QuizManager2 quizManager2 = new QuizManager2();
        QuizManager3 quizManager3 = new QuizManager3();
        QuizManager4 quizManager4 = new QuizManager4();
        QuizManager5 quizManager5 = new QuizManager5();
        QuizManager6 quizManager6 = new QuizManager6();
        QuizManager7 quizManager7 = new QuizManager7();

        SetLevelPrefs("NewGame", "2");
        quizManager0.SavePlayerReset0();
        quizManager1.SavePlayerReset1();
        quizManager2.SavePlayerReset2();
        quizManager3.SavePlayerReset3();
        quizManager4.SavePlayerReset4();
        quizManager5.SavePlayerReset5();
        quizManager6.SavePlayerReset6();
        quizManager7.SavePlayerReset7();
    }


    private void floorsUnlocked()
    {
        //FloorData XML load
        FloorData0 data0 = SaveSystem0.LoadPlayer0();
        FloorData1 data1 = SaveSystem1.LoadPlayer1();
        FloorData2 data2 = SaveSystem2.LoadPlayer2();
        FloorData3 data3 = SaveSystem3.LoadPlayer3();
        FloorData4 data4 = SaveSystem4.LoadPlayer4();
        FloorData5 data5 = SaveSystem5.LoadPlayer5();
        FloorData6 data6 = SaveSystem6.LoadPlayer6();
        FloorData7 data7 = SaveSystem7.LoadPlayer7();
        //FloorDatat datat = SaveSystemt.LoadPlayert();

        if (data0.nextFloor0 == true)
        {
            level2Floor[0].image.sprite = unlockState;
            level2Floor[0].image.raycastTarget = true;
        }

        else
        {
            level2Floor[0].image.sprite = lockState;
            level2Floor[0].image.raycastTarget = false;
        }

        
        //
        if (data1.nextFloor1 == true)
        {
            level3Floor[0].image.sprite = unlockState;
            level3Floor[0].image.raycastTarget = true;
        }

        if (data2.nextFloor2 == true)
        {
            level4Floor[0].image.sprite = unlockState;
            level4Floor[0].image.raycastTarget = true;
        }

        if (data3.nextFloor3 == true)
        {
            level5Floor[0].image.sprite = unlockState;
            level5Floor[0].image.raycastTarget = true;

        }

        if (data4.nextFloor4 == true)
        {
            level6Floor[0].image.sprite = unlockState;
            level6Floor[0].image.raycastTarget = true;

        }

        if (data5.nextFloor5 == true)
        {
            level7Floor[0].image.sprite = unlockState;
            level7Floor[0].image.raycastTarget = true;

        }

        if (data6.nextFloor6 == true)
        {
            level8Floor[0].image.sprite = unlockState;
            level8Floor[0].image.raycastTarget = true;
        }


        //Classroomtxt.text = "Floor One: " +data1.stars1.ToString() + " Star/s";
        //Librarytxt.text = "Floor Two: " + data2.stars2.ToString() + " Star/s";
        //Canteentxt.text = "Floor Three: " + data3.stars3.ToString() + " Star/s";
        //Labtxt.text = "Floor Four: " + data4.stars4.ToString() + " Star/s"; 
        //Lockertxt.text = "Floor Five: " + data5.stars5.ToString() + " Star/s";
        //Gymtxt.text = "Floor Six: " + data6.stars6.ToString() + " Star/s";
        //Rooftoptxt.text = "Floor Seven: " + data7.stars7.ToString() + " Star/s";


    }


    private void Update()
    {

    }

    public string GetLevelPrefs(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    public void SetLevelPrefs(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }


}
