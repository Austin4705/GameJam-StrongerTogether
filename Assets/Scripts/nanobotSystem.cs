using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nanobotSystem : MonoBehaviour
{
    public int nanobots;
    public int startingBots = 5;
    public int abilityStatus = 0;
    public int[] abilityPrice = {5, 20, 40, 60, 100};
    public GameObject player;
    public float hitCooldown;
    public bool devInvinsible = true;
    public bool invinsible;
    public float invinsibilityTimer = 0;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        nanobots = startingBots;
        invinsibilityTimer = Time.time;
    }

    public void Damage(int damage)
    {
        if (Time.time - invinsibilityTimer > hitCooldown)
        {
            nanobots = nanobots - damage;
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
        if (nanobots - abilityPrice[abilityStatus] > 0)
        {
            nanobots = nanobots - abilityPrice[abilityStatus];
            abilityStatus++;
        }
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
        }
        if (other.gameObject.tag == "Enemy")
        {
            Damage(other.gameObject.GetComponent<enemyDamage>().playerDamage);
        }
    }
}
