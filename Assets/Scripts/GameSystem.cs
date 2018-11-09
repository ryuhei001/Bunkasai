using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

    private AudioSource[] audioSources; //複数の音楽ファイルを追加した時に対応できるように配列

	// Use this for initialization
	void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
        audioSources[0].Play();
    }
	
	// Update is called once per frame
	void Update () {
        if(!audioSources[0].isPlaying){
            audioSources[0].Play();
        }
    }
}
