using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleToggle : MonoBehaviour
{
    public Sprite[] puzzlePieces;
    public GameObject[] floors;
    public GameObject[] notice;

    public GameObject wholePuzzle;
    public GameObject puzzle;
    public TMPro.TextMeshProUGUI floorOne;
    public TMPro.TextMeshProUGUI floorTwo;
    public TMPro.TextMeshProUGUI floorThree;
    public TMPro.TextMeshProUGUI floorFour;
    public TMPro.TextMeshProUGUI floorFive;
    public TMPro.TextMeshProUGUI floorSix;
    public TMPro.TextMeshProUGUI lastFloor;

    int floor1Value;
    int floor2Value;
    int floor3Value;
    int floor4Value;
    int floor5Value;
    int floor6Value;
    int floor7Value;

    public GameObject puzzlePiece1;
    public GameObject puzzlePiece2;
    public GameObject puzzlePiece3;
    public GameObject puzzlePiece4;
    public GameObject puzzlePiece5;
    public GameObject puzzlePiece6;
    public GameObject puzzlePiece7;


    private int puzzleCount;

    private int puzzle1;
    private int puzzle2;
    private int puzzle3;
    private int puzzle4;
    private int puzzle5;
    private int puzzle6; 
    private int puzzle7;

    private void Awake()
    {
        puzzle1 = PlayerPrefs.GetInt("puzzle1");
        puzzle2 = PlayerPrefs.GetInt("puzzle2");
        puzzle3 = PlayerPrefs.GetInt("puzzle3");
        puzzle4 = PlayerPrefs.GetInt("puzzle4");
        puzzle5 = PlayerPrefs.GetInt("puzzle5");
        puzzle6 = PlayerPrefs.GetInt("puzzle6");
        puzzle7 = PlayerPrefs.GetInt("puzzle7");
    }

    private void Start()
    {
        puzzleCount = PlayerPrefs.GetInt("puzzleCount");
        PuzzleCheck();
        FetchScores();
        ShowFloorImages();
    }
    void FetchScores()
    {

        floor1Value = PlayerPrefs.GetInt("floor1Score");
        floor2Value = PlayerPrefs.GetInt("floor2Score");
        floor3Value = PlayerPrefs.GetInt("floor3Score");
        floor4Value = PlayerPrefs.GetInt("floor4Score");
        floor5Value = PlayerPrefs.GetInt("floor5Score");
        floor6Value = PlayerPrefs.GetInt("floor6Score");
        floor7Value = PlayerPrefs.GetInt("floor7Score");

        //Please Set Endpoints For These
        floorOne.text += floor1Value.ToString();
        floorTwo.text += floor2Value.ToString();
        floorThree.text += floor3Value.ToString();
        floorFour.text += floor4Value.ToString();
        floorFive.text += floor5Value.ToString();
        floorSix.text += floor6Value.ToString();
        lastFloor.text += floor7Value.ToString();

    }

    void ShowFloorImages()
    {
        if(floor1Value == 0)
        {
            floors[0].SetActive(false);
            notice[0].SetActive(true);  //Notice
            notice[1].GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            notice[0].SetActive(false);  //Notice
            notice[1].GetComponent<CanvasGroup>().alpha = 1;
        }


        if (floor2Value == 0)
        {
            floors[1].SetActive(false);
        }
        if (floor3Value == 0)
        {
            floors[2].SetActive(false);
        }
        if (floor4Value == 0)
        {
            floors[3].SetActive(false);
        }
        if (floor5Value == 0)
        {
            floors[4].SetActive(false);
        }
        if (floor6Value == 0)
        {
            floors[5].SetActive(false);
        }
        if (floor7Value == 0)
        {
            floors[6].SetActive(false);
        }
    }
    void PuzzleCheck()
    {
        if(puzzle1 == 1 && puzzle2 == 1 && puzzle3 == 1 && puzzle4 == 1 && puzzle5 == 1 && puzzle6 == 1 && puzzle7 == 1)
        {
            wholePuzzle.SetActive(true);
            puzzle.SetActive(false);
        }

        if(puzzle1 == 1)
        {
            puzzlePiece1.SetActive(true);
        }

        if (puzzle2 == 1)
        {
            puzzlePiece2.SetActive(true);

            

        }

        if (puzzle3 == 1)
        {
            puzzlePiece3.SetActive(true);

            

        }

        if (puzzle4 == 1)
        {
            puzzlePiece4.SetActive(true);

            
        }

        if (puzzle5 == 1)
        {
            puzzlePiece5.SetActive(true);

           
        }

        if (puzzle6 == 1)
        {
            puzzlePiece6.SetActive(true);

            
        }

        if (puzzle7 == 1)
        {
            puzzlePiece7.SetActive(true);

            

        }

    }

 
}
