using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimationLoader : MonoBehaviour
{

    public AudioSource startSFX;
    public Animator transition;
    public float transitiontime = 1f;
    int lobbyBuildIndex = 8;

    Toggle toggle;


    

    //Load Lobby from Cutscene
    public void StartFromCutscene()
    {
        transition.SetTrigger("Loading");
        startSFX.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("newPlayer", 1);
        StartCoroutine(CutsceneLoad());
    }

    IEnumerator CutsceneLoad()
    {

        yield return new WaitForSeconds(transitiontime);

        AsyncOperation async = SceneManager.LoadSceneAsync(lobbyBuildIndex);

        while ( !async.isDone )
        {
            transition.SetTrigger( "Loading" );
            yield return new WaitForSeconds(transitiontime);
            yield return null;
        }

    }


  
    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Exitting App");
    }


    public void StartGame()
    {
        startSFX.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(5f);

        if (PlayerPrefs.GetInt("characterSelected") == 1)
        {
           
            AsyncOperation async = SceneManager.LoadSceneAsync(lobbyBuildIndex);

            
            while (!async.isDone)
            {
                yield return new WaitForSeconds(1f);
                yield return null;
            }
        }

        else
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    public void LoadLobbyFromQuiz()
    {
        transition.SetTrigger("Loading");
        startSFX.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadLobby());

    }
    IEnumerator LoadLobby()
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitiontime);

        AsyncOperation async = SceneManager.LoadSceneAsync(lobbyBuildIndex);

        while (!async.isDone)
        {
            yield return new WaitForSeconds(transitiontime);
            yield return null;
        }


    }

    void PlaySound()
    {
        startSFX.Play();
    }
    

    public void LoadNextLevel()
    {
        PlaySound();
        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(transitiontime);
        startSFX.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void LoadPreviousScene()
    {
        PlaySound();
        StartCoroutine(LoadPrevious());
    }

    IEnumerator LoadPrevious()
    {
        yield return new WaitForSeconds(transitiontime);
        startSFX.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void LoadQuizGame()
    {
        if(PlayerPrefs.GetInt("newPlayer") == 1)
        {
            Debug.Log("PRESSING!");
            SceneManager.LoadScene(9); //Load 1GameQuiz 
        }
    }


    public void ShowThisOverlay(GameObject overview)
    {
        PlaySound();
        overview.SetActive(true);


    }

    public void HideThisOverlay(GameObject overview)
    {
        PlaySound();
        overview.SetActive(false);
    }

    public void LoadScene(int buildIndex)
    {
        //SceneManager.LoadScene(buildIndex);

        PlaySound();
        GameObject voiceOver= GameObject.FindGameObjectWithTag("VoiceOver");
        if (voiceOver == true)
        {
            voiceOver.SetActive(false);
        }

        transition.SetTrigger("Loading");
        StartCoroutine(SceneLoad(buildIndex));
    }

    IEnumerator SceneLoad(int index)
    {

        //GameObject voiceOver = GameObject.FindGameObjectWithTag("VoiceOver");
        //voiceOver.GetComponent<AudioSource>().mute = true;

        yield return new WaitForSeconds(2f);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while (!async.isDone)
        {
            yield return new WaitForSeconds(transitiontime);
            yield return null;
        }

    }
   
}
