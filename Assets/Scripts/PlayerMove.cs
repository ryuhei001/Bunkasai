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
    //for boost
    public float boostSpeed = 1.0f;
   // Rigidbody rigidBody;
    public float touchDelay = 0.5f;
    public bool isBoostF = false;
	private float boostDelay;
	public float BOOST_DELAY = 7.0f;
    public bool isMashF = false;
	private float boostSec = BOOST_SEC;
	public static float BOOST_SEC = 1.0f;
	public float rotVerSpeed=1.5f;
	//回る角度 = GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).〇 * rotSpeed * (ROT_ACC * rotCountTime)
	public float ROT_MAX_ACC_X = 3;  //回転の最高加速度
	public float rotCountTimeX = 0;	//押し続けられている時間
	public float ROT_ACC_X = 10f;  //加速度
	public float rotCountTimeY = 0;
	public float ROT_MAX_ACC_Y = 3;
	public float ROT_ACC_Y = 10f;
	void Start () {
        mainCam = transform.Find("Main Camera1");
        boostDelay = BOOST_DELAY;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController chCon = GetComponent<CharacterController> ();
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
		Rigidbody rigidBody = GetComponent<Rigidbody>();
		//Debug.Log ("worldPosition"+transform.TransformDirection(moveDir));
		if (!chCon.isGrounded) {
			if (Physics.Linecast (rayPos.position, (rayPos.position - transform.up * rayRan))) {
				isGround = true;
			} else {
				isGround = false;

			}
		}

		if (chCon.isGrounded||isGround||isGround==false||chCon.isGrounded==false) {
            if (isMashF == false && isBoostF == false)
            {
			
                if(GamePad.GetButtonUp(GamePad.Button.B, GamePad.Index.One)){
                    isMashF = true;
                }
            }else {
				if(touchDelay >= 0) {
					if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One) && boostDelay <= 0){
                        //rigidBody.AddForce(Vector3.forward * boostSpeed, ForceMode.VelocityChange);
						//rigidBody.velocity += (Vector3.forward * boostSpeed) * Time.fixedDeltaTime;
						//rigidBody.velocity += transform.forward * boostSpeed;
						//chCon.Move(transform.forward * boostSpeed);
						isBoostF = true;
						boostDelay = BOOST_DELAY;
						//chCon.velocity += transform.forward * boostSpeed;
						Debug.Log("boost");
						isMashF = false;
						touchDelay = 0.5f;
                    }
				} else {
					isMashF = false;
					touchDelay = 0.5f;
				}
                touchDelay -= Time.deltaTime;
            }
			if(isBoostF) {
				if(boostSec >= 0) {
					chCon.Move(transform.forward * boostSpeed * Mathf.Sqrt(boostSec)*Time.deltaTime);
					boostSec -= Time.deltaTime;
				}else {
					boostSec = BOOST_SEC;
					isBoostF = false;
				}
			}else {
				boostDelay -= Time.deltaTime;
			}
			if (inSta.B == true) {
				moveDir = new Vector3 (0, 0, 1);
			} else if (inSta.X) {
				moveDir = new Vector3 (0, 0, -1);
			} else if (inSta.X == false && inSta.B == false) {
				moveDir = new Vector3 (0, 0, 0);
			}

			/*if(Input.GetKeyDown("KeyCode.UpArrow") == true){
				moveDir = new Vector3(0,0,1);
			}else if(Input.GetKeyDown("KeyCode.DownArrow") == true){
				moveDir = new Vector3(0,0,-1);
			}
			if(Input.GetKeyDown("KeyCode.A") == true){
				transform.Rotate(0,-1*rotSpeed,0);
			}else if(Input.GetKeyDown("KeyCode.D") == true){
				transform.Rotate(0,1*rotSpeed,0);
			}*/

			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			//視点移動がされていないときはCountをリセット
			float acc = 0;
			if(GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).x == 0){
				rotCountTimeX = 0;
			}else{
				rotCountTimeX += Time.deltaTime;
			}
			acc = ROT_ACC_X * rotCountTimeX;
			if(acc > ROT_MAX_ACC_X){
				acc = ROT_MAX_ACC_X;
			}
			transform.Rotate (0, GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).x * rotSpeed * acc, 0);

			acc = 0;
			if(GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y == 0){
				rotCountTimeY = 0;
			}else{
				rotCountTimeY += Time.deltaTime;
			}
			acc = ROT_ACC_Y * rotCountTimeY;
			if(acc > ROT_MAX_ACC_Y){
				acc = ROT_MAX_ACC_Y;
			}
			Vector3 angles = mainCam.eulerAngles;
			if(angles.x > 180 && angles.x < 340 && GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y > 0)
			{
				angles = new Vector3(340, angles.y, angles.z);
			}
			else if(angles.x <= 180 && angles.x > 20 && GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y <= 0)
			{
				angles = new Vector3(20, angles.y, angles.z);
			}
			else
			{
				mainCam.eulerAngles = new Vector3(angles.x + GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y * rotVerSpeed * acc * -1, angles.y, angles.z);
			}

			//Debug.Log ("true");
		} else {
			//Debug.Log ("false2");
		}
		moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);
	}
		/*if(inSta.X == true){
			Debug.Log ("X");
		}else{
			Debug.Log("IsNotX");
		}*/

		/*moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);*/

}
