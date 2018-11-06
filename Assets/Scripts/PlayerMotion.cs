using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour {
    public GameObject bomb;

	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0) {
            ani.SetInteger("Vertical", 1);
        } else if (Input.GetAxis("Vertical") < 0) {
            ani.SetInteger("Vertical", -1);
        } else {
            ani.SetInteger("Vertical", 0);
        }
		ani.SetBool ("Jump", Input.GetButton ("Jump"));
        //射撃処理
        if (Input.GetMouseButtonUp(0))
        {
            GameObject newBomb = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 4.93f, transform.position.z), transform.rotation);
            newBomb.GetComponent<BombScript>().SetVelocity(transform.forward);
        }
	}
}
