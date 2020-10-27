using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public static enemySpawn temp;
    public GameObject enemy;
    public int xpos;
    public int zpos;
    public int enemyCount;

    public GameObject player;
    public Transform camera;

    void Start()
    {
        temp = this;
      //  animator = GetComponent<Animator>();
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (enemyCount < 5)
        {
            xpos = Random.Range(1, 100) - 50;
            zpos = Random.Range(1, 50) - 50;
            Instantiate(enemy, new Vector3(xpos, 0f, zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }


}

