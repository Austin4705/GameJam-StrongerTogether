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
    public GameObject enemy;
    
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
        if(Time.time - lastSpawned > 1 / enemiesPerSecond)
        {
            lastSpawned = Time.time;
            spawnEnemies();
        }
    }

    private void spawnEnemies()
    {
        for(int i = 0; i < 4; i++)
        {
            canSpawn[i] = false;
            if(isOffScreen(gameObjects[i]))
                canSpawn[i] = true;
        }
        for (int i = 0; i < 4; i++)
        {
               
        }

        // leftSpawn = false;
        // rightSpawn = false;
        // upSpawn = false;
        // downSpawn = false;
        // if (isOffScreen(left))
        // {
        //     offScreenObjects.Add(left);
        //     leftSpawn = true;
        // }
        // if (isOffScreen(right))
        // {
        //     offScreenObjects.Add(right);
        //     rightSpawn = true;
        // }
        // if (isOffScreen(up))
        // {
        //     offScreenObjects.Add(up);
        //     upSpawn = true;
        // }
        // if (isOffScreen(down))
        // {
        //     offScreenObjects.Add(down);
        //     downSpawn = true;
        // }
        int whichSpawn = Random.Range(0, offScreenObjects.Count);
        Instantiate(enemy, offScreenObjects[whichSpawn].transform.position,
            offScreenObjects[whichSpawn].transform.rotation);
        Debug.Log($"Could of spawned{whichSpawn}");
    }

    private bool isOffScreen(GameObject obj)
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.transform.position.z);
        Vector3 screenHeight = new Vector3(Screen.width / 2, Screen.height, Camera.main.transform.position.z);
        Vector3 screenWidth = new Vector3(Screen.width, Screen.height/2, Camera.main.transform.position.z);
        Vector3 goscreen = Camera.main.WorldToScreenPoint(obj.transform.position);
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(goscreen.x, 0f,0f));
        float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, goscreen.y, 0f));
        if(distX > Screen.width / 2 || distY > Screen.height / 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
