using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 10 )
        {
            animator.SetBool("attack", true);
            transform.LookAt(player.transform);
           // transform.position += transform.forward * 1f * Time.deltaTime;
        }
        else
        {
            animator.SetBool("attack", false);
        }


    }


}
