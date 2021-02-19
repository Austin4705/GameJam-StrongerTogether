using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class roundManager : MonoBehaviour
{
    public float roundTime;
    public rounds level;
    public float totalLevels;
    public int currentRoundNum;
    private round currentRound;
    private bool newRound;
    public float waitTimeBetweenRounds = 10;
    public float gruntsPerSec;
    public float totalRoundTime;
    public float gruntTime;
    public GameObject thisGameObject;
    public Special specialEnemy;
    private int specialEnemyAt;
    public int totalSpecialEnemies;
    public TextAsset jsonFile;
    // Start is called before the first frame update
    void Start()
    {
        thisGameObject = this.gameObject;
        
        roundTime = Time.time;
        read();
        totalLevels = level.eachRound.Length;
        currentRoundNum = 1;
        currentRound = level.eachRound[0];
        newRound = true;
    }
    // Update is called once per frame
    void Update()
    {
        calcSpawn();
    }

    void calcSpawn()
    {
        if (newRound)
        {
            //new round init
            Debug.Log("NewRound");
            currentRound = level.eachRound[currentRoundNum-1];
            totalRoundTime = currentRound.roundTime;
            roundTime = Time.time;
            gruntsPerSec = currentRound.grunt / roundTime;
            totalSpecialEnemies = currentRound.special.Length;
            specialEnemyAt = 0;
            if (totalSpecialEnemies > 0)
            {
                specialEnemy = currentRound.special[0];
            }
        }
        else
        {
            //periodically spawn the enemies
            if (Time.time - gruntTime > 1 / gruntsPerSec)
            {
                Debug.Log("Spawning Grunt");
                //thisGameObject.GetComponent<enemySpawner>().spawnGrunt();
            }
            
            if (Time.time - roundTime > specialEnemy.time)
            {
                switch (specialEnemy.type)
                {
                    case 1:
                        Debug.Log("Spawning Grunt Special");
                        thisGameObject.GetComponent<enemySpawner>().spawnGrunt();
                        break;
                    case 2:
                        Debug.Log("Spawning Charged");
                        thisGameObject.GetComponent<enemySpawner>().spawnCharged();
                        break;
                    case 3:
                        Debug.Log("Spawning Ranged");
                        thisGameObject.GetComponent<enemySpawner>().spawnRanged();
                        break;
                }
                
                if (!(specialEnemyAt > totalSpecialEnemies))
                {
                    specialEnemy = currentRound.special[specialEnemyAt];
                }
                specialEnemyAt++;
            }
        }
        //check if new round over to init over to the new one if needed
        newRound = false;
        if (Time.time - roundTime + waitTimeBetweenRounds > totalRoundTime)
        {
            //round done
            newRound = true;
            if (currentRoundNum <= totalLevels - 1)
            {
                currentRoundNum++;    
            }
            // else
            // {
            //     //infinite mode
            //     currentRound.grunt += 10;
            // }
        }
    }
    
    // Start is called before the first frame update
    public void read()
    {
        level = JsonUtility.FromJson<rounds>(jsonFile.text);
        
        //printing rounds
        // foreach (round Round in level.eachRound)
        // {
        //     Debug.Log(
        //         "roundID: " + Round.roundID + " " + 
        //         "roundID: " + Round.grunt + " " +
        //         "roundTime: " + Round.roundTime + " "
        //     );
        //     foreach (Special special in Round.special)
        //     {
        //         Debug.Log(
        //             "type: " + special.type + " " + 
        //             "time: " + special.time + " " +
        //             "amount: " + special.amount + " "
        //         );
        //     }
        // }
    }
}
