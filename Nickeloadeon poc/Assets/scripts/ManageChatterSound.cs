using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageChatterSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("sound_effect", 1) == 0)
        {
            GetComponent<AudioSource>().Stop();
        }

    }
	
}
