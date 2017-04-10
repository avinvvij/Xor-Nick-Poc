using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class ManageHomeClick : MonoBehaviour {

    public GameObject exit_panel;
    AsyncOperation async;

	public void onHomeClicked()
    {
        exit_panel.SetActive(true);
    }

    public void onYesClicked()
    {
        Time.timeScale = 1;
        try
        {
            async = SceneManager.LoadSceneAsync(0);
        }catch(System.Exception e)
        {

        }
        async.allowSceneActivation = false;
        Camera.main.GetComponent<Grayscale>().enabled = false;
        Camera.main.GetComponent<BlurOptimized>().enabled = false;
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().setMoveFactor(-15);
        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().setMoveFactor(15);
        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
    }

    public void onNoClicked()
    {
        exit_panel.SetActive(false);
    }
}
