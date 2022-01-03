using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloorData5
{
    public int stars5;
    public bool nextFloor5;
    public bool Costume5;
    public bool Puzzle5;
    public bool Reviewer5;

    public FloorData5(QuizManager5 quizManager5)
    {
        stars5 = quizManager5.stars5;
        nextFloor5 = quizManager5.nextFloor5;
        Costume5 = quizManager5.Costume5;
        Puzzle5 = quizManager5.Puzzle5;
        Reviewer5 = quizManager5.Reviewer5;
    }

}
