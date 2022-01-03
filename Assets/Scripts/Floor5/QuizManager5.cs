using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager5 : MonoBehaviour
{
    public List<QuestionAnswer5> QnA;
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

    public TMPro.TextMeshProUGUI QuestionPhrase;
    public TMPro.TextMeshProUGUI CurrentScore;
    public TMPro.TextMeshProUGUI CurrentQuestiontxt;
    public TMPro.TextMeshProUGUI Triestxt;
    public TMPro.TextMeshProUGUI WrongIdentifier;

    public TMPro.TextMeshProUGUI StaticQuestion;

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
    public GameObject AnimationOverlay;


    int totalQuestions = 0;
    int score;
    int stars;
    int qcounter = 0;

    public int playerDamage = 100;
    public float health = 100;
    public float enemyHealth = 100f;
    int monsterInc = 0;

    int tries = 0;


    int decider;
    int numL;
    int numR;

    int hints =10;
    int usedtemp;
    int usedHint;

    int AnswerPlace;
    string QuestionT;

    //xml variables
    public int stars5;
    public bool nextFloor5;
    public bool Costume5;
    public bool Puzzle5;
    public bool Reviewer5;



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


        if (GetLevelPrefs("NewSave5") == "5")
        {
            LoadPlayer5();
        }
        else
        {
            SetLevelPrefs("NewSave5", "5");
            stars5 = 0;
            Reviewer5 = false;
            nextFloor5 = false;
            Costume5 = false;
            Puzzle5 = false;
            SaveSystem5.SavePlayer5(this);
            LoadPlayer5();

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
    public void SavePlayer5()
    {

        FloorData5 data = SaveSystem5.LoadPlayer5();
        if (stars5 > data.stars5)
        {
            SaveSystem5.SavePlayer5(this);
        }
        else
        {
            Debug.Log("SavePlayer5 catch");

        }


    }
    public void SavePlayerReset5()
    {
        SetLevelPrefs("NewSave5", "5");
        stars5 = 0;
        Reviewer5 = false;
        nextFloor5 = false;
        Costume5 = false;
        Puzzle5 = false;
        SaveSystem5.SavePlayer5(this);
    }
    public void LoadPlayer5()
    {


        FloorData5 data = SaveSystem5.LoadPlayer5();


        //Data debug
        Debug.Log("Stars = " + data.stars5.ToString() + " Floor = " + data.nextFloor5.ToString() + " Costume = " + data.Costume5.ToString() + " Puzzle = " + data.Puzzle5.ToString() + " Reviewer = " + data.Reviewer5.ToString());

    }

    public void showReviewerOV()
    {
        ReviewerOV.SetActive(true);
    }

    public void showReviewer()
    {
        Reviewer.SetActive(true);
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
    //    floorPrefs.SetLevelPrefs("level6", "unlockLevel6");
    //}

    ////Unlock Only Reviewer 4
    //private void UnlockNextReviewer()
    //{
    //    reviewerPrefs.SetReviewerPrefs("reviewer6", "unlockReviewer6");
    //}
    //private void UnlockCostume()
    //{
    //    costumePrefs.SetCostumePrefs("costume6", 1);
    //}
    private void PuzzleCount(int count)
    {
        PlayerPrefs.SetInt("puzzleCount", count);
    }
    private void FifthPuzzlePiece()
    {
        PlayerPrefs.SetInt("puzzle5", 1);
    }

    IEnumerator GameOver()
    {
        Wrong.SetActive(false);
        Right.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        //UnlockNextLevel();
        //UnlockNextReviewer();

        PlayerPrefs.SetInt("floor", 6);
        PlayerPrefs.SetInt("floor5Score", score);
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
            stars5 = 0;
            Reviewer5 = false;
            nextFloor5 = false;
            Costume5 = false;
            Puzzle5 = false;

            SavePlayer5();
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
            stars5 = 1;
            Reviewer5 = true;
            nextFloor5 = true;
            Costume5 = false;
            Puzzle5 = false;

            SavePlayer5();
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
            stars5 = 2;
            Reviewer5 = true;
            nextFloor5 = true;
            Costume5 = true;
            Puzzle5 = false;
            //UnlockCostume();
            SavePlayer5();
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
            stars5 = 3;
            Reviewer5 = true;
            nextFloor5 = true;
            Costume5 = true;
            Puzzle5 = true;

           
            //UnlockCostume();
            PuzzleCount(5);
            FifthPuzzlePiece();
            SavePlayer5();
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
      
        StartCoroutine(CorrectTimer());
        CurrentScore.text = score.ToString();
        QnA.RemoveAt(currentQuestion);
     
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
            WrongIdentifier.text = "The correct answer is: " + QuestionT;
            Choices.SetActive(false);
            ContinueBtn.SetActive(true);
            Hint.SetActive(false);
            StaticQuestion.gameObject.SetActive(false);
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
        AnimationOverlay.SetActive(true);



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

        generateQuestion();
    }




    void setWrongAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript5>().isCorrect = false;
        }
        
        options[0].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "<";
        options[1].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = ">";
        options[2].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "=";



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
        else
        {
            AnswerPlace = 2;
        }


        QnA[currentQuestion].CorrectAnswer = AnswerPlace;
        options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QuestionT + "*";

        for (int i = 0; i < options.Length; i++)
        {
            if (QnA[currentQuestion].CorrectAnswer == i)// answers here
            {
                options[i].GetComponent<AnswerScript5>().isCorrect = true;


            }
        }
    }


    public void hint()
    {
        if (hints >= 1)
        {


            int temp = Random.Range(0, 3);

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
            usedHint = 0;
            usedtemp = 6;
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            
            Hint.SetActive(true);

            qcounter++;
            tries = 0;
            Triestxt.text = "Tries: \n" + tries.ToString();
            WrongIdentifier.gameObject.SetActive(false);
            ContinueBtn.SetActive(false);
            StaticQuestion.gameObject.SetActive(true);
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


        numL = Random.Range(0, 1000);
        numR = Random.Range(0, 1000);


        if (numL < numR)
        {
            decider = 0;
            QuestionPhrase.text = numL.ToString() + "_" + numR.ToString();

            QuestionT = "<";
        }
        else if (numL > numR)
        {
            decider = 1;
            QuestionPhrase.text = numL.ToString() + "_" + numR.ToString();

            QuestionT = ">";
        }
        else
        {
            decider = 2;
            QuestionPhrase.text = numL.ToString() + "_" + numR.ToString();

            QuestionT = "=";
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

