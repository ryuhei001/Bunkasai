using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1Ap : MonoBehaviour {
    
    GameObject player1;
    [SerializeField] GameObject OtherCamera1;
    [SerializeField] GameObject OtherCamera2;
    [SerializeField] GameObject OtherCamera3;
    [SerializeField] GameObject OtherCamera4;
    Slider HP_Slider1;
	public int armerPoint1 = 100;
	public int damage1 = 10;
    int Ranking01;

	// Use this for initialization
	void Start () {
        player1 = GameObject.FindWithTag("bunkasai_player");
        HP_Slider1 = GameObject.FindWithTag("HitPoint1").GetComponent<Slider>();
        armerPoint1 = 100;
    }
	
	// Update is called once per frame
	void Update () {


		
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player4Shot"){
			armerPoint1 -= damage1;
            HP_Slider1.value = armerPoint1;
		}
		if(armerPoint1<0){
            OtherCamera1.SetActive(true);
            Ranking01 = GetComponent<RankingScript>().Ranking;
            GetComponent<RankingScript>().ReturnAccess();
            GetComponent<RankingScript>().Ranking -= 1;
            //Ranking01 -= 1;
            Destroy(player1);

		}
	}
}
