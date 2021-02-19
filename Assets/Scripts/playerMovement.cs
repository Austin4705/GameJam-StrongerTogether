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
    public float shotsPerSecond = 3;
    public float angle;
    public Animator animator;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        animator.SetFloat("Angle", angle);
        gun.transform.rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);
        /*
        if(angle > 90 || angle < -90)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        */
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
        if(Time.time - lastShot > 1 / shotsPerSecond)
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
