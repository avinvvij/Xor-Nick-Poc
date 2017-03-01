using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    Hashtable ht;
    private GameObject level_controller;

	// Use this for initialization
	void Start () {
        level_controller = GameObject.FindGameObjectWithTag("LevelController");
        ht = new Hashtable();
        ht.Add("x", 1f);
        ht.Add("y", 1f);
        ht.Add("z", 1f);
        ht.Add("easetype", iTween.EaseType.linear);
        ht.Add("time", 0.8f);
        ht.Add("oncomplete", "onWaveAnimationComplete");
        ht.Add("oncompletetarget", level_controller);
        iTween.ShakePosition(Camera.main.gameObject , ht);
    }
	
}
