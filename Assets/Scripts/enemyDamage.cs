using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float health = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(float damage)
    {
        //for dumb two colliders
        health = health - (.5f * damage);
        if (health < 0)
        {
            enemyDie();            
        }

    }
    public void enemyDie()
    {
        Destroy(this.gameObject);
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            damage(other.gameObject.GetComponent<bullet>().damage);
            Destroy(other.gameObject);
        }
    }
}
