using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAnimationSpeed : MonoBehaviour {
    Animator anim;
    public float animspeed = 3.0f;

	// Use this for initialization
	void Start () {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim.speed = animspeed;
	}
   
}
