using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager0 : MonoBehaviour
{
    public List<QuestionAnswer0> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject scrollScript;

    FloorLevelPrefs floorPrefs = new FloorLevelPrefs();
    ReviewerPrefs reviewerPrefs = new ReviewerPrefs();
    CostumePrefs costumePrefs = new CostumePrefs();
    FloorData0 floorData0;

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

    public GameObject enemyDisplay;

    
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
    public TMPro.TextMeshProUGUI Plus;
    public TMPro.TextMeshProUGUI Stars;

    public TMPro.TextMeshProUGUI Health;


    public TMPro.TextMeshProUGUI WrongIdentifier;


    public GameObject costumeUnlocked;
    public GameObject puzzlePiece;
    public GameObject Quizpanel;
    public GameObject GoPanel0;
    public GameObject GoPanel1;
    public GameObject GoPanel2;
    public GameObject GoPanel3;
    public GameObject Bundles;
    public GameObject ContinueBtn;
    public GameObject AnimationOverlay;

    public Image enemyImage;
    public Sprite enemyAlive;
    public Sprite enemyDead;

    public GameObject Hint;

    //reviewers

    public GameObject Reviewer;

    public GameObject ReviewerOV;


    public GameObject Choices;


    public GameObject Play;
    public GameObject Right;
    public GameObject Wrong;

    //tutorial GameObjects
    
    public GameObject CorrectT;
    public GameObject WrongT;
    public GameObject Tutorial1;
    public GameObject Tutorial8;

    int totalQuestions = 0;
    int score;


    int qcounter = 0;
    int tries = 0;
    
    int AnswerPlace;
    string QuestionT;
    int hints;
    int usedtemp;

    public int playerDamage = 100;
    public float health = 100f;
    public float enemyHealth = 100f;

    //xml variables
    public int stars0;
    public bool nextFloor0;
    public bool Costume0;
    public bool Puzzle0;
    public bool Reviewer0;


    

    private void Awake()
    {
        enemyDisplay = GameObject.FindGameObjectWithTag("EnemyDisplay");


    }

    private void Start()
    {
        EquipCostume();


        totalQuestions = QnA.Count;
        Tutorial1.SetActive(true);
        SetLevelPrefs("FirstCorrect", "0");
        SetLevelPrefs("FirstWrong", "0");
         GoPanel0.SetActive(false);
        GoPanel1.SetActive(false);
        GoPanel2.SetActive(false);
        GoPanel3.SetActive(false);
        ContinueBtn.SetActive(false);



        if (GetLevelPrefs("NewSave0") == "0")
        {
            LoadPlayer0();
        }
        else
        {
            SavePlayerReset0();
            LoadPlayer0();

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
    public void SavePlayer0()
    {

        FloorData0 data = SaveSystem0.LoadPlayer0();
        if (stars0 > data.stars0)
        {
            SaveSystem0.SavePlayer0(this);
        }
        else
        {
            Debug.Log("SavePlayer0 catch");
        }

    }

    public void SavePlayerReset0()
    {
        SetLevelPrefs("NewSave0", "0");
        stars0 = 0;
        Reviewer0 = false;
        nextFloor0 = false;
        Costume0 = false;
        Puzzle0 = false;
        SaveSystem0.SavePlayer0(this);
    }
    public void LoadPlayer0()
    {

        FloorData0 data = SaveSystem0.LoadPlayer0();

        //Data debug
        Debug.Log("Stars = " + data.stars0.ToString() + " Floor = " + data.nextFloor0.ToString() + " Costume = " + data.Costume0.ToString() + " Puzzle = " + data.Puzzle0.ToString() + " Reviewer = " + data.Reviewer0.ToString());

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

    ////Unlock only level 2
    //private void UnlockNextLevel()
    //{
    //    floorPrefs.SetLevelPrefs("level1", "unlockLevel1");
    //}
    ////Unlock only Reviewer 2
    //private void UnlockNextReviewer()
    //{
    //    reviewerPrefs.SetReviewerPrefs("reviewer1", "unlockReviewer1");
    //}
    //private void UnlockCostume()
    //{
    //    costumePrefs.SetCostumePrefs("costume1", 1);
    //}

    IEnumerator GameOver()
    {

        PlayerPrefs.SetInt("floor", 1);             //Used to determine which floor must play when Start Button is clicked in the lobby
        PlayerPrefs.SetInt("floor0Score", score);
        yield return new WaitForSeconds(1.5f);
        //UnlockNextLevel();
        //UnlockNextReviewer();

        if (score == 0)
        {
            poseDefeat();
            yield return new WaitForSeconds(3f);
            GoPanel0.SetActive(true);
            backgroundMusic.mute = true;
            defeatSFX.Play();

            //xml variables
            stars0 = 0;
            Reviewer0 = false;
            nextFloor0 = false;
            Costume0 = false;
            Puzzle0 = false;
            SavePlayer0();

           
        }

        if (score <= 2 && score >= 1)
        {
            poseVictory();
            yield return new WaitForSeconds(3f);
            GoPanel1.SetActive(true);
            backgroundMusic.mute = true;
            rewardsSfx.Play();
            //xml variables
            stars0 = 1;
            Reviewer0 = true;
            nextFloor0 = true;
            Costume0 = false;
            Puzzle0 = false;
           
            SavePlayer0();
        }

        if (score == 3)
        {
            poseVictory();
            yield return new WaitForSeconds(3f);
            //xml variables
            stars0 = 2;
            Reviewer0 = true;
            nextFloor0 = true;
            Costume0 = true;
            Puzzle0 = false;

            GoPanel2.SetActive(true);
            //UnlockCostume();
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            SavePlayer0();
        }


        if (score == 4 )
        {
            poseVictory();
            yield return new WaitForSeconds(3f);
            GoPanel3.SetActive(true);
            PlayerPrefs.SetInt("puzzleCount", 1);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars0 = 3;
            Reviewer0 = true;
            nextFloor0 = true;
            Costume0 = true;
            Puzzle0 = true;

            //UnlockCostume();

            SavePlayer0();
            

        }

        Tutorial8.SetActive(true);
        

    }


    public void continueGame()
    {
        Choices.SetActive(true);
       
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    public void CorrectAnswerAnimation()
    {
        poseAttack();
        meleeCombat_Valen.CharacterAttack();
        meleeCombat_Enemy.EnemyHurt();
        StartCoroutine(equipDelay());

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
        
        poseHit();
        StartCoroutine(equipDelay());
    }
    IEnumerator equipDelay()
    {
        yield return new WaitForSeconds(1f);
        EquipCostume();
    }
    public void correct()
    {
        CorrectAnswerAnimation();
        
        enemyHealth = enemyHealth - playerDamage;
        score += 1;
        
        CurrentScore.text = score.ToString();
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(CorrectTimer());
        generateQuestion();


        if(enemyHealth == 0)
        {
            enemyImage.sprite = enemyDead;
        }


        if (GetLevelPrefs("FirstCorrect") =="0")
        {
            CorrectT.SetActive(true);
            SetLevelPrefs("FirstCorrect", "1");
        }
    }

    IEnumerator CorrectTimer()
    {
        AnimationOverlay.SetActive(true);
        Right.SetActive(true);
        yield return new WaitForSeconds(3f);
        enemyHealth = 100;
        enemyImage.sprite = enemyAlive;
        Right.SetActive(false);
        AnimationOverlay.SetActive(false);
    }
    IEnumerator WrongTimer()
    {
        AnimationOverlay.SetActive(true);
        Wrong.SetActive(true);
        yield return new WaitForSeconds(1f);
        AnimationOverlay.SetActive(false);
        Wrong.SetActive(false);
    }

    public void wrong()
    {
        tries++;

        

        Triestxt.text = "Tries: \n" + tries.ToString();
        if (GetLevelPrefs("FirstWrong") == "0")
        {
            WrongT.SetActive(true);
            SetLevelPrefs("FirstWrong", "1");
        }
        Wrong.SetActive(true);
        
        //Health.text = health.ToString();
        
        if(tries == 1 && score == 0 && qcounter == 4)
        {
            int i = QnA[currentQuestion].CorrectAnswer - 1;
            options[0].gameObject.SetActive(false);
            options[1].gameObject.SetActive(false);
            options[2].gameObject.SetActive(false);
            options[3].gameObject.SetActive(false);
            options[i].gameObject.SetActive(true);
        }
        else if (tries == 2)
        {
            WrongAnswerAnimation();
            int i=QnA[currentQuestion].CorrectAnswer -1;
            health = health - 6;
            WrongIdentifier.gameObject.SetActive(true);
            WrongIdentifier.text = "The correct answer is: " + options[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text;
            QuestionPhrase.gameObject.SetActive(false);
            Choices.SetActive(false);
            ContinueBtn.SetActive(true);
            Hint.SetActive(false);
            StartCoroutine(enemyDeadDelay());
        }

        StartCoroutine(WrongTimer());

    }

    IEnumerator enemyDeadDelay()
    {
        yield return new WaitForSeconds(2f);
    }



    public void hint()
    {



        int temp = Random.Range(0, 4);
        AnswerPlace = QnA[currentQuestion].CorrectAnswer - 1;
        while (temp == AnswerPlace)
        {
            temp = Random.Range(0, 4);
        }
        if (temp != AnswerPlace)

        {
            hints--;
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
            options[temp].SetActive(false);

        }
        if (hints == 0)
        {
            Hint.SetActive(false);
        }
    }


    void setWrongAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript0>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript0>().isCorrect = true;
            }
        }

        


    }

    void generateQuestion()
    {
        if (QnA.Count > 0 && QnA.Count <= 5)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            int tempqcount= qcounter +1;
            CurrentQuestiontxt.text = "Question " + tempqcount.ToString();

            QuestionPhrase.text = QnA[currentQuestion].Question;
            qcounter++;
            tries = 0;
            hints = 1;
            
            Triestxt.text = "Tries: \n" + tries.ToString();
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;

            QuestionPhrase.gameObject.SetActive(true);
            Hint.SetActive(true);
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            options[3].SetActive(true);
            WrongIdentifier.gameObject.SetActive(false);
            ContinueBtn.SetActive(false);

            setWrongAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");

            StartCoroutine(GameOver());

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




