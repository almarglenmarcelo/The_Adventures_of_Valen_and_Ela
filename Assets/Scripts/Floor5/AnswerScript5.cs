using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript5 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager5 quizManager;
    public void Answer()
    {
        if (isCorrect)
        {
            GameObject correctSfx = GameObject.FindGameObjectWithTag("CorrectSFX");
            correctSfx.GetComponent<AudioSource>().Play();
            Debug.Log("Correct answer");
            quizManager.correct();
        }
        else
        {
            GameObject wrongSfx = GameObject.FindGameObjectWithTag("WrongSFX");
            wrongSfx.GetComponent<AudioSource>().Play();
            Debug.Log("Wrong answer");
            quizManager.wrong();
        }
    }

}
