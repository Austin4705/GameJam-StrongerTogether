using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage = 10;
    public float speed = 20f;
    public Rigidbody2D rb;
    public float time;
    public bool piercing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        time = Time.time;
    }
    void Update()
    {
        if (Time.time - time > 15)
        {
            Destroy(this.gameObject);
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!piercing)
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
