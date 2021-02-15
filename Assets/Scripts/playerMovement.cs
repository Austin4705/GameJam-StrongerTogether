using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public CharacterController player;
    public Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Update is called once per frame
    void FixedUpdate()
    {
        move();
        look();
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
        float xInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector2 force = new Vector2(xInput, yInput);
        player.Move(force);
    }
    
    
    
}
