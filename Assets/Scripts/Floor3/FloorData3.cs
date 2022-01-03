using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData3
{
    public int stars3;
    public bool nextFloor3;
    public bool Costume3;
    public bool Puzzle3;
    public bool Reviewer3;

    public FloorData3(QuizManager3 quizManager3)
    {
        stars3 = quizManager3.stars3;
        nextFloor3 = quizManager3.nextFloor3;
        Costume3 = quizManager3.Costume3;
        Puzzle3 = quizManager3.Puzzle3;
        Reviewer3 = quizManager3.Reviewer3;
    }

}
