using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public string costumeEquipped;

    public PlayerData(WardrobeToggle wardrobeToggle){
        costumeEquipped = wardrobeToggle.costumeEquipped;
        }

}
