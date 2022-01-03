using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReviewerPrefs : MonoBehaviour
{
    //public Button reviewer1;
    public Button reviewer1;
    public Sprite reviewer1Unlock;

    public Button reviewer2;
    public Sprite reviewer2Unlock;

    public Button reviewer3;
    public Sprite reviewer3Unlock;

    public Button reviewer4;
    public Sprite reviewer4Unlock;

    public Button reviewer5;
    public Sprite reviewer5Unlock;

    public Button reviewer6;
    public Sprite reviewer6Unlock;

    public Button reviewer7;
    public Sprite reviewer7Unlock;
    

    private void Start()
    {

        FloorData0 data0 = SaveSystem0.LoadPlayer0();
        FloorData1 data1 = SaveSystem1.LoadPlayer1();
        FloorData2 data2 = SaveSystem2.LoadPlayer2();
        FloorData3 data3 = SaveSystem3.LoadPlayer3();
        FloorData4 data4 = SaveSystem4.LoadPlayer4();
        FloorData5 data5 = SaveSystem5.LoadPlayer5();
        FloorData6 data6 = SaveSystem6.LoadPlayer6();

        //SetReviewerPrefs("reviewer2", "lockReviewer2");
        //SetReviewerPrefs("reviewer3", "lockReviewer3");
        //SetReviewerPrefs("reviewer4", "lockReviewer4");
        //SetReviewerPrefs("reviewer5", "lockReviewer5");
        //SetReviewerPrefs("reviewer6", "lockReviewer6");
        //SetReviewerPrefs("reviewer7", "lockReviewer7");

        
        if (data0.Reviewer0 ==true)
        {
            reviewer1.image.sprite = reviewer1Unlock;
            reviewer1.image.raycastTarget = true;
        }

        if (data1.Reviewer1 == true)
        {
            reviewer2.image.sprite = reviewer2Unlock;
            reviewer2.image.raycastTarget = true;
            //Debug.Log(GetReviewerPrefs("reviewer2"));
        }

        if (data2.Reviewer2 == true)
        {
            reviewer3.image.sprite = reviewer3Unlock;
            reviewer3.image.raycastTarget = true;
            //Debug.Log(GetReviewerPrefs("reviewer3"));
        }

        if (data3.Reviewer3 == true)
        {
            reviewer4.image.sprite = reviewer4Unlock;
            reviewer4.image.raycastTarget = true;
            //Debug.Log(GetReviewerPrefs("reviewer4"));
        }

        if (data4.Reviewer4 == true)
        {
            reviewer5.image.sprite = reviewer5Unlock;
            reviewer5.image.raycastTarget = true;
            //Debug.Log(GetReviewerPrefs("reviewer5"));
        }

        if (data5.Reviewer5 == true)
        {
            reviewer6.image.sprite = reviewer6Unlock;
            reviewer6.image.raycastTarget = true;
            //Debug.Log(GetReviewerPrefs("reviewer6"));
        }

        if (data6.Reviewer6 == true)
        {
            reviewer7.image.sprite = reviewer7Unlock;
            reviewer7.image.raycastTarget = true;
            //Debug.Log(GetReviewerPrefs("reviewer7"));
        }
        
    }
    private string GetReviewerPrefs(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    public void SetReviewerPrefs(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    
    private void LockReviewer()
    {
        SetReviewerPrefs("reviewer2", "lock");
        SetReviewerPrefs("reviewer3", "lock");
        SetReviewerPrefs("reviewer4", "lock");
        SetReviewerPrefs("reviewer5", "lock");
        SetReviewerPrefs("reviewer6", "lock");
        SetReviewerPrefs("reviewer7", "lock");
    }

}
