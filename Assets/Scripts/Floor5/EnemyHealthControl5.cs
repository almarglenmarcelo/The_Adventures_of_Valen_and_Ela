using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControl5 : MonoBehaviour
{
    public Image EnemyHealthbar;
    public float EnemyCurrentHealth;
    private float EnemyMaxHealth = 100;

    public QuizManager5 quizManager5;

    // Update is called once per frame
    void Update()
    {
        EnemyCurrentHealth = quizManager5.enemyHealth;
        EnemyHealthbar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}
