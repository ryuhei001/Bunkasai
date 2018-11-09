using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReady : MonoBehaviour {
    public bool isGameStarted = false;

    Image readyImage;
    Image OKImage;

	// Use this for initialization
	void Start () {
        readyImage = GameObject.Find("AreYouReady").GetComponent<Image>();
        OKImage = GameObject.Find("OK").GetComponent<Image>();
        OKImage.enabled = false;
	}

    public void GameReady() {
        readyImage.enabled = false;
        OKImage.enabled = true;
    }

    public void GameStart() {
        readyImage.enabled = false;
        OKImage.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(GameSystem.ready == 4) {
            isGameStarted = true;
        }
	}
}
