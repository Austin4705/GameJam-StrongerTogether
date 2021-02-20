using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityManager : MonoBehaviour
{
    public bool c4Unlocked = false;
    public bool piercingUnlocked = false;
    public bool machineGunUnlocked = false;
    public bool orbUnlocked = false;

    public bool piercingEnabled = false;
    public bool machineGunEnabled = false;
    private static abilityManager _instance;
    public GameObject gunTip;
    public GameObject orb;
    public GameObject C4;
    public static abilityManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //TODO: input
        if (Input.GetKeyDown(KeyCode.G) && c4Unlocked)
        {
            spawnC4();
        }
        if (Input.GetKeyDown(KeyCode.F) && c4Unlocked)
        {
            detonateC4();
        }
        if (Input.GetKeyDown(KeyCode.H) && piercingUnlocked)
        {
            enablePiecingBullets();
        }
        if (Input.GetKeyDown(KeyCode.Y) && machineGunUnlocked)
        {
            enableMachineGun();
        }
        if (Input.GetKeyDown(KeyCode.T) && orbUnlocked)
        {
            spawnOrb();
        }
    }

    private void spawnC4()
    {
        Vector3 pos = 
            new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                this.gameObject.transform.position.z);
        Debug.Log("C4");
        
        GameObject newObj = GameObject.Instantiate(C4, this.gameObject.transform.position, this.gameObject.transform.rotation);
        newObj.GetComponent<C4Script>().position = pos;
    }

    private void detonateC4()
    {
        
    }
    private void enablePiecingBullets()
    {
        piercingEnabled = true;
    }

    private void enableMachineGun()
    {
        machineGunEnabled = true;
    }

    private void spawnOrb()
    {
        GameObject newObj = GameObject.Instantiate(orb, gunTip.transform.position,
            gunTip.transform.rotation);
    }
}
