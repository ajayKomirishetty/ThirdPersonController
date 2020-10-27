using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 2f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    Quaternion playerRot;
    Vector3 lookAtTarget;
    float rotSpeed = 5f;
    Vector3 trgetPosition;
    bool moving;
    GameObject[] weapons;
    public int activeGunIndex;
    RaycastHit hit;
    private bool is_clicking = false; // this is to detect long press




    public Animator animator;


    private void Start()
    {
        weapons = GameObject.FindGameObjectsWithTag("weapon");
        weapons[1].gameObject.SetActive(false);
        activeGunIndex = 0; // 1 is gun and 0 is sword
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float holdStartTime = 0;

        if (Input.GetMouseButtonDown(0))
        {
            holdStartTime = 0;
            setTargetPositon("short");
            holdStartTime = Time.deltaTime;
        }

        if (Input.GetMouseButton(0) )
        {
            holdStartTime += Time.deltaTime;
            
            if (holdStartTime > 0.02f)
            {
                setTargetPositon("long");
                is_clicking = true;
                
            }
        }
        if (Input.GetMouseButtonUp(0) && is_clicking)
        {
            is_clicking = false;
            animator.SetBool("melee", false);
        }

        if (moving)
        {
            Move();
        }

        if (direction.magnitude >= 0.1f)
        {
            float targerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targerAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movedir = Quaternion.Euler(0f, targerAngle, 0f) * Vector3.forward;
            animator.SetBool("walking", true);
            controller.Move(movedir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        if (moving == true)
        {
            animator.SetBool("walking", true);
            speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("running", true);
            speed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("running", false);
            speed = 2f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (activeGunIndex == 1)
            {
                activeGunIndex = 0;
                weapons[0].gameObject.SetActive(true);
                weapons[1].gameObject.SetActive(false);
            }
            else if (activeGunIndex == 0)
            {
                activeGunIndex = 1;
                weapons[0].gameObject.SetActive(false);
                weapons[1].gameObject.SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (activeGunIndex == 1)
            {
                animator.SetBool("melee", true);
                animator.SetBool("firing", false);


            }
            else
            {
                animator.SetBool("melee", false);
                animator.SetBool("firing", true);

            }
        }

        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            if (activeGunIndex == 1)
            {
                animator.SetBool("melee", false);
            }
            else
            {
                animator.SetBool("firing", false);

            }
        }
    }

    void setTargetPositon(string hold_type)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000F))
        {
            Debug.Log("hold_type is "+ hold_type);
            Debug.Log("tag is "+ hit.transform.tag);
            if (hold_type == "long" && (hit.transform.tag == "enemy"  || hit.transform.tag == "goblin"))
            {
                animator.SetBool("melee", true);
            }
            trgetPosition = hit.point;
            lookAtTarget = new Vector3(trgetPosition.x - transform.position.x - 2f, 0, trgetPosition.z - transform.position.z - 2f);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;
         
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, trgetPosition, speed * Time.deltaTime);

        if (transform.position == trgetPosition)
        {
            moving = false;
        }

        float dist = Vector3.Distance(trgetPosition, transform.position);

        if (hit.transform.tag == "enemy")
        {
            // Debug.Log("enemy is at distance" + dist);
            int enemyHealth = hit.transform.GetComponent<enemyHealth>().currentHealth;
            if (activeGunIndex == 0)
                animator.SetBool("firing", true);
            else
                animator.SetBool("melee", true);
            if (activeGunIndex == 0)
            {
                while (enemyHealth >= 0 && dist <= 2)
                {
                    enemyHealth = hit.transform.GetComponent<enemyHealth>().currentHealth;
                    fire();
                }
            }
            else
                animator.SetBool("melee", true);
            if (activeGunIndex == 0)
            {
                animator.SetBool("firing", false);
            }
            else
            {
                animator.SetBool("melee", false);
            }
        }

    }

    public void fire()
    {
        GameObject newbullet = BulletObjectPool.sharedInstance.getPooledObjects();
        newbullet.transform.position = transform.position + transform.forward;
        newbullet.GetComponent<Rigidbody>().velocity = transform.forward * 8f;
        newbullet.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("idCard"))
        {
            Debug.Log("id card detected");
            Destroy(collision.gameObject);
        }


        Debug.Log("enemy collided");
        //  if (collision.transform.tag == "enemy")
        //{
        Rigidbody rbdy = collision.transform.GetComponent<Rigidbody>();
        //  rbdy.isKinematic = true;

        //Stop Moving/Translating
        rbdy.velocity = Vector3.zero;

        //Stop rotating
        rbdy.angularVelocity = Vector3.zero;
        //}
    }
}