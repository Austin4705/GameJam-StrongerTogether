using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    public float enemyDamage = 5;
    public int playerDamage = 4;
    public float stayAliveTime = 3;
    public float liveTimer;
    // Start is called before the first frame update
    void Start()
    {
        liveTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - liveTimer > stayAliveTime)
        {
            Destroy(gameObject);
        }
    }
}
