using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timeAlive = 0f;

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 3)
        {
            gameObject.SetActive(false);
            timeAlive = 0f;
        }
    }

   

    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.transform.tag == "enemy")
        {
            Debug.Log("enemy");
             enemyHealth eh = collision.transform.GetComponent<enemyHealth>();
             eh.takeDamage(20);
            //Destroy(collision.gameObject);

            Rigidbody rbdy = collision.transform.GetComponent<Rigidbody>();
            Debug.Log("velocity of enemy is "+rbdy.velocity);

            //Stop Moving/Translating
            rbdy.velocity = Vector3.zero;

            //Stop rotating
            rbdy.angularVelocity = Vector3.zero;
        }
        else if (collision.transform.tag == "goblin")
        {
            goblinHealth gh = GameObject.Find("Goblin").GetComponent<goblinHealth>();
            gh.takeDamage(20);
        }
    }
}
