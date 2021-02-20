using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float time;
    public GameObject explosion;
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
        //Instantiate(explosion, this.gameObject.transform);
        Destroy(gameObject);
        
    }
}
