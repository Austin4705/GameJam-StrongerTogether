using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D player;
    public Transform gunTip;
    private float lastShot;
    public GameObject bullet;
    public GameObject bulletStorage;
    public float shotsPerSecond = 3;
    public float angle;
    public Animator animator;
    public Transform[] stateTransform = new Transform[8];
    public int state;

    public Transform front;
    public Transform frontLeft;
    public Transform left;
    public Transform backLeft;
    public Transform back;
    public Transform backRight;
    public Transform right;
    public Transform frontRight;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        lastShot = Time.time;

        stateTransform[0] = front;
        stateTransform[1] = frontLeft;
        stateTransform[2] = left;
        stateTransform[3] = backLeft;
        stateTransform[4] = back;
        stateTransform[5] = backRight;
        stateTransform[6] = right;
        stateTransform[7] = frontRight;
    }
    void FixedUpdate()
    {
        move();
    }

    void Update()
    {
        shoot();
        switchShootPos();
    }

    void switchShootPos()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Front"))
            state = 0;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Front Left"))
            state = 1;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Left"))
            state = 2;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Back Left"))
            state = 3;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Back"))
            state = 4;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Back Right"))
            state = 5;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Right"))
            state = 6;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Front Right"))
            state = 7;
        look();
    }
    private void look()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //TODO: INPUT
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        animator.SetFloat("Angle", angle);
        gunTip.transform.position = stateTransform[state].position;
        gunTip.transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward);
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
