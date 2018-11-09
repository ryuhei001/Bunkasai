﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Ap : MonoBehaviour {
    GameObject player3;
    Slider HP_Slider3;
	public int armerPoint3 = 100;
	public int damage3 = 10;
    [SerializeField] GameObject OtherCamera3;


	// Use this for initialization
	void Start () {
        player3 = GameObject.FindWithTag("bunkasai_player(2)");
        HP_Slider3 = GameObject.FindWithTag("HitPoint3").GetComponent<Slider>();
        armerPoint3 = 100;
	}

	// Update is called once per frame
	void Update () {
        if (RankingSystemScript.Ranking == 1)
        {
            OtherCamera3.SetActive(true); 
        }
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player4Shot"
			||collider.gameObject.tag=="Player1Shot"){
			armerPoint3 -= damage3;
            HP_Slider3.value = armerPoint3;
          
		}
		if(armerPoint3<0){
            OtherCamera3.SetActive(true);
			Destroy(player3);
		}
	}
}
