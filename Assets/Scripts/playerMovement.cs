using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
        
    
    
    //Update is called once per frame
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal") * moveSpeed;
        float yInput = Input.GetAxis("Vertical") * moveSpeed;
        Debug.Log($"{Input.GetAxis("Horizontal")}, {Input.GetAxis("Vertical")}");
        Vector2 force = new Vector2(xInput, yInput);
        rigidbody.velocity = force;
    }
}
