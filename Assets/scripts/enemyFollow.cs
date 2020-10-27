using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject target;
    public Animator anmie1;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        anmie1 = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        // this will set the enemy destination as player position to move towards payer.
        float distance = Vector3.Distance(target.transform.position, transform.position);

        //transform.LookAt(target.transform.position);

        if (distance < 12 & distance > 0.5)
        {
            anmie1.SetBool("walking", true);
            agent.SetDestination(target.transform.position);
        }
        if (distance <= 6)
        {
            anmie1.SetBool("Attack", true);
        }
        else
        {
            anmie1.SetBool("Attack", false);
        }


    }
}