using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("destroySelf", 3f);
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }

}
