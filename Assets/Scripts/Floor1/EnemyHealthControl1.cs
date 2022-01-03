using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthControl1 : MonoBehaviour
{
    public Image EnemyHealthbar;
    public float EnemyCurrentHealth;
    private float EnemyMaxHealth = 100;

    public QuizManager1 quizManager1;
    
    void Update()
    {
        EnemyCurrentHealth = quizManager1.enemyHealth;
        EnemyHealthbar.fillAmount = EnemyCurrentHealth / EnemyMaxHealth;
    }
}
