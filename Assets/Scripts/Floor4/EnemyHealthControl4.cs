using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControl4 : MonoBehaviour
{
    public Image EnemyHealthbar;
    public float EnemyCurrentHealth;
    private float EnemyMaxHealth = 100;

    public QuizManager4 quizManager4;

    // Update is called once per frame
    void Update()
    {
        EnemyCurrentHealth = quizManager4.enemyHealth;
        EnemyHealthbar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}
