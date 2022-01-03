using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public Animator scrollEffect;
    public Animator bossPlaceEffect;
   
    public void ScrollBoth()
    {
        ScrollHallway();
        ScrollBossPlace();
    }

    public void ScrollHallway()
    {
        StartCoroutine(ScrollMe());
    }

  
    IEnumerator ScrollMe()
    {
        scrollEffect.enabled = true;

        yield return new WaitForSeconds(2.5f);

        scrollEffect.enabled = false ;
    }


    void ScrollBossPlace()
    {
        StartCoroutine(BossPlace());
    }

    IEnumerator BossPlace()
    {
        bossPlaceEffect.enabled = true;

        yield return new WaitForSeconds(2.5f);

    }

}
