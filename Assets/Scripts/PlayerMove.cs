using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour {
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
	void Start () {
		anim = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
		CharacterController chCon = GetComponent<CharacterController> ();

		//Debug.Log ("worldPosition"+transform.TransformDirection(moveDir));
		if (!chCon.isGrounded) {
			if (Physics.Linecast (rayPos.position, (rayPos.position - transform.up * rayRan))) {
				isGround = true;
			} else {
				isGround = false;
			}
		}

		if (chCon.isGrounded||isGround) {
			moveDir = new Vector3 (0, 0, Input.GetAxis ("Vertical2"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			transform.Rotate (0, Input.GetAxis ("Horizontal2") * rotSpeed, 0);

			if (Input.GetButton ("Jump")) {
				
				moveDir.y = jumpSpeed;
			} else {
				moveDir.y -= gra * Time.deltaTime;
			}
			//Debug.Log ("true");
		} else {
			//Debug.Log ("false2");
		}
		moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);
	}
}
