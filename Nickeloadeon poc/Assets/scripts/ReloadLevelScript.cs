using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class ReloadLevelScript : MonoBehaviour {

    AsyncOperation async;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReloadLevel()
    {
        PlayerPrefs.SetInt("level_no", GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().getLevel_No());
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        Camera.main.GetComponent<Grayscale>().enabled = false;
        Camera.main.GetComponent<BlurOptimized>().enabled = false;
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().setMoveFactor(-15);
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().setMoveFactor(15);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
    }

    public void TakeToPreviousMenu()
    {
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;
        Camera.main.GetComponent<Grayscale>().enabled = false;
        Camera.main.GetComponent<BlurOptimized>().enabled = false;
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().setMoveFactor(-15);
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().setMoveFactor(15);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
    }
}
