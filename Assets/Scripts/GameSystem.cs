using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   
public class GameSystem : MonoBehaviour {
    public static int ready = 0; //準備完了した人数
    public static bool isGameStarted = false;
    private AudioSource[] audioSources; //複数の音楽ファイルを追加した時に対応できるように配列
    public float exitTime = 5;
	// Use this for initialization
	void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
        audioSources[0].Play();
        exitTime = 5;

    }
	
	// Update is called once per frame
	void Update () {
        if(isGameStarted == false){
            if(ready == 4){
                isGameStarted = true;
            }
        }

        if(!audioSources[0].isPlaying){
            audioSources[0].Play();
        }
        

        if(RankingSystemScript.Ranking <= 1) {
            if(exitTime<0){
                ready = 0;
                isGameStarted = false;
                RankingSystemScript.Ranking = 4;
                Application.LoadLevel("title");
            
            }
            exitTime -= Time.deltaTime;    
        }
    }
}
