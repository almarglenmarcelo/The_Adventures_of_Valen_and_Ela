using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TowerProgressionChecker : MonoBehaviour
{
    int floorUnlocked;
    public Animator transition;

    private void Start() 
    {
        floorUnlocked = PlayerPrefs.GetInt("floor");
    }


    public void LoadLatest()
    {
        GameObject sound = GameObject.FindGameObjectWithTag("ButtonSound");
        sound.GetComponent<AudioSource>().Play();

        transition.SetTrigger("Loading");
        StartCoroutine(LoadAsync());
    }

   
   
    public IEnumerator LoadAsync()
    {
        yield return new WaitForSeconds(2f);

        switch (floorUnlocked)
        {
            case 1:
                SceneManager.LoadSceneAsync(9);
                break;
            case 2:
                SceneManager.LoadSceneAsync(10);
                break;
            case 3:
                SceneManager.LoadSceneAsync(11);
                break;
            case 4:
                SceneManager.LoadSceneAsync(12);
                break;
            case 5:
                SceneManager.LoadSceneAsync(13);
                break;
            case 6:
                SceneManager.LoadSceneAsync(14);
                break;
            case 7:
                SceneManager.LoadSceneAsync(15);
                break;
            default:
                SceneManager.LoadSceneAsync(16);
                break;
        }

    }
   


}
