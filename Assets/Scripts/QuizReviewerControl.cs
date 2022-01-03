using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizReviewerControl : MonoBehaviour
{
    GameObject[] quizPages;
    int counterNext = 1;
    int counterPrev = 0;

    private void Start()
    {

        quizPages = GameObject.FindGameObjectsWithTag("QuizPages");

        foreach (GameObject c in quizPages)
        {
            c.SetActive(false);
        }

        quizPages[counterPrev].SetActive(true); // counterPrev : 0

        Debug.Log("Next:" + counterNext);
        Debug.Log("Prev:" + counterPrev);
    }
    public void ShowNextPage()
    {
        GameObject sound = GameObject.FindGameObjectWithTag("ButtonSound");
        sound.GetComponent<AudioSource>().Play();

        quizPages[counterPrev].SetActive(false);
        quizPages[counterNext].SetActive(true);

        counterNext += 1;
        counterPrev += 1;

        Debug.Log("Next:" + counterNext);
        Debug.Log("Prev:" + counterPrev);
    }

    public void ShowPreviousPage()
    {
        GameObject sound = GameObject.FindGameObjectWithTag("ButtonSound");
        sound.GetComponent<AudioSource>().Play();
        quizPages[counterPrev - 1].SetActive(true);
        quizPages[counterNext - 1].SetActive(false);

        counterNext -= 1;
        counterPrev -= 1;

        if (counterPrev < 0)
        {
            counterNext = 1;
            counterPrev = 0;
        }

        Debug.Log("Next:" + counterNext);
        Debug.Log("Prev:" + counterPrev);
    }
    public void ShowThisOverlay(GameObject overview)
    {
        overview.SetActive(true);
    }
    public void HideThisOverlay(GameObject overview)
    {
        overview.SetActive(false);
    }

}
