using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarRating : MonoBehaviour
{
    public Sprite noStar;
    public Sprite oneStar;
    public Sprite twoStar;
    public Sprite threeStar;

    public Animator[] bouncing;
    public Animator tutorialLabel;

    public GameObject[] floorLevels;

    private void Start()
    {
        if (PlayerPrefs.GetInt("floor0Score") >= 1)
        {
            tutorialLabel.enabled = false;
        }

       

    }

    private void Update()
    {
        SetFloorStars(0);   //Tutorial Level
        SetFloorStars(1);   //Level One
        SetFloorStars(2);   //Level Two
        SetFloorStars(3);   //Level Three
        SetFloorStars(4);   //Level Four
        SetFloorStars(5);   //Level Five
        SetFloorStars(6);   //Level Six
        SetFloorStars(7);   //Level Seven
    }



    void SetFloorStars(int floorLevel)
    {
        int floorScore = PlayerPrefs.GetInt("floor"+ floorLevel +"Score");

       

        if (floorScore >= 1 && floorScore <= 7)
        {
            floorLevels[floorLevel].GetComponent<Image>().sprite = oneStar;
            bouncing[floorLevel].enabled = true;
        }
       
        else  if (floorScore >= 8 && floorScore <= 11)
        {
            floorLevels[floorLevel].GetComponent<Image>().sprite = twoStar;
            bouncing[floorLevel].enabled = true;
        }

        else if (floorScore >= 12 && floorScore <= 15)

        {
            floorLevels[floorLevel].GetComponent<Image>().sprite = threeStar;
            bouncing[floorLevel].enabled = true;
        }

        else
        {
            floorLevels[floorLevel].GetComponent<Image>().sprite = noStar;
            floorLevels[floorLevel].SetActive(false);
        }

    }

}
