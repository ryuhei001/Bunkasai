using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class PlayerReady3 : MonoBehaviour {
    Image readyImage;
    Image OKImage;
    bool isWaited = false;

    // Use this for initialization
    void Start () {
        GetComponent<PlayerMotion4>().enabled = false;
        GetComponent<PlayerMove4>().enabled = false;
        readyImage = GameObject.Find("AreYouReady3").GetComponent<Image>();
        OKImage = GameObject.Find("OK3").GetComponent<Image>();
        OKImage.enabled = false;
        readyImage.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isWaited == false){
			if (GamePad.GetButtonUp(GamePad.Button.A, GamePad.Index.Four)||GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).x>0) {
                GameReady();
            }
        }
        if(GameSystem.isGameStarted == true){
            GameStart();
            this.enabled = false;
        }
	}

    void GameReady()
    {
        isWaited = true;
        OKImage.enabled = true;
        readyImage.enabled = false;
        GameSystem.ready ++;
    }

    void GameStart()
    {
        GetComponent<PlayerMotion4>().enabled = true;
        GetComponent<PlayerMove4>().enabled = true;
        OKImage.enabled = false;
        readyImage.enabled = false;
    }
}
