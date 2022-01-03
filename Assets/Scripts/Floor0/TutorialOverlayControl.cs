using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOverlayControl : MonoBehaviour
{
    //tutorial overalys
    public GameObject Overlay;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject Tutorial4;
    public GameObject Tutorial5;

    public GameObject Floor;
    public GameObject MonsterName;
    public GameObject HpBar;
    public GameObject Sketchpad;
    public GameObject Scores;
    public GameObject ReviewerT;
    public GameObject HintT;
    public GameObject Qnumber;
    public GameObject Qpanel;
    public GameObject Choice;
    public GameObject Tries;
    public GameObject Menu;
    public GameObject Quit;
    public GameObject CorrectT;
    public GameObject WrongT;

    public GameObject Tutorial6;
    public GameObject Tutorial7;
    public GameObject Correct;
    public GameObject Wrong;
    public GameObject Tutorial8;
    public GameObject Tutorial9;
    public GameObject Tutorial10;

    public void OverlayT()
    {
        Overlay.SetActive(false);
    }

        public void Tutorial1T()
    {
        Overlay.SetActive(true);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(true);
    }
    public void Tutorial2T()
    {
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(true);
    }
    public void Tutorial3T()
    {
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(true);
    }
    public void Tutorial4T()
    {
        Tutorial4.SetActive(false);
        StartCoroutine(Tutorial5Timer()); 
    }

    IEnumerator Tutorial5Timer()
    {
        
        yield return new WaitForSeconds(3f);
        Tutorial5.SetActive(true);
    }
    public void Tutorial5T()
    {
        Tutorial5.SetActive(false);
        
        Floor.SetActive(true);
    }

    public void FloorT()
    {
        Floor.SetActive(false);
        MonsterName.SetActive(true);
    }

    public void MonsterT()
    {
        MonsterName.SetActive(false);
        HpBar.SetActive(true);
    }


    public void HpT()
    {
        HpBar.SetActive(false);
        Sketchpad.SetActive(true);
    }
    public void SketchpadT()
    {
        Sketchpad.SetActive(false);
        Scores.SetActive(true);
    }
    public void ScoresT()
    {
        Scores.SetActive(false);
        ReviewerT.SetActive(true);
    }
    public void ReviewerTT()
    {
        ReviewerT.SetActive(false);
        HintT.SetActive(true);
    }

    public void HintTT()
    {
        HintT.SetActive(false);
        Qnumber.SetActive(true);
    }
    public void QnumberT()
    {
        Qnumber.SetActive(false);
        Qpanel.SetActive(true);
    }
    public void QpanelT()
    {
        Qpanel.SetActive(false);
        Choice.SetActive(true);
    }
    public void ChoiceT()
    {
        Choice.SetActive(false);
        Tries.SetActive(true);
    }

    public void TriesT()
    {
        Tries.SetActive(false);
        Menu.SetActive(true);
    }
    public void MenuT()
    {
        Menu.SetActive(false);
        Quit.SetActive(true);
    }
    public void QuitT()
    {
        Quit.SetActive(false);
        Tutorial6.SetActive(true);
    }
    public void Tutorial6T()
    {
        Tutorial6.SetActive(false);
        Tutorial7.SetActive(true);
    }
    public void Tutorial7T()
    {
        Tutorial7.SetActive(false);
        OverlayT();
        
    }
    public void CorrectF()
    {
        CorrectT.SetActive(false);
    }
    public void WrongF()
    {
        WrongT.SetActive(false);
    }
    public void Tutorial8T()
    {
        Tutorial8.SetActive(false);
        Tutorial9.SetActive(true);
    }
    public void Tutorial9T()
    {
        Tutorial9.SetActive(false);
        Tutorial10.SetActive(true);
    }
    public void Tutorial10T()
    {
        Tutorial10.SetActive(false);
       
    }
}
