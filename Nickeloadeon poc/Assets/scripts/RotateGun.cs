using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour {

    float rotateyangle;

	// Use this for initialization
	void Start () {
        rotateyangle = 0f;	
	}

    public void FixedUpdate()
    {
        
            transform.eulerAngles = new Vector3(270f , rotateyangle , 0f);
    }

    public void setRotateyangle(float yangle)
    {
        this.rotateyangle = yangle;
    }

}
