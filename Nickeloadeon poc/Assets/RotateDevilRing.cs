using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDevilRing : MonoBehaviour {
    public float rotation_factor = 2f;
	
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + ( rotation_factor * Time.deltaTime));	
	}
}
