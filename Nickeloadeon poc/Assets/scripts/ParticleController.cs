using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    public float destroy_time = 3f;

	// Use this for initialization
	void Start () {

        Invoke("destroySelf", destroy_time);
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }

}
