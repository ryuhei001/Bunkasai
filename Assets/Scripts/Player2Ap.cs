using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Ap : MonoBehaviour {
    GameObject player2;
    Slider HP_Slider2;
	public int armerPoint2 = 100;
	public int damage2 = 10;
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
            HP_Slider2.value = 0;
            Destroy(player2);          
		}
	}
}
