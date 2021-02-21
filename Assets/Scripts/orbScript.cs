using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float time;
    public GameObject explosion;
    public GameObject storage;
    public float beginInvinsibleTime = .25f;
    public float invinsibleTimer;
    public bool isInvinsible;
    // Start is called before the first frame update
    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("orbExplosionStorage");
        rb.velocity = transform.up * speed;
        time = Time.time;
        isInvinsible = true;
    }
    void Update()
    {
        if (Time.time - time > 15)
        {
            Destroy(this.gameObject);
        }
        if (Time.time - time > beginInvinsibleTime)
        {
            isInvinsible = false;
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!isInvinsible)
        {
            GameObject newObj = GameObject.Instantiate(explosion, this.gameObject.transform);
            newObj.transform.parent = storage.transform;
            Destroy(gameObject);

        }
    }
}
