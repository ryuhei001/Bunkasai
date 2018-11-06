using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detect : MonoBehaviour {

    GameObject player;
    Slider HP_Slider;
    float _hp;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("bunkasai_player1");
        HP_Slider = GameObject.FindWithTag("HitPoint1").GetComponent<Slider>();
        _hp = 100;
        HP_Slider.value = _hp;
	}


	// Update is called once per frame
	
    void Update () {
        


	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "bumb")
        {

            Debug.Log("ダメージ");

            Destroy(this.gameObject); //当たった弾の消去

            //体力の減少と０になると消滅
            //_hp -= 5;

            //if (_hp <= 0) {
              //  Destroy(player);
            //}

        }

    }


}
