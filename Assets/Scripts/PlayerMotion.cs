using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerMotion : MonoBehaviour {
    public GameObject bomb;

	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
		if (inSta.X == true) {
            ani.SetInteger("Vertical", 1);
		} else if ( inSta.B == true) {
            ani.SetInteger("Vertical", -1);
        } else {
            ani.SetInteger("Vertical", 0);
        }
		if (inSta.A==true)
        {
            GameObject newBomb = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 4.93f, transform.position.z), transform.rotation);
            newBomb.GetComponent<BombScript>().SetVelocity(transform.forward);
        }
	}
}
