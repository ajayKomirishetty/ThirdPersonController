using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billBoard : MonoBehaviour
{

    //public Transform cam;
   
    void LateUpdate()
    {
        transform.LookAt(transform.position + enemySpawn.temp.camera.forward); 
    }
}
