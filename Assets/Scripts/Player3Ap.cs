﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Ap : MonoBehaviour {
	public int armerPoint = 100;
	public int damage = 10;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player4Shot"
			||collider.gameObject.tag=="Player1Shot"){
			armerPoint -= damage;
		}
		if(armerPoint<0){
			Destroy(gameObject);
		}
	}
}
