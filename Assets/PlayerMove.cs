using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject bomb;
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
		CharacterController chCon = GetComponent<CharacterController> ();

		Debug.Log ("worldPosition"+transform.TransformDirection(moveDir));
		if (!chCon.isGrounded) {
			if (Physics.Linecast (rayPos.position, (rayPos.position - transform.up * rayRan))) {
				isGround = true;
			} else {
				isGround = false;
			}
		}

		if (chCon.isGrounded||isGround) {
			moveDir = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed, 0);
            
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
            //射撃処理
            if (Input.GetMouseButtonUp(0))
            {
                GameObject newBomb = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 4.93f, transform.position.z), transform.rotation);
                newBomb.GetComponent<BombScript>().SetVelocity(mainCam.forward);
            }

            if (Input.GetButton ("Jump")) {
				
				moveDir.y = jumpSpeed;
			} else {
				moveDir.y -= gra * Time.deltaTime;
			}
			Debug.Log ("true");
		} else {
			Debug.Log ("false");
		}

        


		moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);
	}
}
