using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTheLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadLevel(int level_no)
    {
        PlayerPrefs.SetInt("level_no", level_no);
        Application.LoadLevel(1);
    }

}
