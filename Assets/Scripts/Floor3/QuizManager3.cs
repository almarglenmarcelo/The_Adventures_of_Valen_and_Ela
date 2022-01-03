using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager3 : MonoBehaviour
{
    public List<QuestionAnswer3> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject scrollScript;

    FloorLevelPrefs floorPrefs = new FloorLevelPrefs();
    ReviewerPrefs reviewerPrefs = new ReviewerPrefs();
    CostumePrefs costumePrefs = new CostumePrefs();



    public MeleeCombat meleeCombat_Valen;
    public MeleeCombat meleeCombat_Enemy;
    public Animator valen;
    public Animator enemy;


    //SFX
    public AudioSource rewardsSfx;
    public AudioSource defeatSFX;
    public AudioSource backgroundMusic;

    //monsterUI
    public Sprite[] monsterSpritesAlive;
    public Sprite[] monsterSpritesDead;
    public GameObject enemyDisplay;
    public GameObject Enemyicon;
    public Sprite[] monsterSprites;
    public TMPro.TextMeshProUGUI monsterText;

    //Stores costumes' sprites & PlayerUI
    public TMPro.TextMeshProUGUI playerText;
    public GameObject playerIcon;
    public Sprite[] playersprites;
    public Sprite[] elaCostumes;
    public Sprite[] elaAttack;
    public Sprite[] elaRun;
    public Sprite[] elaHit;
    public Sprite[] elaVictory;
    public Sprite[] elaDefeat;
    public Sprite[] valenCostumes;
    public Sprite[] valenAttack;
    public Sprite[] valenRun;
    public Sprite[] valenHit;
    public Sprite[] valenVictory;
    public Sprite[] valenDefeat;
    public GameObject playerDisplay;

    //MainUI
    public TMPro.TextMeshProUGUI QuestionPhrase;
    public TMPro.TextMeshProUGUI CurrentScore;
    public TMPro.TextMeshProUGUI CurrentQuestiontxt;
    public TMPro.TextMeshProUGUI Triestxt;
    public TMPro.TextMeshProUGUI WrongIdentifier;

    public TMPro.TextMeshProUGUI Uones;
    public TMPro.TextMeshProUGUI Utens;
    public TMPro.TextMeshProUGUI Uhundreds;
    public TMPro.TextMeshProUGUI Uthousands;

    public GameObject Quizpanel;
    public GameObject GoPanel0;
    public GameObject GoPanel1;
    public GameObject GoPanel2;
    public GameObject GoPanel3;
    public GameObject ContinueBtn;

    public GameObject Reviewer;
    public GameObject ReviewerOV;

    public GameObject Choices;

    public GameObject Hint;
    public GameObject HintPop;

    public GameObject Play;
    public GameObject Right;
    public GameObject Wrong;


    public TMPro.TextMeshProUGUI Qones;
    public TMPro.TextMeshProUGUI Qtens;
    public TMPro.TextMeshProUGUI Qhundreds;
    public TMPro.TextMeshProUGUI Qthousands;

    public GameObject AnimationOverlay;


    int totalQuestions = 0;
    int score;

    int qcounter = 0;
    int hints=10;
    int usedHint;
    int usedtemp;
    int tries = 0;
    int monsterInc = 0;

    public int playerDamage = 100;
    public float health = 100;
    public float enemyHealth = 100f;


    int decider;
    int numL;
    int numR;


    int AnswerPlace;
    string QuestionT;
    string vOnes;
    string vTens;
    string vHundreds;
    string vThousands;


    //xml variables
    public int stars3;
    public bool nextFloor3;
    public bool Costume3;
    public bool Puzzle3;
    public bool Reviewer3;




    private void Start()
    {
        EquipCostume();
        totalQuestions = QnA.Count;
        Play.SetActive(true);
        GoPanel0.SetActive(false);
        GoPanel1.SetActive(false);
        GoPanel2.SetActive(false);
        GoPanel3.SetActive(false);
        ContinueBtn.SetActive(false);


        if (GetLevelPrefs("NewSave3") == "3")
        {
            LoadPlayer3();
        }
        else
        {
            SetLevelPrefs("NewSave3", "3");
            stars3 = 0;
            Reviewer3 = false;
            nextFloor3 = false;
            Costume3 = false;
            Puzzle3 = false;
            SaveSystem3.SavePlayer3(this);
            LoadPlayer3();

        }
        generateQuestion();

    }
    void EquipCostume()
    {
        PlayerData data = PlayerSaveSystem.LoadPlayer();

        int isValen = PlayerPrefs.GetInt("isValen");
        if (isValen == 1)
        {
            playerText.text = "Valen";
            playerIcon.GetComponent<Image>().sprite = playersprites[0];
        }
        else
        {
            playerText.text = "Ela";
            playerIcon.GetComponent<Image>().sprite = playersprites[1];
        }
        //string costumePrefs = PlayerPrefs.GetString("costumePrefs");

        //Valen 
        if (isValen == 1 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[0];
        }

        if (isValen == 1 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[1];
        }

        if (isValen == 1 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[2];
        }
        if (isValen == 1 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[3];
        }

        if (isValen == 1 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[4];
        }

        if (isValen == 1 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[5];
        }

        if (isValen == 1 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[6];
        }

        if (isValen == 1 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = valenCostumes[7];
        }



        //Ela
        if (isValen == 0 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[0];
        }

        if (isValen == 0 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[1];
        }

        if (isValen == 0 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[2];
        }
        if (isValen == 0 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[3];
        }

        if (isValen == 0 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[4];
        }

        if (isValen == 0 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[5];
        }

        if (isValen == 0 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[6];
        }

        if (isValen == 0 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = elaCostumes[7];
        }

    }

    void poseAttack()
    {
        PlayerData data = PlayerSaveSystem.LoadPlayer();

        int isValen = PlayerPrefs.GetInt("isValen");

        if (isValen == 1 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[0];
        }

        if (isValen == 1 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[1];
        }

        if (isValen == 1 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[2];
        }
        if (isValen == 1 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[3];
        }

        if (isValen == 1 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[4];
        }

        if (isValen == 1 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[5];
        }

        if (isValen == 1 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[6];
        }

        if (isValen == 1 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = valenAttack[7];
        }



        //Ela
        if (isValen == 0 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[0];
        }

        if (isValen == 0 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[1];
        }

        if (isValen == 0 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[2];
        }
        if (isValen == 0 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[3];
        }

        if (isValen == 0 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[4];
        }

        if (isValen == 0 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[5];
        }

        if (isValen == 0 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[6];
        }

        if (isValen == 0 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = elaAttack[7];
        }
    }

    void poseHit()
    {

        PlayerData data = PlayerSaveSystem.LoadPlayer();

        int isValen = PlayerPrefs.GetInt("isValen");

        if (isValen == 1 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[0];
        }

        if (isValen == 1 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[1];
        }

        if (isValen == 1 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[2];
        }
        if (isValen == 1 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[3];
        }

        if (isValen == 1 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[4];
        }

        if (isValen == 1 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[5];
        }

        if (isValen == 1 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[6];
        }

        if (isValen == 1 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = valenHit[7];
        }



        //Ela
        if (isValen == 0 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[0];
        }

        if (isValen == 0 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[1];
        }

        if (isValen == 0 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[2];
        }
        if (isValen == 0 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[3];
        }

        if (isValen == 0 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[4];
        }

        if (isValen == 0 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[5];
        }

        if (isValen == 0 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[6];
        }

        if (isValen == 0 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = elaHit[7];
        }
    }
    void poseDefeat()
    {

        PlayerData data = PlayerSaveSystem.LoadPlayer();

        int isValen = PlayerPrefs.GetInt("isValen");

        if (isValen == 1 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[0];
        }

        if (isValen == 1 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[1];
        }

        if (isValen == 1 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[2];
        }
        if (isValen == 1 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[3];
        }

        if (isValen == 1 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[4];
        }

        if (isValen == 1 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[5];
        }

        if (isValen == 1 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[6];
        }

        if (isValen == 1 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = valenDefeat[7];
        }



        //Ela
        if (isValen == 0 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[0];
        }

        if (isValen == 0 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[1];
        }

        if (isValen == 0 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[2];
        }
        if (isValen == 0 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[3];
        }

        if (isValen == 0 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[4];
        }

        if (isValen == 0 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[5];
        }

        if (isValen == 0 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[6];
        }

        if (isValen == 0 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = elaDefeat[7];
        }
    }

    void poseVictory()
    {

        PlayerData data = PlayerSaveSystem.LoadPlayer();

        int isValen = PlayerPrefs.GetInt("isValen");

        if (isValen == 1 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[0];
        }

        if (isValen == 1 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[1];
        }

        if (isValen == 1 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[2];
        }
        if (isValen == 1 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[3];
        }

        if (isValen == 1 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[4];
        }

        if (isValen == 1 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[5];
        }

        if (isValen == 1 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[6];
        }

        if (isValen == 1 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = valenVictory[7];
        }



        //Ela
        if (isValen == 0 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[0];
        }

        if (isValen == 0 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[1];
        }

        if (isValen == 0 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[2];
        }
        if (isValen == 0 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[3];
        }

        if (isValen == 0 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[4];
        }

        if (isValen == 0 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[5];
        }

        if (isValen == 0 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[6];
        }

        if (isValen == 0 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = elaVictory[7];
        }
    }
    void poseRun()
    {

        PlayerData data = PlayerSaveSystem.LoadPlayer();

        int isValen = PlayerPrefs.GetInt("isValen");

        if (isValen == 1 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[0];
        }

        if (isValen == 1 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[1];
        }

        if (isValen == 1 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[2];
        }
        if (isValen == 1 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[3];
        }

        if (isValen == 1 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[4];
        }

        if (isValen == 1 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[5];
        }

        if (isValen == 1 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[6];
        }

        if (isValen == 1 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = valenRun[7];
        }



        //Ela
        if (isValen == 0 && data.costumeEquipped == "c0")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[0];
        }

        if (isValen == 0 && data.costumeEquipped == "c1")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[1];
        }

        if (isValen == 0 && data.costumeEquipped == "c2")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[2];
        }
        if (isValen == 0 && data.costumeEquipped == "c3")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[3];
        }

        if (isValen == 0 && data.costumeEquipped == "c4")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[4];
        }

        if (isValen == 0 && data.costumeEquipped == "c5")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[5];
        }

        if (isValen == 0 && data.costumeEquipped == "c6")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[6];
        }

        if (isValen == 0 && data.costumeEquipped == "c7")
        {
            playerDisplay.GetComponent<Image>().sprite = elaRun[7];
        }
    }   //to be used
    public void SavePlayerReset3()
    {
        SetLevelPrefs("NewSave3", "3");
        stars3 = 0;
        Reviewer3 = false;
        nextFloor3 = false;
        Costume3 = false;
        Puzzle3 = false;
        SaveSystem3.SavePlayer3(this);
    }
    public void SavePlayer3()
    {

        FloorData3 data = SaveSystem3.LoadPlayer3();
        if (stars3 > data.stars3)
        {
            SaveSystem3.SavePlayer3(this);
        }
        else
        {
            Debug.Log("SavePlayer3 catch");

        }


    }
    public void LoadPlayer3()
    {


        FloorData3 data = SaveSystem3.LoadPlayer3();


        //Data debug
        Debug.Log("Stars = " + data.stars3.ToString() + " Floor = " + data.nextFloor3.ToString() + " Costume = " + data.Costume3.ToString() + " Puzzle = " + data.Puzzle3.ToString() + " Reviewer = " + data.Reviewer3.ToString());

    }

    public void showReviewerOV()
    {
        ReviewerOV.SetActive(true);
    }

    public void showReviewer()
    {
        Reviewer.SetActive(true);
    }

    public void disableReviewer()
    {
        Reviewer.gameObject.SetActive(false);
    }



    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayStart()
    {
        Play.SetActive(false);
    }

    ////Unlock only level 4
    //private void UnlockNextLevel()
    //{
    //    floorPrefs.SetLevelPrefs("level4", "unlockLevel4");
    //}

    ////Unlock Only Reviewer 4
    //private void UnlockNextReviewer()
    //{
    //    reviewerPrefs.SetReviewerPrefs("reviewer4", "unlockReviewer4");
    //}

    //private void UnlockCostume()
    //{
    //    costumePrefs.SetCostumePrefs("costume4", 1);
    //}
    private void PuzzleCount(int count)
    {
        PlayerPrefs.SetInt("puzzleCount", count);
    }
    private void ThirdPuzzlePiece()
    {
        PlayerPrefs.SetInt("puzzle3", 1);
    }
    IEnumerator GameOver()
    {
        Wrong.SetActive(false);
        Right.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        //UnlockNextLevel();
        //UnlockNextReviewer();

        PlayerPrefs.SetInt("floor", 4);
        PlayerPrefs.SetInt("floor3Score", score);
        if (score == 0)
        {
            poseDefeat();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel0.SetActive(true);
            backgroundMusic.mute = true;
            defeatSFX.Play();

            //xml variables
            stars3 = 0;
            Reviewer3 = false;
            nextFloor3 = false;
            Costume3 = false;
            Puzzle3 = false;

            SavePlayer3();
        }

        if (score <= 7 && score >= 1)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel1.SetActive(true);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars3 = 1;
            Reviewer3 = true;
            nextFloor3 = true;
            Costume3 = false;
            Puzzle3 = false;

            SavePlayer3();
        }

        if (score <= 11 && score >= 8)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel2.SetActive(true);
           
           
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars3 = 2;
            Reviewer3 = true;
            nextFloor3 = true;
            Costume3 = true;
            Puzzle3 = false;

            //UnlockCostume();
            SavePlayer3();
        }
        if (score <= 15 && score >= 12)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel3.SetActive(true);
           
       
            PlayerPrefs.SetInt("puzzleCount", 3);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars3 = 3;
            Reviewer3 = true;
            nextFloor3 = true;
            Costume3 = true;
            Puzzle3 = true;

            //UnlockCostume();
            PuzzleCount(3);
            ThirdPuzzlePiece();
            SavePlayer3();
        }
    }

    public void CorrectAnswerAnimation()
    {
        poseAttack();

        meleeCombat_Valen.CharacterAttack();
        meleeCombat_Enemy.EnemyHurt();
        StartCoroutine(runDelay());
    }
    IEnumerator runDelay()
    {
        if (qcounter < 11)
        {
            yield return new WaitForSeconds(2f);
            poseRun();
        }
        if (qcounter != 15)
        {
            yield return new WaitForSeconds(1.7f);
            EquipCostume();
        }
    }
        public void WrongAnswerAnimation()
    {
        StartCoroutine(hitDelay());
        meleeCombat_Enemy.EnemyAttack();
        meleeCombat_Valen.CharacterHurt();
    }

    IEnumerator hitDelay()
    {
        yield return new WaitForSeconds(.2f);
        Debug.Log("hit");
        poseHit();
        StartCoroutine(equipDelay());
    }
    IEnumerator equipDelay()
    {
        yield return new WaitForSeconds(1.5f);
        EquipCostume();
    }

   

    public void correct()
    {

        if (qcounter >= 11 && qcounter < 15)
        {
            playerDamage = 20;
        }
        else if (qcounter == 15)
        {
            playerDamage = 100;
        }
        else
        {
            playerDamage = 100;
        }
        CorrectAnswerAnimation();
        if (qcounter != 15)
        {
            randomizeEnemy();
            enemyHealth = enemyHealth - playerDamage;
        }
        else
        {
            enemyHealth = enemyHealth - playerDamage;
            if (enemyHealth <= 0)
            {
                enemyDisplay.GetComponent<Image>().sprite = monsterSpritesDead[4];
            }
        }

        score += 1;
        CurrentScore.text = score.ToString();
        QnA.RemoveAt(currentQuestion);
        
        StartCoroutine(CorrectTimer());
        generateQuestion();
    }

    public void wrong()
    {
        int enemydmg = 6;
        tries++;

        Triestxt.text = "Tries: \n" + tries.ToString();
        StartCoroutine(firstWrongTimer());



        if (tries == 2)
        {
            StartCoroutine(WrongTimer());
            WrongAnswerAnimation();

            if (decider == 0)
            {
                QuestionT = vOnes;
            }
            else if (decider == 1)
            {
                QuestionT = vTens;
            }
            else if (decider == 2)
            {
                QuestionT = vHundreds;
            }
            else if (decider == 3)
            {
                QuestionT = vThousands;
            }

            if (qcounter == 15)
            {
                enemydmg = 100;
            }
            else
            {
                enemydmg = 6;
            }
            health = health - enemydmg;
            QuestionPhrase.gameObject.SetActive(false);
            Uones.gameObject.SetActive(false);
            Utens.gameObject.SetActive(false);
            Uhundreds.gameObject.SetActive(false);
            Uthousands.gameObject.SetActive(false);
            WrongIdentifier.gameObject.SetActive(true);
            Qones.text = "";
            Qtens.text = "";
            Qhundreds.text = "";
            Qthousands.text = "";
            WrongIdentifier.text = "The correct answer is: " + QuestionT;
            Choices.SetActive(false);
            ContinueBtn.SetActive(true);

            Hint.SetActive(false);
        }


    }

    IEnumerator firstWrongTimer()
    {
        AnimationOverlay.SetActive(true);
        Wrong.SetActive(true);
        Right.SetActive(false);
        yield return new WaitForSeconds(1f);
        Wrong.SetActive(false);
        AnimationOverlay.SetActive(false);

    }
    IEnumerator CorrectTimer()
    {
        AnimationOverlay.SetActive(true);
        Wrong.SetActive(false);
        Right.SetActive(true);
        yield return new WaitForSeconds(5f);
        Right.SetActive(false);
        AnimationOverlay.SetActive(false);

    }
    IEnumerator WrongTimer()
    {
        Right.SetActive(false);
        Wrong.SetActive(true);
        AnimationOverlay.SetActive(true);
        yield return new WaitForSeconds(3f);
        AnimationOverlay.SetActive(false);
        Wrong.SetActive(false);
    }

    void randomizeEnemy()
    {


        monsterInc++;
        


        if (qcounter != 1 && qcounter <= 10)
        {


            enemyDisplay.GetComponent<Image>().sprite = monsterSpritesDead[monsterInc - 1];
            StartCoroutine(EnemyAnimationTimer());

        }

        else if (qcounter >= 10)
        {
          


            StartCoroutine(EnemyAnimationTimer());
        
        }


        else
        {
            enemyDisplay.GetComponent<Image>().sprite = monsterSpritesDead[3];
            StartCoroutine(EnemyAnimationTimer());

        }

    }

    IEnumerator EnemyAnimationTimer()
    {
        StartCoroutine(equipDelay());


        yield return new WaitForSeconds(2f);

        if (qcounter == 11)
        {
            enemyHealth = 100;
        }
        if (qcounter >= 11)
        {
            meleeCombat_Enemy.animator.SetBool("Boss_Fight", true);

            enemyDisplay.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(75, 75);
            Enemyicon.GetComponent<Image>().sprite = monsterSprites[4];
            enemyDisplay.GetComponent<Image>().sprite = monsterSpritesAlive[4];

            monsterText.text = "Boss Slime";
            scrollScript.GetComponent<ScrollScript>().ScrollBoth();                                    //Scrolling of Hallway with main Place scrolling (Boss Fight)   
        }

        else
        {

            if (monsterInc >= 4)
            {
                monsterInc = 0;
            }
            enemyHealth = 100;
            Enemyicon.GetComponent<Image>().sprite = monsterSprites[monsterInc];
            enemyDisplay.GetComponent<Image>().sprite = monsterSpritesAlive[monsterInc];
            monsterText.text = "Slime";

            scrollScript.GetComponent<ScrollScript>().ScrollHallway();                                     //Scrolling Animation of Hallway here (Normal monsters)

        }
    }
    public void continueGame()
    {
        Choices.SetActive(true);
        QnA.RemoveAt(currentQuestion);
        QuestionPhrase.gameObject.SetActive(true);
        Uones.gameObject.SetActive(true);
        Utens.gameObject.SetActive(true);
        Uhundreds.gameObject.SetActive(true);
        Uthousands.gameObject.SetActive(true);

        generateQuestion();
    }




    void setWrongAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript3>().isCorrect = false;
        }
        //options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
        options[0].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vOnes;
        options[1].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vTens;
        options[2].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vHundreds;
        options[3].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vThousands;



    }

    void setRightAnswer()
    {

        if (decider == 0)
        {
            AnswerPlace = 0;
            QnA[currentQuestion].CorrectAnswer = AnswerPlace;
            options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vOnes + "*";
        }
        else if (decider == 1)
        {
            AnswerPlace = 1;
            QnA[currentQuestion].CorrectAnswer = AnswerPlace;
            options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vTens + "*";
        }
        else if (decider == 2)
        {
            AnswerPlace = 2;
            QnA[currentQuestion].CorrectAnswer = AnswerPlace;
            options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vHundreds + "*";
        }
        else
        {
            AnswerPlace = 3;
            QnA[currentQuestion].CorrectAnswer = AnswerPlace;
            options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = vThousands + "*";
        }


        //QnA[currentQuestion].CorrectAnswer = AnswerPlace;
        //options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QuestionT + "*";

        for (int i = 0; i < options.Length; i++)
        {
            if (QnA[currentQuestion].CorrectAnswer == i)// answers here
            {
                options[i].GetComponent<AnswerScript3>().isCorrect = true;


            }
        }
    }
    public void hint()
    {
        if (hints >= 1)
        {


            int temp = Random.Range(0, 4);

            if (temp == AnswerPlace || temp == usedtemp)
            {
                hint();
            }
            else
            {
                hints--;
                Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
                options[temp].SetActive(false);
                usedHint++;
                usedtemp = temp;
            }
            if (usedHint == 2)
            {
                Hint.SetActive(false);
            }
        }
        else
        {

            //HintPop.SetActive(true);

            StartCoroutine(HintpopTimer());
        }

    }


    IEnumerator HintpopTimer()
    {
        HintPop.SetActive(true);
        yield return new WaitForSeconds(3f);
        HintPop.SetActive(false);
    }

    void generateQuestion()
    {
        if (QnA.Count > 0 && QnA.Count <= 15)
        {

            currentQuestion = Random.Range(0, QnA.Count);
            int tempqcount = qcounter + 1;
            CurrentQuestiontxt.text = "Question " + tempqcount.ToString();

            //hint
            usedHint =0;
            usedtemp = 6;
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            options[3].SetActive(true);
            Hint.SetActive(true);

            qcounter++;
            tries = 0;
            Triestxt.text = "Tries: \n" + tries.ToString();
            WrongIdentifier.gameObject.SetActive(false);
            ContinueBtn.SetActive(false);
            randomizer();
            setWrongAnswers();
            setRightAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");

            StartCoroutine(GameOver());

        }

    }



    public void randomizer()
    {


        // numL = Random.Range(1000, 9999);
        int ones = Random.Range(1,9);
        int tens = Random.Range(1,9);
        int hundreds = Random.Range(1,9);
        int thousands = Random.Range(1,9);

        Uones.text = ones.ToString();
        Utens.text = tens.ToString();
        Uhundreds.text = hundreds.ToString();
        Uthousands.text = thousands.ToString();

        decider = Random.Range(0, 4);

        convert(ref ones, ref tens, ref hundreds, ref thousands);

        if (decider == 0)
        {

           

            
            Qones.text = "_";
            Qtens.text = "";
            Qhundreds.text = "";
            Qthousands.text = "";
        }
        else if (decider == 1)
        {


            
            Qones.text = "";
            Qtens.text = "_";
            Qhundreds.text = "";
            Qthousands.text = "";
        }
        else if (decider == 2)
        {

            
            Qones.text = "";
            Qtens.text = "";
            Qhundreds.text = "_";
            Qthousands.text = "";
        }
        else
        {


            Qones.text = "";
            Qtens.text = "";
            Qhundreds.text = "";
            Qthousands.text = "_";
        }
    }


        // Start of convert num to text module


        private void convert(ref int cones, ref int ctens, ref int chundreds, ref int cthousands)
        {
            string result;

            int num;



            num = cones;

            if (ConvertNumberToText(num, out result) == true)

                vOnes = result;

            num = ctens*10;

            if (ConvertNumberToText(num, out result) == true)

                vTens = result;

            num = chundreds*100;

            if (ConvertNumberToText(num, out result) == true)

                vHundreds = result;

            num = cthousands*1000;

            if (ConvertNumberToText(num, out result) == true)

                vThousands = result;




        }

        static bool HelperConvertNumberToText(int num, out string buf)

        {

            string[] strones = {

            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",

            "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",

            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen",

          };



            string[] strtens = {

              "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty",

              "Seventy", "Eighty", "Ninety", "Hundred"

          };



            string result = "";

            buf = "";

            int single, tens, hundreds;



            if (num > 1000)

                return false;



            hundreds = num / 100;

            num = num - hundreds * 100;

            if (num < 20)

            {

                tens = 0; // special case

                single = num;

            }

            else

            {

                tens = num / 10;

                num = num - tens * 10;

                single = num;

            }



            result = "";



            if (hundreds > 0)

            {

                result += strones[hundreds - 1];

                result += " Hundred ";

            }

            if (tens > 0)

            {

                result += strtens[tens - 1];

                result += " ";

            }

            if (single > 0)

            {

                result += strones[single - 1];

                result += " ";

            }



            buf = result;

            return true;

        }



        static bool ConvertNumberToText(int num, out string result)

        {

            string tempString = "";

            int thousands;

            int temp;

            result = "";

            if (num < 0 || num > 100000)

            {

                System.Console.WriteLine(num + " \tNot Supported");

                return false;

            }



            if (num == 0)

            {

                System.Console.WriteLine(num + " \tZero");

                return false;

            }



            if (num < 1000)

            {

                HelperConvertNumberToText(num, out tempString);

                result += tempString;

            }

            else

            {

                thousands = num / 1000;

                temp = num - thousands * 1000;

                HelperConvertNumberToText(thousands, out tempString);

                result += tempString;

                result += "Thousand ";

                HelperConvertNumberToText(temp, out tempString);

                result += tempString;

            }

            return true;

        }
    // End num to text


    public void HideThis(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ShowNext(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void RestartThisQuizScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    private string GetLevelPrefs(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    private void SetLevelPrefs(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }






}





