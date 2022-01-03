using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData6
{
    public int stars6;
    public bool nextFloor6;
    public bool Costume6;
    public bool Puzzle6;
    public bool Reviewer6;

    public FloorData6(QuizManager6 quizManager6)
    {
        stars6 = quizManager6.stars6;
        nextFloor6 = quizManager6.nextFloor6;
        Costume6 = quizManager6.Costume6;
        Puzzle6 = quizManager6.Puzzle6;
        Reviewer6 = quizManager6.Reviewer6;
    }

}
