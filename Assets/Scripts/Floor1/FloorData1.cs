using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData1
{
    public int stars1;
    public bool nextFloor1;
    public bool Costume1;
    public bool Puzzle1;
    public bool Reviewer1;
    


    public FloorData1(QuizManager1 quizManager1)
    {
        stars1 = quizManager1.stars1;
        nextFloor1 = quizManager1.nextFloor1;
        Costume1 = quizManager1.Costume1;
        Puzzle1 = quizManager1.Puzzle1;
        Reviewer1 = quizManager1.Reviewer1;
    }

}
