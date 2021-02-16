using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D player;
    public Transform gun;
    public Transform gunTip;
    private float lastShot;
    public GameObject bullet;
    public GameObject bulletStorage;
    public float shotsPerMinute = 3;
    
    void Start()
    {
        lastShot = Time.time;
    }
    void FixedUpdate()
    {
        move();
        look();
    }

    void Update()
    {
        shoot();
    }
    private void look()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //TODO: INPUT
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);
    }
    private void move()
    {
        //TODO: INPUT
        float xInput = Input.GetAxis("Horizontal") * moveSpeed;
        float yInput = Input.GetAxis("Vertical") * moveSpeed;
        //Debug.Log($"{Input.GetAxis("Horizontal")}, {Input.GetAxis("Vertical")}");
        Vector2 force = new Vector2(xInput, yInput);
        player.velocity = force;
    }

    private void shoot()
    {
        if(Time.time - lastShot > 1 / shotsPerMinute)
        {
            if (Input.GetButton("Jump"))
            {
                lastShot = Time.time;
                GameObject newObj = GameObject.Instantiate(bullet, gunTip.transform.position,
                    gunTip.transform.rotation);
                newObj.transform.parent = bulletStorage.transform;
            }

        }
    }
    
    
    
}
