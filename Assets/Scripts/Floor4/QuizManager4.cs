using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager4 : MonoBehaviour
{
    public List<QuestionAnswer4> QnA;
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
    
    int qcounter = 0;
    int decider;
    int tries = 0;
    int numT;

    int A;
    int B;
    int C;
    int D;

    int hints = 10;
    int usedtemp;
    int usedHint;

    public int playerDamage = 100;
    public float health = 100;
    public float enemyHealth = 100f;
    int monsterInc = 0;

    string QuestionL;
    string QuestionR;
    string AnswerA;
    string AnswerB;
    string AnswerC;
    string AnswerD;


    int AnswerPlace;
    string QuestionT;

    //xml variables
    public int stars4;
    public bool nextFloor4;
    public bool Costume4;
    public bool Puzzle4;
    public bool Reviewer4;



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

        if (GetLevelPrefs("NewSave4") == "4")
        {
            LoadPlayer4();
        }
        else
        {
            SetLevelPrefs("NewSave4", "4");
            stars4 = 0;
            Reviewer4 = false;
            nextFloor4 = false;
            Costume4 = false;
            Puzzle4 = false;
            SaveSystem4.SavePlayer4(this);
            LoadPlayer4();

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
    public void SavePlayer4()
    {

        FloorData4 data = SaveSystem4.LoadPlayer4();
        if (stars4 > data.stars4)
        {
            SaveSystem4.SavePlayer4(this);
        }
        else
        {
            Debug.Log("SavePlayer4 catch");

        }


    }
    public void SavePlayerReset4()
    {
        SetLevelPrefs("NewSave4", "4");
        stars4 = 0;
        Reviewer4 = false;
        nextFloor4 = false;
        Costume4 = false;
        Puzzle4 = false;
        SaveSystem4.SavePlayer4(this);
    }
    public void LoadPlayer4()
    {


        FloorData4 data = SaveSystem4.LoadPlayer4();


        //Data debug
        Debug.Log("Stars = " + data.stars4.ToString() + " Floor = " + data.nextFloor4.ToString() + " Costume = " + data.Costume4.ToString() + " Puzzle = " + data.Puzzle4.ToString() + " Reviewer = " + data.Reviewer4.ToString());

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
    //    floorPrefs.SetLevelPrefs("level5", "unlockLevel5");
    //}

    ////Unlock Only Reviewer 4
    //private void UnlockNextReviewer()
    //{
    //    reviewerPrefs.SetReviewerPrefs("reviewer5", "unlockReviewer5");
    //}
    //private void UnlockCostume()
    //{
    //    costumePrefs.SetCostumePrefs("costume5", 1);
    //}
    private void PuzzleCount(int count)
    {
        PlayerPrefs.SetInt("puzzleCount", count);
    }
    private void FourthPuzzlePiece()
    {
        PlayerPrefs.SetInt("puzzle4", 1);
    }

    IEnumerator GameOver()
    {
        Wrong.SetActive(false);
        Right.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        //UnlockNextLevel();
        //UnlockNextReviewer();

        PlayerPrefs.SetInt("floor", 5);
        PlayerPrefs.SetInt("floor4Score", score);
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
            stars4 = 0;
            Reviewer4 = false;
            nextFloor4 = false;
            Costume4 = false;
            Puzzle4 = false;

            SavePlayer4();
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
            stars4 = 1;
            Reviewer4 = true;
            nextFloor4 = true;
            Costume4 = false;
            Puzzle4 = false;

            SavePlayer4();
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
            stars4 = 2;
            Reviewer4 = true;
            nextFloor4 = true;
            Costume4 = true;
            Puzzle4 = false;

            //UnlockCostume();
            SavePlayer4();
        }
        if (score <= 15 && score >= 12)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel3.SetActive(true);
          
         
            PlayerPrefs.SetInt("puzzleCount", 4);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars4 = 3;
            Reviewer4 = true;
            nextFloor4 = true;
            Costume4 = true;
            Puzzle4 = true;

            //UnlockCostume();
            FourthPuzzlePiece();
            PuzzleCount(4);

            SavePlayer4();
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
            WrongAnswerAnimation();
            StartCoroutine(WrongTimer());
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
            WrongIdentifier.text = "The correct answer is: " +QuestionT;
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
       // AnimationOverlay.SetActive(true);


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
            options[i].GetComponent<AnswerScript4>().isCorrect = false;
        }
        A = Random.Range(100, 999);
        B = Random.Range(100, 999);
        C = Random.Range(100, 999);
        D = Random.Range(100, 999);
        checkDuplicate();

        options[0].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = A.ToString();
        options[1].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = B.ToString();
        options[2].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = C.ToString();
        options[3].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = D.ToString();



    }

    public void checkDuplicate()
    {


        if (numT == A || numT == B || numT == C || numT == D)
        {
            A = Random.Range(100, 999);
            B = Random.Range(100, 999);
            C = Random.Range(100, 999);
            D = Random.Range(100, 999);
            checkDuplicate();
        }
        if (A == B || A == C || A == D || B == C || B == D || C == D)
        {
            A = Random.Range(100, 999);
            B = Random.Range(100, 999);
            C = Random.Range(100, 999);
            D = Random.Range(100, 999);
            checkDuplicate();
        }
    }

    void setRightAnswer()
    {
        AnswerPlace = Random.Range(0, 4);
        QnA[currentQuestion].CorrectAnswer = AnswerPlace;
        options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = numT + "*";

        for (int i = 0; i < options.Length; i++)
        {
            if (QnA[currentQuestion].CorrectAnswer == i)// answers here
            {
                options[i].GetComponent<AnswerScript4>().isCorrect = true;


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


            usedHint = 0;
            usedtemp = 6;
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            options[3].SetActive(true);
            Hint.SetActive(true);

            qcounter++;
            tries = 0;
            Triestxt.text = "Tries: \n"+tries.ToString();
            WrongIdentifier.gameObject.SetActive(false);
            ContinueBtn.SetActive(false);

            randomizer();
            QuestionPhrase.text = QuestionL + " + " + QuestionR + "?";
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
        int maxH = 500;
        int maxF = 1000;

        int numL = Random.Range(0, maxH);
        int numR = Random.Range(0, maxH);

        numT = (numL + numR);

        int ans1 = Random.Range(0, maxF);
        int ans2 = Random.Range(0, maxF);
        int ans3 = Random.Range(0, maxF);
        int ans4 = Random.Range(0, maxF);

        convert(ref numL, ref numR, ref numT, ref ans1, ref ans2, ref ans3, ref ans4);



    }

    // Start of convert num to text module


    private void convert(ref int L, ref int R, ref int T, ref int a, ref int b, ref int c, ref int d)
    {
        string result;

        int num;



        num = L;

        if (ConvertNumberToText(num, out result) == true)

            QuestionL = result;
        //    lbl1st.Text = (num + "  \t" + result);

        num = R;

        if (ConvertNumberToText(num, out result) == true)

            QuestionR = result;

        num = T;

        if (ConvertNumberToText(num, out result) == true)

            QuestionT = result;

        num = a;

        if (ConvertNumberToText(num, out result) == true)

            AnswerA = result;

        num = b;

        if (ConvertNumberToText(num, out result) == true)

            AnswerB = result;

        num = c;

        if (ConvertNumberToText(num, out result) == true)

            AnswerC = result;

        num = d;

        if (ConvertNumberToText(num, out result) == true)

            AnswerD = result;



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




