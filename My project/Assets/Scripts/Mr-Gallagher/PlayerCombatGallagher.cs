using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatGallagher : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Mr Gallagher died!");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
