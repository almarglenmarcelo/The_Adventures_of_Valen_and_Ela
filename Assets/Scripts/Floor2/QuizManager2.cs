using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager2 : MonoBehaviour
{
    public List<QuestionAnswer2> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject scrollScript;

    FloorLevelPrefs floorPrefs = new FloorLevelPrefs();
    ReviewerPrefs reviewerPrefs = new ReviewerPrefs();
    CostumePrefs costumePrefs = new CostumePrefs();
    
    //Animation Triggers
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


    //Main UI
    public TMPro.TextMeshProUGUI QuestionPhrase;
    public TMPro.TextMeshProUGUI CurrentScore;
    public TMPro.TextMeshProUGUI CurrentQuestiontxt;
    public TMPro.TextMeshProUGUI Triestxt;
    public TMPro.TextMeshProUGUI WrongIdentifier;

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
    int monsterInc = 0;
    int tries = 0;

    int decider;
    int numL;
    int numR;


    int hints=10;
    int usedtemp;
    int usedHint;

    int AnswerPlace;
    string QuestionT;

    public int playerDamage = 100;
    public float health = 100;
    public float enemyHealth = 100f;

    //xml variables
    public int stars2;
    public bool nextFloor2;
    public bool Costume2;
    public bool Puzzle2;
    public bool Reviewer2;



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

        if (GetLevelPrefs("NewSave2") == "2")
        {
            LoadPlayer2();
        }
        else
        {
            SavePlayerReset2();
            LoadPlayer2();

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
    public void SavePlayerReset2()
    {
        SetLevelPrefs("NewSave2", "2");
        stars2 = 0;
        Reviewer2 = false;
        nextFloor2 = false;
        Costume2 = false;
        Puzzle2 = false;
        SaveSystem2.SavePlayer2(this);
    }
    public void SavePlayer2()
    {

        FloorData2 data = SaveSystem2.LoadPlayer2();
        if (stars2 > data.stars2)
        {
            SaveSystem2.SavePlayer2(this);
        }
        else
        {
            Debug.Log("SavePlayer2 catch");

        }


    }
    public void LoadPlayer2()
    {


        FloorData2 data = SaveSystem2.LoadPlayer2();


        //Data debug
        Debug.Log("Stars = " + data.stars2.ToString() + " Floor = " + data.nextFloor2.ToString() + " Costume = " + data.Costume2.ToString() + " Puzzle = " + data.Puzzle2.ToString() + " Reviewer = " + data.Reviewer2.ToString());

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
    //    floorPrefs.SetLevelPrefs("level3", "unlockLevel3");
    //}

    ////Unlock Only Reviewer 4
    //private void UnlockNextReviewer()
    //{
    //    reviewerPrefs.SetReviewerPrefs("reviewer3", "unlockReviewer3");
    //}

    //private void UnlockCostume()
    //{
    //    costumePrefs.SetCostumePrefs("costume3", 1);
    //}

    private void PuzzleCount(int count)
    {
        PlayerPrefs.SetInt("puzzleCount", count);
    }
    private void SecondPuzzlePiece()
    {
        PlayerPrefs.SetInt("puzzle2", 1);
    }

    IEnumerator GameOver()
    {
        Wrong.SetActive(false);
        Right.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        //UnlockNextReviewer();
        //UnlockNextLevel();

        PlayerPrefs.SetInt("floor", 3);
        PlayerPrefs.SetInt("floor2Score", score);
        if (score == 0)
        {
            poseDefeat();
            yield return new WaitForSeconds(3f);
            GoPanel0.SetActive(true);
            backgroundMusic.mute = true;
            defeatSFX.Play();

            //xml variables
            stars2 = 0;
            Reviewer2 = false;
            nextFloor2 = false;
            Costume2 = false;
            Puzzle2 = false;

            SavePlayer2();
        }

        if (score <= 7 && score >= 1)
        {
            poseVictory();
            yield return new WaitForSeconds(3f);
            GoPanel1.SetActive(true);
            backgroundMusic.mute = true;
            rewardsSfx.Play();
            //xml variables
            stars2 = 1;
            Reviewer2 = true;
            nextFloor2 = true;
            Costume2 = false;
            Puzzle2 = false;

            SavePlayer2();
        }

        if (score <= 11 && score >= 8)
        {
            poseVictory();
            yield return new WaitForSeconds(3f);
            GoPanel2.SetActive(true);
           
            backgroundMusic.mute = true;
            rewardsSfx.Play();
            //xml variables
            stars2 = 2;
            Reviewer2 = true;
            nextFloor2 = true;
            Costume2 = true;
            Puzzle2 = false;

            //UnlockCostume();
            SavePlayer2();
        }
        if (score <= 15 && score >= 12)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel3.SetActive(true);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars2 = 3;
            Reviewer2 = true;
            nextFloor2 = true;
            Costume2 = true;
            Puzzle2 = true;

            PuzzleCount(2);
            SecondPuzzlePiece();
            //UnlockCostume();

            SavePlayer2();
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

        //AnimationOverlay.SetActive(false);
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

        generateQuestion();
    }



    void setWrongAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript2>().isCorrect = false;
        }
        //options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
        options[0].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Ones";
        options[1].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Tens";
        options[2].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hundreds";
        options[3].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Thousands";



    }

    void setRightAnswer()
    {

        if (decider == 0)
        {
            AnswerPlace = 0;
        }
        else if (decider == 1)
        {
            AnswerPlace = 1;
        }
        else if (decider == 2)
        {
            AnswerPlace = 2;
        }
        else
        {
            AnswerPlace = 3;
        }


        QnA[currentQuestion].CorrectAnswer = AnswerPlace;
        options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QuestionT + "*";

        for (int i = 0; i < options.Length; i++)
        {
            if (QnA[currentQuestion].CorrectAnswer == i)// answers here
            {
                options[i].GetComponent<AnswerScript2>().isCorrect = true;


            }
        }
    }


    void generateQuestion()
    {
        if (QnA.Count > 0 && QnA.Count <= 15)
        {

            currentQuestion = Random.Range(0, QnA.Count);
            int tempqcount = qcounter + 1;
            CurrentQuestiontxt.text = "Question " + tempqcount.ToString();

            //Variables
            qcounter++;
            tries = 0;
            usedHint = 0;
            usedtemp = 6;
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
            Triestxt.text = "Tries: \n" + tries.ToString();

            //UI
            WrongIdentifier.gameObject.SetActive(false);
            ContinueBtn.SetActive(false);
            Hint.SetActive(true);
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            options[3].SetActive(true);

            //Functions
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
    public void randomizer()
    {


        numL = Random.Range(1000, 9999);


        decider = Random.Range(0, 4);

        if (decider == 0)
        {

            QuestionPhrase.text = numL.ToString();

            QuestionT = "Ones";
            Qones.text = "_";
            Qtens.text = "";
            Qhundreds.text = "";
            Qthousands.text = "";
        }
        else if (decider == 1)
        {

            QuestionPhrase.text = numL.ToString();

            QuestionT = "Tens";
            Qones.text = "";
            Qtens.text = "_";
            Qhundreds.text = "";
            Qthousands.text = "";
        }
        else if (decider == 2)
        {

            QuestionPhrase.text = numL.ToString();

            QuestionT = "Hundreds";
            Qones.text = "";
            Qtens.text = "";
            Qhundreds.text = "_";
            Qthousands.text = "";
        }
        else
        {

            QuestionPhrase.text = numL.ToString();

            QuestionT = "Thousands";
            Qones.text = "";
            Qtens.text = "";
            Qhundreds.text = "";
            Qthousands.text = "_";
        }


    }


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
