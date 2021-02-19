using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeEnemyAI : MonoBehaviour
{
// Start is called before the first frame update
    public Rigidbody2D enemy;
    public GameObject player;
    public float enemySpeed = 5f;
    public float chargeRange = 5;
    public float speedChargeMultiplier;
    public float chargeTime;
    public bool isCharging = false;
    public bool touchingPlayer = false;
    public float chargeTimeSpace;
    public bool inCoolDown;
    public float angle;
    
    private float lastCharge;
    private Vector2 dir;
    private float vLength;
    private float time;
    private Vector2 chargeDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        dir = new Vector2(player.transform.position.x - this.transform.position.x,
            player.transform.position.y - this.transform.position.y);
        vLength = (Mathf.Sqrt((dir.x * dir.x) + (dir.y * dir.y)));
        
        //if in cooldown
        if (Time.time - lastCharge < chargeTimeSpace)
        {
            enemy.velocity = Vector2.zero;
            inCoolDown = true;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        }
        else
        {
            inCoolDown = false;
            //if can charge or already charging
            if (vLength <= chargeRange || isCharging)
            {
                charge();
            }
            else
            {
                follow();
            }
        }
    }

    void charge()
    {
        //initializes charge
        if (isCharging == false)
        {
            isCharging = true;
            time = Time.time;
            chargeDirection = dir / vLength;
        }
        //while charge is running
        else
        {
            //if charge times still going
            if (Time.time - time < chargeTime)
            {
                Vector2 direction = chargeDirection * enemySpeed * speedChargeMultiplier;
                enemy.velocity = direction;
                Debug.DrawRay(this.transform.position, new Vector3(direction.x, direction.y, 0));
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            }
            //charge time is up
            else
            {
                isCharging = false;
                enemy.velocity = Vector2.zero;
                lastCharge = Time.time;

            }
            //if touching player end charge
            if (touchingPlayer)
            {
                isCharging = false;
                enemy.velocity = Vector2.zero;
                lastCharge = Time.time;
                
            }
        }

    }

    void follow()
    {
        dir = (dir / vLength) * enemySpeed;
        //Debug.Log($"{dir.x}, {dir.y}, {vLength}");
        Debug.DrawRay(this.transform.position, new Vector3(dir.x, dir.y, 0));
        enemy.velocity = dir;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
    
    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            touchingPlayer = true;
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
