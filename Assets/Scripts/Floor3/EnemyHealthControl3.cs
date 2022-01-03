using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControl3 : MonoBehaviour
{
    public Image EnemyHealthbar;
    public float EnemyCurrentHealth;
    private float EnemyMaxHealth = 100;

    public QuizManager3 quizManager3;

    // Update is called once per frame
    void Update()
    {
        EnemyCurrentHealth = quizManager3.enemyHealth;
        EnemyHealthbar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}
