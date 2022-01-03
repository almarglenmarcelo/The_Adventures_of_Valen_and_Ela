using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Number : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI inputCode;
    private int passcode = 5555;
    private string code = "";
    private int maxNumber = 4;
    public GameObject passwordToggle;
    public GameObject confirmationPanel;
    public GameObject incorrectPinPanel;
    public GameObject incorrectPinSound;
    public GameObject diffuser;
    GameObject confirmSfx;

    private void Start()
    {
        inputCode.text = "";
        confirmSfx = GameObject.FindGameObjectWithTag("SaveSFX");
    }
    
    void PasswordToggle()
    {
        passwordToggle.GetComponent<AudioSource>().Play();
    }

   
    public void ConfirmReset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs Deleted!");

        FloorLevelPrefs floorLevelPrefs = new FloorLevelPrefs();

        floorLevelPrefs.hardReset();

        StartCoroutine(Reset());
    }

    public void NewPlayerReset()
    {
        PlayerPrefs.DeleteAll();

    }
    IEnumerator Reset()
    {   
        PlayerPrefs.SetInt("isNew", 1); //Set Default Costume if New to the game
        confirmSfx.GetComponent<AudioSource>().Play();
        confirmationPanel.SetActive(false);
        diffuser.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0); //Load Start Screen
        Debug.Log("Game Reset! Confirmed!");
    }

    public void Confirm()
    {
        StartCoroutine(Validate());
    }
    IEnumerator Validate()
    {
        if (int.Parse(code) == passcode)
        {
            Debug.Log("Game Reset!");
            confirmationPanel.SetActive(true);
            ClearCode();
        }
        else
        {
            Debug.Log("Incorrect Pin");
            incorrectPinSound.GetComponent<AudioSource>().Play();
            incorrectPinPanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            incorrectPinPanel.SetActive(false);
            ClearCode(); ;
        }
    }

    public void ClearCode()
    {
        code = "";
        inputCode.text = code;
    }

    public void CharacterLimiter()
    {
        inputCode.text = code;      
    }

    public void One()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 1;
            inputCode.text = code;
        }
        
    }
    public void Two()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 2;
            inputCode.text = code;
        }  
    }
    public void Three()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 3;
            inputCode.text = code;
        }  
    }
    public void Four()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 3;
            inputCode.text = code;
        }
    }
    public void Five()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 5;
            inputCode.text = code;
        }  
    }

    public void Six()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 6;
            inputCode.text = code;
        }   
    }
    public void Seven()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 7;
            inputCode.text = code;
        }   
    }
    public void Eight()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 8;
            inputCode.text = code;
        }   
    }
    public void Nine()
    {
        PasswordToggle();
        if (code.Length >= maxNumber)
        {
            CharacterLimiter();
        }
        else
        {
            code += 9;
            inputCode.text = code;
        }  
    }
}
