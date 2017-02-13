using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBulet : MonoBehaviour {

    public float rotation_speed = 75f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.forward * rotation_speed);
	}
}
