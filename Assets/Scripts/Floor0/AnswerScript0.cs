using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript0 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager0 quizManager;
    
    
    public void Answer()
    {
        if (isCorrect)
        {
            GameObject correctSfx = GameObject.FindGameObjectWithTag("CorrectSFX");
            correctSfx.GetComponent<AudioSource>().Play();
            quizManager.correct();
            Debug.Log("Correct answer");
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
