using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class enemyHealthBar : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject enemy;
    public Vector3 scale;
    public float percentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        //canvas.GetComponent<Canvas>().worldCamera = camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        health = enemy.GetComponent<enemyDamage>().health;
        maxHealth = enemy.GetComponent<enemyDamage>().maxHealth;
        percentHealth = health / maxHealth;
        scale.x = percentHealth * 0.3f;
        transform.localScale = scale;        
    }
}
