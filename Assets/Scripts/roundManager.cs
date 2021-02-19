using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        thisGameObject = this.gameObject;
        
        roundTime = Time.time;
        readJSON.read();
        level = readJSON.level;
        readJSON.level = null;
        totalLevels = level.eachRound.Length;
        currentRoundNum = 1;
        currentRound = level.eachRound[0];
        newRound = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (newRound)
        {
            //new round init
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
                thisGameObject.GetComponent<enemySpawner>().spawnGrunt();
            }
            
            if (Time.time - roundTime > specialEnemy.time)
            {
                switch (specialEnemy.type)
                {
                    case 1:
                        thisGameObject.GetComponent<enemySpawner>().spawnGrunt();
                        break;
                    case 2:
                        thisGameObject.GetComponent<enemySpawner>().spawnCharged();
                        break;
                    case 3:
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
            else
            {
                //infinite mode
                currentRound.grunt += 10;
            }
            
        }
        
    }
}
