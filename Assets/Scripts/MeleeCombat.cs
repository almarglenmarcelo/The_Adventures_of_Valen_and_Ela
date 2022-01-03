using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{

    public Animator animator;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyAttack();
        }
    }

    public void CharacterAttack()
    {
        animator.SetTrigger("Valen_Attack");
       
        
        Debug.Log("Attack!");
    }

    public void CharacterHurt()
    {
        animator.SetTrigger("Valen_Hurt");
    }



    public void EnemyAttack()
    {
        animator.SetTrigger("Enemy_Attack");

    }

    public void EnemyHurt()
    {
        animator.SetTrigger("Enemy_Hurt");
    }


    
 
}
