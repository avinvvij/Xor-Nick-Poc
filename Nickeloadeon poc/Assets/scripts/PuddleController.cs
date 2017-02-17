using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.ScaleTo(gameObject, new Vector3(0f, 0f, 0f), 25f);
        Invoke("destroySelf", 3f);
	}

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
