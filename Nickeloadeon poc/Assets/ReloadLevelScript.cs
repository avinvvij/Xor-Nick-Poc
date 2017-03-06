using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReloadLevel()
    {
        PlayerPrefs.SetInt("level_no", GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().getLevel_No());
        Application.LoadLevel(0);
    }

}
