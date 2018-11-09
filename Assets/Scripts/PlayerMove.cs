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
<<<<<<< HEAD
	void Start () {
		anim = GetComponent<Animator> ();


=======
    private Transform mainCam;
    //for boost
    public float boostSpeed = 1.0f;
    Rigidbody rigidBody;
    public float touchDelay = 0.5f;
    public bool isBoostF = false;
    public bool isMashF;
	void Start () {
        mainCam = transform.Find("Main Camera1");
        rigidBody = GetComponent<Rigidbody>();
>>>>>>> boost
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
<<<<<<< HEAD
			moveDir = new Vector3 (0, 0, Input.GetAxis ("Vertical2"));
=======
            if (isMashF == false)
            {
                if(GamePad.GetButtonUp(GamePad.Button.B, GamePad.Index.One) {
                    isMashF = true;
                }
            }else {
                if(isBoostF == false) {
                    if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One) {
                        if (touchDelay >= 0)
                        {
                            isBoostF = true;
                            rigidBody.AddForce(transform.forward * boostSpeed, ForceMode.Acceleration);
                        }
                    }
                }else {
                    if(GamePad.GetButtonUp(GamePad.Button.B, GamePad.Index.One) {
                        isMashF = false;
                        isBoostF = false;
                    }
                }
                
                touchDelay -= Time.deltaTime;
            }
			if (inSta.X == true) {
				moveDir = new Vector3 (0, 0, 1);
			} else if (inSta.B) {
				moveDir = new Vector3 (0, 0, -1);
			} else if (inSta.X == false && inSta.B == false) {
				moveDir = new Vector3 (0, 0, 0);
			}
>>>>>>> boost
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
<<<<<<< HEAD
=======
		/*if(inSta.X == true){
			Debug.Log ("X");
		}else{
			Debug.Log("IsNotX");
		}*/

		/*moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);*/
    void BoostF() {

    }
>>>>>>> boost
}
