using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumePrefs : MonoBehaviour
{
    private int GetCostumePrefs(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public void SetCostumePrefs(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
