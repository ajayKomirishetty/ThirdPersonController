using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionsText : MonoBehaviour
{

    public GameObject uiObject;
    public Transform player;
    public Text text;
    private bool isGoblinAlive  = true;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
        text.text = "Welcome Stranger, your quest begins now, go and collect id cards from the deamon.";
        text.color = Color.white;
    }

    private void Update()
    {
        if(isGoblinAlive == true)
            isGoblinAlive =GameObject.Find("Goblin").GetComponent<goblinHealth>().isAlive;

        if (isGoblinAlive == false)
        {
            text.text = "Congratulations, you won the game,collect the Gold chest reward";   
        }


        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= 20)
        {
            uiObject.SetActive(true);
            StartCoroutine("waitForSec");
        }
    }

    IEnumerator waitForSec() 
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
    }
}
