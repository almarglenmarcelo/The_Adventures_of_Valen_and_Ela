using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControl6 : MonoBehaviour
{
    public Image EnemyHealthbar;
    public float EnemyCurrentHealth;
    private float EnemyMaxHealth = 100;

    public QuizManager6 quizManager6;

    // Update is called once per frame
    void Update()
    {
        EnemyCurrentHealth = quizManager6.enemyHealth;
        EnemyHealthbar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}
