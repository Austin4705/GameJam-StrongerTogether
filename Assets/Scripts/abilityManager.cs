using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityManager : MonoBehaviour
{
    public bool c4Unlocked = false;
    public bool piercingUnlocked = false;
    public bool machineGunUnlocked = false;
    public bool orbUnlocked = false;
    
    
    private static abilityManager _instance;
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
        if (Input.GetButtonDown("Fire2") && c4Unlocked)
        {
            spawnC4();
        }
        if (Input.GetButtonDown("Fire2") && c4Unlocked)
        {
            //detonate c4
        }
        if (Input.GetButtonDown("Fire3") && piercingUnlocked)
        {
            enablePiecingBullets();
        }
        if (Input.GetButtonDown("Fire3") && machineGunUnlocked)
        {
            enableMachineGun();
        }
        if (Input.GetButtonDown("Fire2") && orbUnlocked)
        {
            spawnOrb();
        }
    }

    private void spawnC4()
    {
        
    }

    private void enablePiecingBullets()
    {
        
    }

    private void enableMachineGun()
    {
        
    }

    private void spawnOrb()
    {
        
    }
}
