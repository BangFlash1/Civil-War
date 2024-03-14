using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    public Animator animator;
    public int attackDamage = 40;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Mr Wayne hit " + enemy);
            enemy.GetComponent<PlayerCombatGallagher>().TakeDamage(attackDamage);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
            
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}


