using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nanobotSystem : MonoBehaviour
{
    public int nanobots;
    public int startingBots = 5;
    public int abilityStatus = 0;
    public int[] abilityPrice = {1, 2, 3, 4};
    public GameObject player;
    public float hitCooldown;
    public bool devInvinsible = true;
    public bool invinsible;
    public float invinsibilityTimer = 0;
    public float time;
    public GameObject hitEffect;

    public GameObject audioPlayer;
    public AudioClip hit;
    public AudioClip death;

    // Start is called before the first frame update
    void Start()
    {
        nanobots = startingBots;
        invinsibilityTimer = Time.time;
    }
    private static nanobotSystem _instance;
    public static nanobotSystem Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    public void Damage(int damage)
    {
        if (Time.time - invinsibilityTimer > hitCooldown)
        {
            nanobots = nanobots - damage;

            GameObject sound = GameObject.Instantiate(audioPlayer, transform.position, transform.rotation);
            sound.GetComponent<PlaySoundThenDie>().clip = hit;

            GameObject newObj = GameObject.Instantiate(hitEffect, gameObject.transform.position,
                gameObject.transform.rotation);
            newObj.transform.parent = gameObject.transform;

            if (nanobots < 0)
            {
                if (!devInvinsible)
                {
                    kill();
                }
            }
            invinsible = true;
            invinsibilityTimer = Time.time;
        }

    }
    void Update()
    {
        if (Time.time - invinsibilityTimer > hitCooldown)
        {
            invinsible = false;
        }
        time = Time.time - invinsibilityTimer;
        //TODO Input
        if (Input.GetKeyDown(KeyCode.R))
        {
            unlockAbility();
        }
    }
    public void useAbility(int value)
    {
        if (nanobots - value > 0)
        {
            nanobots = nanobots - value;
        }
    }
    public void unlockAbility()
    {
        if (!(abilityStatus >= 4))
        {
            if (nanobots - abilityPrice[abilityStatus] > 0 && abilityStatus <= 4)
            {
                Debug.Log("Unlocking Ability");
                nanobots = nanobots - abilityPrice[abilityStatus];
                switch (abilityStatus)
                {
                    case 0:
                        unlockC4();
                        break;
                    case 1:
                        unlockBulletPiercing();
                        break;
                    case 2:
                        unlockMachineGun();
                        break;
                    case 3:
                        unlockLaserOrb();
                        break;
                }
                abilityStatus++;
            }   
        }
    }
    public void unlockC4()
    {
        abilityManager.Instance.c4Unlocked = true;
    }
    public void unlockBulletPiercing()
    {
        abilityManager.Instance.piercingUnlocked = true;
    }
    public void unlockMachineGun()
    {
        abilityManager.Instance.machineGunUnlocked = true;
    }

    public void unlockLaserOrb()
    {
        abilityManager.Instance.orbUnlocked = true;
    }
    
    public void addNanobot()
    {
        nanobots++;
    }

    public void kill()
    {

        Destroy(player);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Nanobot")
        {
            addNanobot();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Damage(other.gameObject.GetComponent<enemyDamage>().playerDamage);
            if (other.gameObject.GetComponent<enemyDamage>().dieOnContact)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            Damage(other.gameObject.GetComponent<explosionScript>().playerDamage);
        }
    }
}
