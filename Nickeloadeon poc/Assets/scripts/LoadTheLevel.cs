using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheLevel : MonoBehaviour {

    AsyncOperation async;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void LoadLevel(int level_no)
    {
        PlayerPrefs.SetInt("level_no", level_no);
        async =  SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
    }

}
