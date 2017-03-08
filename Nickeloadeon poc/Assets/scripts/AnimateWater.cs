using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWater : MonoBehaviour {

    public float scrollspeed = 0.4f;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = scrollspeed * Time.time;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset,0));
	}
}
