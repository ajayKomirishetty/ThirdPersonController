using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnIdCards : MonoBehaviour
{
    bool isGoblinAlive;
    public GameObject idCard;
    private float rewardXpos, idCardxpos, rewardZpos, idCardZpos;
    private int idCardCount = 0;
    bool createdIdCards = false;
    public GameObject reward;
    GameObject lord;
    // Update is called once per frame

    void Update()
    {
        isGoblinAlive = GameObject.Find("Goblin").GetComponent<goblinHealth>().isAlive;
        lord = GameObject.Find("Peasant_girl");
        if (isGoblinAlive == false && createdIdCards == false) 
        {
            StartCoroutine(spawn());
            createdIdCards = true;
        }
    }

    IEnumerator spawn()
    {
        while (idCardCount < 2)
        {

            idCardxpos = Random.Range(transform.position.x, transform.position.x+6);
            idCardZpos = Random.Range(transform.position.z, transform.position.z + 6);

            rewardXpos = Random.Range(lord.transform.position.x, lord.transform.position.x + 3);
            rewardZpos = Random.Range(lord.transform.position.z, lord.transform.position.z + 3);

            Instantiate(idCard, new Vector3(idCardxpos, 4f, idCardZpos),idCard.transform.rotation);
            Instantiate(reward, new Vector3(rewardXpos, 0f, rewardZpos), reward.transform.rotation);
            yield return new WaitForSeconds(0.1f);
            idCardCount += 1;
        }
        createdIdCards = true;
    }

}
