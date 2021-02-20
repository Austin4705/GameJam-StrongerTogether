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
    
    public float C4CoolDown;
    public int C4Price;
    public float C4Timer;
    public event Action detonation;
    
    public float piercingCoolDown;
    public int piercingPrice;
    public float piercingTimer;
    public float piercingActiveTime;

    public float machineGunCoolDown;
    public int machineGunPrice;
    public float machineGunTimer;
    public float machineGunActiveTime;

    public float orbCoolDown;
    public int orbPrice;
    public float orbTimer;

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
        C4Timer = Time.time;
        piercingTimer = Time.time;
        machineGunTimer = Time.time;
        orbTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - piercingTimer > piercingActiveTime)
        {
            piercingEnabled = false;
        }
        if (Time.time - machineGunTimer > machineGunActiveTime)
        {
            machineGunEnabled = false;
        }
        //TODO: input
        if (Input.GetKeyDown(KeyCode.G) && c4Unlocked && Time.time - C4Timer > C4CoolDown && this.GetComponent<nanobotSystem>().nanobots - C4Price > 0)
        {
            spawnC4();
            C4Timer = Time.time;
            this.GetComponent<nanobotSystem>().nanobots -= C4Price;
        }
        if (Input.GetKeyDown(KeyCode.F) && c4Unlocked)
        {
            detonateC4();
        }
        if (Input.GetKeyDown(KeyCode.H) && piercingUnlocked && Time.time - piercingTimer > piercingCoolDown && this.GetComponent<nanobotSystem>().nanobots - piercingPrice > 0)
        {
            enablePiecingBullets();
            piercingTimer = Time.time;
            this.GetComponent<nanobotSystem>().nanobots -= piercingPrice;
        }
        if (Input.GetKeyDown(KeyCode.Y) && machineGunUnlocked && Time.time - machineGunTimer > machineGunCoolDown && this.GetComponent<nanobotSystem>().nanobots - machineGunPrice > 0)
        {
            enableMachineGun();
            machineGunTimer = Time.time;
            this.GetComponent<nanobotSystem>().nanobots -= machineGunPrice;
        }
        if (Input.GetKeyDown(KeyCode.T) && orbUnlocked && Time.time - orbTimer > orbCoolDown && this.GetComponent<nanobotSystem>().nanobots - orbPrice > 0)
        {
            spawnOrb();
            orbTimer = Time.time;
            this.GetComponent<nanobotSystem>().nanobots -= orbPrice;
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
        if(detonation != null)
        {
            detonation();
        }
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
