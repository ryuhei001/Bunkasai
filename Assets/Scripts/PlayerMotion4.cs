﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerMotion4 : MonoBehaviour {
    public GameObject bomb;

	private Animator ani;
    public Transform gun;
    public Transform Camera;
    private AudioSource[] audioSources;

    // Use this for initialization
    void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.Four);
		if (inSta.B == true) {
            ani.SetInteger("Vertical", 1);
		} else if ( inSta.X == true) {
            ani.SetInteger("Vertical", -1);
        } else {
            ani.SetInteger("Vertical", 0);
        }
		if (GamePad.GetButtonUp(GamePad.Button.A, GamePad.Index.Four))
        {
            GameObject newBomb = Instantiate(bomb,gun.transform.position, Camera.transform.rotation);
            newBomb.GetComponent<BombScript1>().SetVelocity(transform.forward);
            audioSources[0].Play();
        }
	}
}
