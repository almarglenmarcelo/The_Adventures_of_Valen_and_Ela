using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript7 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager7 quizManager;
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
            GameObject correctSfx = GameObject.FindGameObjectWithTag("WrongSFX");
            correctSfx.GetComponent<AudioSource>().Play();
            Debug.Log("Wrong answer");
            quizManager.wrong();
        }
    }

}
