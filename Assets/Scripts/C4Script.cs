﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4Script : MonoBehaviour
{
    public Rigidbody2D C4;
    public Vector3 position;
    public float cutOff = 0.1f;
    public GameObject explosion;
    public GameObject storage;
    // Start is called before the first frame update
    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("C4ExplosionStorage"); 
        abilityManager.Instance.detonation += C4Detonation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = new Vector2(position.x - this.transform.position.x, position.y - this.transform.position.y);
        float vLength = (Mathf.Sqrt((dir.x * dir.x) + (dir.y * dir.y)));
        if ((vLength < cutOff))
        {
            dir.x = 0;
            dir.y = 0;
        }
        C4.velocity = dir;
    }

    void C4Detonation()
    {
        GameObject newObj = GameObject.Instantiate(explosion, this.gameObject.transform);
        newObj.transform.parent = storage.transform;
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        abilityManager.Instance.detonation -= C4Detonation;
    }
}
