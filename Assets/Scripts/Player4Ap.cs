﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player4Ap : MonoBehaviour {
    GameObject player4;
    Slider HP_Slider4;
	public int armerPoint4 = 100;
	public int damage4 = 10;
    [SerializeField] GameObject OtherCamera4;
    

	// Use this for initialization
	void Start () {
        player4 = GameObject.FindWithTag("bunkasai_player(3)");
        HP_Slider4 = GameObject.FindWithTag("HitPoint4").GetComponent<Slider>();
        armerPoint4 = 100;
	}

	// Update is called once per frame
	void Update () {
        if (RankingSystemScript.Ranking == 1)
        {
            OtherCamera4.SetActive(true); 
        }
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player1Shot"){
			armerPoint4 -= damage4;
            HP_Slider4.value = armerPoint4;

		}
		if(armerPoint4<0){
            OtherCamera4.SetActive(true);
			Destroy(gameObject);
		}
	}
}
