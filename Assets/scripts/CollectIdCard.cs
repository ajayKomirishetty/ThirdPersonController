using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIdCard : MonoBehaviour
{
    public AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(enemySpawn.temp.player.transform.position,transform.position);
        if (distance < 2f)
        {
            //audio.Play();
            gameObject.SetActive(false);
        }
    }
   
}
