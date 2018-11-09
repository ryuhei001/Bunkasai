using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class titleTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
		if (inSta.A == true || inSta.B == true || inSta.X == true) {
			Application.LoadLevel ("SampleScene");
		}
	}
}
