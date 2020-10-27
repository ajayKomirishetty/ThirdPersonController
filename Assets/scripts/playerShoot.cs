using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    private AudioSource audio;

    void Update()
    {
        audio = GetComponent<AudioSource>();
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) 
        {
            fire();
        }   
    }
    public void fire() 
    {
        GameObject newbullet = BulletObjectPool.sharedInstance.getPooledObjects();
        newbullet.transform.position = transform.position + transform.forward;
        newbullet.GetComponent<Rigidbody>().velocity = transform.forward * 6f;
        audio.Play();
        //flash.Play();
        newbullet.SetActive(true);
    }
}
