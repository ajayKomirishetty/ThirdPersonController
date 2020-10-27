using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int speed = 2;
    public bool isAlive = true;
    public static goblinHealth temp;

    public Animator animator;

    public HealthBar healthBar;
    void Start()
    {
        temp = this;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void deadEnemy()
    {
        animator.SetBool("death", true);
        Destroy(gameObject, 4f);
        isAlive = false;
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            deadEnemy();
    }
}