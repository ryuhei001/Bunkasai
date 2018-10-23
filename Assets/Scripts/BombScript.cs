﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
	}

    public void SetVelocity(Vector3 forward)
    {
        var rid = GetComponent<Rigidbody>();
        rid.velocity = forward * speed;
    }
}
