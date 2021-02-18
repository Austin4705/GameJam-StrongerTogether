using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemyAI : MonoBehaviour
{
    public Rigidbody2D enemy;
    public GameObject player;
    public float enemySpeed = 5f;
    public float shootingRange = 5;
    public float aimTime = 2;
    public GameObject enemyBullet;
    private bool shotYet = false;
    private float aimingTime;
    public float shotsPerSecond = 2;
    public GameObject gun;
    public GameObject gunTip;
    public GameObject enemyBulletStorage;
    private float lastShot;
    public float angle;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        lastShot = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        animator.SetFloat("Angle", angle);
        Vector2 dir = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y );
        float vLength = (Mathf.Sqrt((dir.x * dir.x) + (dir.y * dir.y)));
        if (vLength <= shootingRange)
        {
            if (!shotYet)
            {
                shotYet = true;
                aimingTime = Time.time;
            }
            if (Time.time - aimingTime > aimTime)
            {
                shoot();
            }
            else
            {
                aim();
            }
            enemy.velocity = Vector2.zero;
        }
        else
        {
            follow(dir, vLength);
            shotYet = false;
        }
    }

    void aim()
    {
        //play animation maybe idk
    }
    void shoot()
    {
        Vector2 dir = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y );
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        

        gun.transform.rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);
        Debug.DrawRay(this.transform.position, new Vector3(dir.x, dir.y, 0) );

        if (Time.time - lastShot > 1 / shotsPerSecond)
        {
            lastShot = Time.time;
            GameObject newObj = GameObject.Instantiate(enemyBullet, gunTip.transform.position,
                gunTip.transform.rotation);
            newObj.transform.parent = enemyBulletStorage.transform;
        }
    }

    void follow(Vector2 dir, float vLength)
    {
        dir = (dir / vLength) * enemySpeed;
        Debug.DrawRay(this.transform.position, new Vector3(dir.x, dir.y, 0) );
        enemy.velocity = dir;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
