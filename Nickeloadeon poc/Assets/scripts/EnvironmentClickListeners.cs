using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentClickListeners : MonoBehaviour {
    Ray ray;
    public GameObject monster_details;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    if(hit.collider.tag == "menumonster" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        monster_details.SetActive(true);
                        monster_details.transform.GetChild(1).GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
                    }
                    if(hit.collider.gameObject.name == "way_to_arcade" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        PlayerPrefs.SetInt("level_no", 1000);
                        AsyncOperation async = SceneManager.LoadSceneAsync(1);
                        
                        async.allowSceneActivation = (false);
                        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
                        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
                    }
                }
            }
        }else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "menumonster" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        monster_details.SetActive(true);
                        monster_details.transform.GetChild(1).GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
                        Camera.main.GetComponent<TouchCameraMover>().setCanScroll(false);
                    }
                    if (hit.collider.gameObject.name == "way_to_arcade" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        PlayerPrefs.SetInt("level_no", 1000);
                        AsyncOperation async = SceneManager.LoadSceneAsync(1);
                        async.allowSceneActivation = (false);
                        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
                        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
                    }
                }
            }
        }
	}
}
