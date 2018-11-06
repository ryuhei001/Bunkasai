using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour {

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
	}
}
