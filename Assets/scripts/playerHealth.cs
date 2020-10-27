using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        
    }

    public void takeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
      //  if (currentHealth <= 0)
        //    animator.SetBool("death",true);

    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i am attacked");
        if (collision.transform.tag == "enemy")
            this.takeDamage(10);
        Rigidbody rigidbody = collision.transform.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

    }

}
