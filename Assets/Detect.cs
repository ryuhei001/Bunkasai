using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detect : MonoBehaviour {

   
    private Slider HP1;
    float level;

   
  

	// Use this for initialization
	void Start () {
        HP1 = GameObject.Find("Sllider").GetComponent<Slider>();
        HP1.value = 100;
        level = HP1.value;

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.H))
        {
            HP1.value -= 5;
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "bumb")
        {

            Debug.Log("ダメージ");

            //爆発エフェクト生成
            //Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Destroy(this.gameObject); //当たった弾の消去

            //体力の減少と０になると消滅
            HP1.value -= 5;

        }

    }


}
