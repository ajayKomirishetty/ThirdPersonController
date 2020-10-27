using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusLogs : MonoBehaviour
{
    Text text;
    int enemyCount;
    bool goblinStatus;
    bool goblinStatusUpdated = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        enemyCount = enemySpawn.temp.enemyCount;        
        text.text = "\t\tWelcome Stranger\n";
        text.text += enemyCount + " enemies are still alive, kill 'em!\n";
        text.text += enemyCount + " enemies are still alive, kill 'em!\n";
        text.text += "Goblin is still Alive, I repeat, Goblin is still Alive ! \n";
        text.text += "Go to Lord Goldbloom at dew hurst hall to start the quest ! \n";
    }

    // Update is called once per frame
    void Update()
    {
        goblinStatus = goblinHealth.temp.isAlive;

        if (goblinStatus == false && goblinStatusUpdated == false)
        {
            goblinStatusUpdated = true;
            text.text += "Goblin is still dead, I repeat, Goblin is dead ! \n";
        }

    }
}
