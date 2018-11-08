﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Ap : MonoBehaviour {
    
    [SerializeField] GameObject OtherCamera1;
    [SerializeField] GameObject OtherCamera2;
    [SerializeField] GameObject OtherCamera3;
    [SerializeField] GameObject OtherCamera;
    GameObject player2;
    Slider HP_Slider2;
	public int armerPoint2 = 100;
	public int damage2 = 10;
    int Ranking02;

	// Use this for initialization

	void Start () {
        player2 = GameObject.FindWithTag("bunkasai_player(1)");
        HP_Slider2 = GameObject.FindWithTag("HitPoint2").GetComponent<Slider>();
        armerPoint2 = 100;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player1Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player4Shot"){
			armerPoint2 -= damage2;
            HP_Slider2.value = armerPoint2;
		}

		if(armerPoint2<0){
            OtherCamera2.SetActive(true);
            Ranking02 = GetComponent<RankingScript>().Ranking;
            GetComponent<RankingScript>().ReturnAccess();
            
            GetComponent<RankingScript>().Ranking -= 1;
            Destroy(player2);          
		}
	}
}
