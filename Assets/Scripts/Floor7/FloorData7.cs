using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData7
{
    public int stars7;
    public bool nextFloor7;
    public bool Costume7;
    public bool Puzzle7;
    public bool Reviewer7;

    public FloorData7(QuizManager7 quizManager7)
    {
        stars7 = quizManager7.stars7;
        nextFloor7 = quizManager7.nextFloor7;
        Costume7 = quizManager7.Costume7;
        Puzzle7 = quizManager7.Puzzle7;
        Reviewer7 = quizManager7.Reviewer7;
    }

}
