using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float enemiesPerSecond = 1;
    public float lastSpawned;

    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public bool leftSpawn;
    public bool rightSpawn;
    public bool upSpawn;
    public bool downSpawn;

    private GameObject[] gameObjects = new GameObject[4];
    public bool[] canSpawn = new bool[4];
    public GameObject enemyGrunt;
    public GameObject enemyCharge;
    public GameObject enemyRanged;
    public GameObject enemyHierarchy;
    
    // Start is called before the first frame update
    void Start()
    {
        lastSpawned = Time.time;
        gameObjects[0] = left;
        gameObjects[1] = right;
        gameObjects[2] = up;
        gameObjects[3] = down;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Time.time - lastSpawned > 1 / enemiesPerSecond)
        // {
        //     lastSpawned = Time.time;
        //     spawnEnemies();
        // }
    }

    public void spawnGrunt()
    {
        spawnEnemies(enemyGrunt);
    }

    public void spawnCharged()
    {
        spawnEnemies(enemyCharge);
    }

    public void spawnRanged()
    {
        spawnEnemies(enemyRanged);
    }
    #region enemyCalculation 
    private void spawnEnemies(GameObject enemy)
    {
        int whichSpawn = calcNum();
        GameObject newObj = GameObject.Instantiate(enemy, gameObjects[whichSpawn].transform.position,
            gameObjects[whichSpawn].transform.rotation);
        newObj.transform.parent = enemyHierarchy.transform;
    }
    private int calcNum()
    {
        for(int i = 0; i < 4; i++)
        {
            canSpawn[i] = false;
            if (isOffScreen(gameObjects[i]))
            {
                canSpawn[i] = true;
            }
        }
        leftSpawn = false;
        if (canSpawn[0])
            leftSpawn = true;
        
        rightSpawn = false;
        if (canSpawn[1])
            rightSpawn = true;
        
        upSpawn = false;
        if (canSpawn[2])
            upSpawn = true;
        
        downSpawn = false;
        if (canSpawn[3])
            downSpawn = true;
        return randomNum();
    }
    private int randomNum()
    {
        int tryNum = Random.Range(0, 4);
        if (canSpawn[tryNum])
        {
            return tryNum;
        }
        else
        {
            return randomNum();
        }
    }
    private bool isOffScreen(GameObject obj)
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.transform.position.z);
        Vector3 screenHeight = new Vector3(Screen.width / 2, Screen.height, Camera.main.transform.position.z);
        Vector3 screenWidth = new Vector3(Screen.width, Screen.height/2, Camera.main.transform.position.z);
        Vector3 goScreen = Camera.main.WorldToScreenPoint(obj.transform.position);
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(goScreen.x, 0f,0f));
        float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, goScreen.y, 0f));
        if(distX > Screen.width / 2 || distY > Screen.height / 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}
