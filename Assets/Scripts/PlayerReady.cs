using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReady : MonoBehaviour {
    public bool isGameStarted = false;
    public bool isWaited = false;

    Image readyImage;
    Image OKImage;

    

	// Use this for initialization
	void Start () {
        readyImage = GameObject.Find("AreYouReady").GetComponent<Image>();
        OKImage = GameObject.Find("OK").GetComponent<Image>();
        OKImage.enabled = false;
        readyImage.enabled = true;
	}

    public void GameReady() {
        readyImage.enabled = false;
        OKImage.enabled = true;
        isWaited = true;
        GameSystem.ready ++;
    }

    public void GameStart() {
        readyImage.enabled = false;
        OKImage.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*if(GameSystem.ready == 4) {
            isGameStarted = true;
        }*/
	}
}
