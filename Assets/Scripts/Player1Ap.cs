using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ap : MonoBehaviour {
	public int armerPoint = 100;
	public int damage = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player4Shot"){
			armerPoint -= damage;
			Debug.Log ("hit");
		}
		if(armerPoint<0){
			Destroy(gameObject);
		}
	}
}
