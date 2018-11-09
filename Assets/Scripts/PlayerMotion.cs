using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerMotion : MonoBehaviour {
    public GameObject bomb;

	private Animator ani;
    public Transform gun;
    public Transform Camera;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
		if (inSta.B == true) {
            ani.SetInteger("Vertical", 1);
		} else if ( inSta.X == true) {
            ani.SetInteger("Vertical", -1);
        } else {
            ani.SetInteger("Vertical", 0);
        }
		if (inSta.A==true)
        {
            GameObject newBomb = Instantiate(bomb,gun.transform.position, Camera.transform.rotation);
            newBomb.GetComponent<BombScript1>().SetVelocity(transform.forward);
        }
	}
}
