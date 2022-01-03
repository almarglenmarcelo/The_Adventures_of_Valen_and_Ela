using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class HealthControl5 : MonoBehaviour
{
    public Image Healthbar;
    public float CurrentHealth;
    private float MaxHealth =100;

    public QuizManager5 player;


    private void Update()
    {
        CurrentHealth = player.health;
        Healthbar.fillAmount = CurrentHealth / MaxHealth;
    }
}
