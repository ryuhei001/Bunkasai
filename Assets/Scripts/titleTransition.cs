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
		GamepadState inSta1 = GamepadInput.GamePad.GetState(GamePad.Index.One);
		GamepadState inSta2 = GamepadInput.GamePad.GetState(GamePad.Index.Two);
		GamepadState inSta3 = GamepadInput.GamePad.GetState(GamePad.Index.Three);
		GamepadState inSta4 = GamepadInput.GamePad.GetState(GamePad.Index.Four);
		if (inSta1.A == true || inSta1.B == true || inSta1.X == true) {
			Application.LoadLevel ("SampleScene");
		}
	}
}
