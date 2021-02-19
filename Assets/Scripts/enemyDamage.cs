using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public int playerDamage;
    public int nanobotsOnDeath;
    public GameObject nanobot;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(float damage)
    {
        //for dumb two colliders
        health = health - (damage);
        if (health < 0)
        {
            enemyDie();            
        }

    }
    public void enemyDie()
    {
        Destroy(this.gameObject);
        UIManager.Instance.addScore(score);
        dropNanobots();
    }

    private void dropNanobots()
    {
        for (int i = 0; i < nanobotsOnDeath; i++)
        {
            GameObject newObj = GameObject.Instantiate(nanobot, gameObject.transform.position, 
                gameObject.transform.rotation);
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            damage(other.gameObject.GetComponent<bullet>().damage);
        }
    }
}
