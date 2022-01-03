using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData0
{
    public int stars0;
    public bool nextFloor0;
    public bool Costume0;
    public bool Puzzle0;
    public bool Reviewer0;
    


    public FloorData0(QuizManager0 quizManager0)
    {
        stars0 = quizManager0.stars0;
        nextFloor0 = quizManager0.nextFloor0;
        Costume0 = quizManager0.Costume0;
        Puzzle0 = quizManager0.Puzzle0;
        Reviewer0 = quizManager0.Reviewer0;
    }

}
