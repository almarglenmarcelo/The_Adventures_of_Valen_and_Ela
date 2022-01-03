using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData2
{
    public int stars2;
    public bool nextFloor2;
    public bool Costume2;
    public bool Puzzle2;
    public bool Reviewer2;

    public FloorData2(QuizManager2 quizManager2)
    {
        stars2 = quizManager2.stars2;
        nextFloor2 = quizManager2.nextFloor2;
        Costume2 = quizManager2.Costume2;
        Puzzle2 = quizManager2.Puzzle2;
        Reviewer2 = quizManager2.Reviewer2;
    }

}
