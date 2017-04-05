using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                }
            }
        }
	}
}
