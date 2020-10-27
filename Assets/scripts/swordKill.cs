using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordKill : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
            enemyHealth eh = collision.transform.GetComponent<enemyHealth>();
            eh.takeDamage(20);
            //Destroy(collision.gameObject);

            Rigidbody rbdy = collision.transform.GetComponent<Rigidbody>();

            //Stop Moving/Translating
            rbdy.velocity = Vector3.zero;

            //Stop rotating
            rbdy.angularVelocity = Vector3.zero;
        }
    }
}
