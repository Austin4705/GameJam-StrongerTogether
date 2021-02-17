using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gruntEnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D enemy;
    public GameObject player;
    public float enemySpeed = .005f;
    public float angle;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y );
        float vLength = (Mathf.Sqrt((dir.x * dir.x) + (dir.y * dir.y)));
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        if (vLength <= 1f)
        {
            dir.x = 0;
            dir.y = 0;
        }
        dir = (dir / vLength) * enemySpeed;
        //Debug.Log($"{dir.x}, {dir.y}, {vLength}");
        Debug.DrawRay(this.transform.position, new Vector3(dir.x, dir.y, 0) );
        enemy.velocity = dir;
    }
}
