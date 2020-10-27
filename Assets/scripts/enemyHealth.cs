using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int speed = 2;

    public Animator animator;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void deadEnemy() 
    {
        animator.SetBool("death",true);
        CapsuleCollider collider = GameObject.Find("zombie@Walking"). GetComponent<CapsuleCollider>();
        collider.direction = 2;
        Destroy(gameObject,5f);
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            deadEnemy();
    }
}
