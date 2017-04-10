using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingAnimation : MonoBehaviour {

    public float scale_factor , time_factor;
    Hashtable ht;
	// Use this for initialization
	void Start () {
        ht = new Hashtable();
        ht.Add("x", scale_factor);
        ht.Add("y", scale_factor);
        ht.Add("z", scale_factor);
        ht.Add("looptype", iTween.LoopType.pingPong);
        ht.Add("time", time_factor);
        iTween.ScaleTo(gameObject, ht);
	}
	
}
