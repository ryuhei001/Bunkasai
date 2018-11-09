using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerMove : MonoBehaviour {
	public float speed = 15f;
	public float jumpSpeed = 8f;
	public float gra = 20f;
	private Vector3 moveDir = Vector3.zero;
	public float rotSpeed = 10f;

	// Use this for initialization
	private AnimatorStateInfo animInfo;
	private Animator anim;
	public Transform rayPos;
	public float rayRan = 0.85f;
	public bool isGround;
    private Transform mainCam;
	void Start () {
		anim = GetComponent<Animator> ();
        mainCam = transform.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.Two);
		CharacterController chCon = GetComponent<CharacterController> ();

		//Debug.Log ("worldPosition"+transform.TransformDirection(moveDir));
		if (!chCon.isGrounded) {
			if (Physics.Linecast (rayPos.position, (rayPos.position - transform.up * rayRan))) {
				isGround = true;
				Debug.Log ("Debug");
			} else {
				isGround = false;
			}
		if (chCon.isGrounded||isGround) {
				if (inSta.X == true) {
				}
			moveDir = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed, 0);
            //float rotateX = (transform.eulerAngles.x > 180) ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
            //float angleX = Mathf.Clamp(rotateX + Input.GetAxis("Vertical") * rotSpeed * -1, minAngle, maxAngle);
            //angleX = (angleX < 0) ? angleX + 360 : angleX;
            //float eulerAngleX = Mathf.Clamp(mainCam.eulerAngles.x + Input.GetAxis("Vertical"), minAngle, maxAngle);
            Vector3 angles = mainCam.eulerAngles;
            Debug.Log(mainCam.eulerAngles.x);
            if(angles.x > 180 && angles.x < 340 && Input.GetAxis("Vertical") > 0)
            {
                angles = new Vector3(340, angles.y, angles.z);
            }
            else if(angles.x <= 180 && angles.x > 20 && Input.GetAxis("Vertical") <= 0)
            {
                angles = new Vector3(20, angles.y, angles.z);
            }
            else
            {
                mainCam.eulerAngles = new Vector3(angles.x + Input.GetAxis("Vertical") * rotSpeed * -1, angles.y, angles.z);
            }
            //transform.RotateAround(transform.position, transform.right, Input.GetAxis("Horizontal") * rotSpeed);

			if (Input.GetButton ("Jump")) {
				
				moveDir.y = jumpSpeed;
			} else {
				moveDir.y -= gra * Time.deltaTime;
			}
			//Debug.Log ("true");
		} else {
			//Debug.Log ("false");
		}

        


		moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);
	}
		if(inSta.X == true){
			Debug.Log ("X");
		}else{
			Debug.Log("IsNotX");
		}

}
}
