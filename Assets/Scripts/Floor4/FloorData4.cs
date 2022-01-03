using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData4
{
    public int stars4;
    public bool nextFloor4;
    public bool Costume4;
    public bool Puzzle4;
    public bool Reviewer4;

    public FloorData4(QuizManager4 quizManager4)
    {
        stars4 = quizManager4.stars4;
        nextFloor4 = quizManager4.nextFloor4;
        Costume4 = quizManager4.Costume4;
        Puzzle4 = quizManager4.Puzzle4;
        Reviewer4 = quizManager4.Reviewer4;
    }

}
