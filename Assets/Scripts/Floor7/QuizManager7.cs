using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager7 : MonoBehaviour
{
    public List<QuestionAnswer7> QnA;
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

    //money assets

    //coins
    public Image Coincanvas;
    public Sprite Onecent;
    public Sprite Fivecent;
    public Sprite Twentyfivecent;
    public Sprite OnePeso;
    public Sprite FivePeso;
    public Sprite TenPeso;
    //bills
    public Image Billcanvas;
    public Sprite TwentyPeso;
    public Sprite FiftyPeso;
    public Sprite OneHundredPeso;
    public Sprite TwoHundredPeso;
    public Sprite FiveHundredPeso;
    public Sprite OneThousand;

    public static System.Random random;

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

    int A;
    int B;
    int C;
    int D;

    int decider;

    int rand;
    int randq;
    int ord;
    int i;

    int hints = 10;
    int usedtemp;
    int usedHint;

    int AnswerPlace;
    string QuestionT;

    int WA;
    int WB;
    int WC;
    int WD;

    //randomizer
    int t0;
    int t1;
    int t2;
    int t3;
    int t4;
    int t5;
    int t6;
    int t7;
    int t8;
    int t9;
    int t10;
    int t11;
    int timp = 0;

    //xml variables
    public int stars7;
    public bool nextFloor7;
    public bool Costume7;
    public bool Puzzle7;
    public bool Reviewer7;

    int[] SelectedNumbers;


 

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
        

        if (GetLevelPrefs("NewSave7") == "7")
        {
            LoadPlayer7();
        }
        else
        {
            SetLevelPrefs("NewSave7", "7");
            stars7 = 0;
            Reviewer7 = false;
            nextFloor7 = false;
            Costume7 = false;
            Puzzle7 = false;
            SaveSystem7.SavePlayer7(this);
            LoadPlayer7();

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

    //Removes numbers from the array until only one is left, and returns it
    public static int GetNumber(int[] arr)
    {
        if (arr.Length > 1)
        {
            //Remove random number from array
            var r = random.Next(0, arr.Length);
            var list = arr.ToList();
            list.RemoveAt(r);

            return GetNumber(list.ToArray());
        }

        return arr[0];
    }
    public void SavePlayer7()
    {

        FloorData7 data = SaveSystem7.LoadPlayer7();
        if (stars7 > data.stars7)
        {
            SaveSystem7.SavePlayer7(this);
        }
        else
        {
            Debug.Log("SavePlayer7 catch");

        }


    }
    public void SavePlayerReset7()
    {
        SetLevelPrefs("NewSave7", "7");
        stars7 = 0;
        Reviewer7 = false;
        nextFloor7 = false;
        Costume7 = false;
        Puzzle7 = false;
        SaveSystem7.SavePlayer7(this);
    }
    public void LoadPlayer7()
    {


        FloorData7 data = SaveSystem7.LoadPlayer7();


        //Data debug
        Debug.Log("Stars = " + data.stars7.ToString() + " Floor = " + data.nextFloor7.ToString() + " Costume = " + data.Costume7.ToString() + " Puzzle = " + data.Puzzle7.ToString() + " Reviewer = " + data.Reviewer7.ToString());

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
    //    floorPrefs.SetLevelPrefs("level7", "unlockLevel7");
    //}

    ////Unlock Only Reviewer 4
    //private void UnlockNextReviewer()
    //{
    //    reviewerPrefs.SetReviewerPrefs("reviewer7", "unlockReviewer7");
    //}
    //private void UnlockCostume()
    //{
    //    costumePrefs.SetCostumePrefs("costume7", 1);
    //}

    private void PuzzleCount(int count)
    {
        PlayerPrefs.SetInt("puzzleCount", count);
    }

    private void SeventhPuzzlePiece()
    {
        PlayerPrefs.SetInt("puzzle7", 1);
    }
    IEnumerator GameOver()
    {
        Wrong.SetActive(false);
        Right.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        //UnlockNextLevel();
        //UnlockNextReviewer();

        PlayerPrefs.SetInt("floor7Score", score);

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
            stars7 = 0;
            Reviewer7 = false;
            nextFloor7 = false;
            Costume7 = false;
            Puzzle7 = false;

            SavePlayer7();
        }

        if (score <= 3 && score >= 1)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel1.SetActive(true);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars7 = 1;
            Reviewer7 = true;
            nextFloor7 = true;
            Costume7 = false;
            Puzzle7 = false;

            SavePlayer7();
        }

        if (score <= 7 && score >= 4)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel2.SetActive(true);
            //UnlockCostume();
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars7 = 2;
            Reviewer7 = true;
            nextFloor7 = true;
            Costume7 = true;
            Puzzle7 = false;

            SavePlayer7();
        }
        if (score <= 10 && score >= 8)
        {
            poseVictory();
            Wrong.SetActive(false);
            Right.SetActive(false);
            yield return new WaitForSeconds(3f);
            GoPanel3.SetActive(true);
            PlayerPrefs.SetInt("puzzleCount", 7);
            backgroundMusic.mute = true;
            rewardsSfx.Play();

            //xml variables
            stars7 = 3;
            Reviewer7 = true;
            nextFloor7 = true;
            Costume7 = true;
            Puzzle7 = true;

            //UnlockCostume();
            PuzzleCount(7);
            SeventhPuzzlePiece();
            SavePlayer7();
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
        if (qcounter < 7)
        {
            yield return new WaitForSeconds(2f);
            poseRun();
        }
        if (qcounter != 10)
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

        if (qcounter >= 6 && qcounter < 10)
        {
            playerDamage = 20;
        }
        else if (qcounter == 10)
        {
            playerDamage = 100;
        }
        else
        {
            playerDamage = 100;
        }
        CorrectAnswerAnimation();
        if (qcounter != 10)
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
            if (qcounter == 10)
            {
                enemydmg = 100;
            }
            else
            {
                enemydmg = 6;
            }
            health = health - enemydmg;
            
            QuestionPhrase.gameObject.SetActive(false);
            Coincanvas.gameObject.SetActive(false);
            Billcanvas.gameObject.SetActive(false);
            WrongIdentifier.gameObject.SetActive(true);
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




        if (qcounter != 1 && qcounter <= 6)
        {


            enemyDisplay.GetComponent<Image>().sprite = monsterSpritesDead[monsterInc - 1];
            StartCoroutine(EnemyAnimationTimer());

        }

        else if (qcounter >= 7)
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

        if (qcounter == 7)
        {
            enemyHealth = 100;
        }

        if (qcounter >= 7)
        {
            meleeCombat_Enemy.animator.SetBool("Boss_Fight", true);
            enemyDisplay.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(75, 75);
            Enemyicon.GetComponent<Image>().sprite = monsterSprites[4];
            enemyDisplay.GetComponent<Image>().sprite = monsterSpritesAlive[4];

            monsterText.text = "Boss Slime";
            scrollScript.GetComponent<ScrollScript>().ScrollBoth();
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
            scrollScript.GetComponent<ScrollScript>().ScrollHallway();
        }
    }

    public void continueGame()
    {
        Choices.SetActive(true);
        QnA.RemoveAt(currentQuestion);
        QuestionPhrase.gameObject.SetActive(true);
        Coincanvas.gameObject.SetActive(true);
        Billcanvas.gameObject.SetActive(true);

        generateQuestion();
    }



    void setWrongAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript7>().isCorrect = false;
        }


        QuizManager7 n = new QuizManager7();


        A = Random.Range(0, 12);
        B = Random.Range(0, 12);
        C = Random.Range(0, 12);
        D = Random.Range(0, 12);
        checkDuplicate();


        string[] str = { "1 Cent", "5 Cents", "25 Cents", "₱1", "₱5", "₱10", "₱20", "₱50", "₱100", "₱200", "₱500", "₱1000" };

        string WA = str[A];
        string WB = str[B];
        string WC = str[C];
        string WD = str[D];

        options[0].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = WA;
        options[1].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = WB;
        options[2].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = WC;
        options[3].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = WD;



        //options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];


    }
    public void checkDuplicate()
    {
        

        if (decider == A || decider == B || decider == C || decider == D)
        {
            A = Random.Range(0, 12);
            B = Random.Range(0, 12);
            C = Random.Range(0, 12);
            D = Random.Range(0, 12);
            checkDuplicate();
        }
         if (A == B || A == C|| A == D || B == C || B == D||C == D)
        {
            A = Random.Range(0, 12);
            B = Random.Range(0, 12);
            C = Random.Range(0, 12);
            D = Random.Range(0, 12);
            checkDuplicate();
        }
    }


    void setRightAnswer()
    {

        AnswerPlace = Random.Range(0, 4);
        QnA[currentQuestion].CorrectAnswer = AnswerPlace;
        options[AnswerPlace].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QuestionT + "*";

        for (int i = 0; i < options.Length; i++)
        {
            if (QnA[currentQuestion].CorrectAnswer == i)// answers here
            {
                options[i].GetComponent<AnswerScript7>().isCorrect = true;


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


            qcounter++;
            tries = 0;
            //hint
            usedHint = 0;
            usedtemp = 6;
            Hint.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Hints: " + hints;
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            options[3].SetActive(true);
            Hint.SetActive(true);

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

    public void imageChange()
    {
        
        


       if (decider == t0 || decider==t1 || decider == t2 || decider == t3 || decider == t4 || decider == t5 || decider == t6 || decider == t7 || decider == t8 || decider == t9 || decider == t10 || decider == t11)
        {
            decider = Random.Range(0, 12);
            imageChange();
            timp++;
            Debug.Log(timp);
        }
        
           
           
        switch (decider)
        {
            //coins
            case 0:
                Coincanvas.gameObject.SetActive(true);
                Billcanvas.gameObject.SetActive(false);
                Coincanvas.sprite = Onecent;
                t0 = 0;
                QuestionT = "1 Cent";
            break;

            case 1:
                Coincanvas.gameObject.SetActive(true);
                Billcanvas.gameObject.SetActive(false);
                Coincanvas.sprite = Fivecent;
                t1 = 1;
                QuestionT = "5 Cents";
                break;
            case 2:
                Coincanvas.gameObject.SetActive(true);
                Billcanvas.gameObject.SetActive(false);
                Coincanvas.sprite = Twentyfivecent;
                t2 = 2;
                QuestionT = "25 Cents";
                break;
            case 3:
                Coincanvas.gameObject.SetActive(true);
                Billcanvas.gameObject.SetActive(false);
                Coincanvas.sprite = OnePeso;
                t3 = 3;
                QuestionT = "₱1";
                break;
            case 4:
                Coincanvas.gameObject.SetActive(true);
                Billcanvas.gameObject.SetActive(false);
                Coincanvas.sprite = FivePeso;
                t4 = 4;
                QuestionT = "₱5";
                break;
            case 5:
                Coincanvas.gameObject.SetActive(true);
                Billcanvas.gameObject.SetActive(false);
                Coincanvas.sprite = TenPeso;
                t5 = 5;
                QuestionT = "₱10";
                break;
                //bills
            case 6:
                Coincanvas.gameObject.SetActive(false);
                Billcanvas.gameObject.SetActive(true);
                Billcanvas.sprite = TwentyPeso;
                t6 = 6;
                QuestionT = "₱20";
                break;
            case 7:
                Coincanvas.gameObject.SetActive(false);
                Billcanvas.gameObject.SetActive(true);
                Billcanvas.sprite = FiftyPeso;
                t7 =7;
                QuestionT = "₱50";
                break;
            case 8:
                Coincanvas.gameObject.SetActive(false);
                Billcanvas.gameObject.SetActive(true);
                Billcanvas.sprite = OneHundredPeso;
                t8 = 8;
                QuestionT = "₱100";
                break;
            case 9:
                Coincanvas.gameObject.SetActive(false);
                Billcanvas.gameObject.SetActive(true);
                Billcanvas.sprite = TwoHundredPeso;
                t9 = 9;
                QuestionT = "₱200";
                break;
            case 10:
                Coincanvas.gameObject.SetActive(false);
                Billcanvas.gameObject.SetActive(true);
                Billcanvas.sprite = FiveHundredPeso;
                t10 = 10;
                QuestionT = "₱500";
                break;
            case 11:
                Coincanvas.gameObject.SetActive(false);
                Billcanvas.gameObject.SetActive(true);
                Billcanvas.sprite = OneThousand;
                t11 = 11;
                QuestionT = "₱1000";
                break;
        

        }


    }

    public void randomizer()
    {
        decider = Random.Range(0, 12);

        imageChange();


        // return extension;
        QuestionPhrase.text ="How much is this?";



        
        
       


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

