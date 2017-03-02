using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FollowTouch : MonoBehaviour {

    public Button[] buttons;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {

            Vector3 targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(targetpos.z > -8.8f)
            {
                gameObject.transform.position = new Vector3(targetpos.x, gameObject.transform.position.y, targetpos.z);
            }
         
        } else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved))
                {
                    Plane plane = new Plane(Vector3.up, transform.position);
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    float dist;
                    if (plane.Raycast(ray, out dist))
                    {
                        Vector3 targetpos = ray.GetPoint(dist);
                        if (targetpos.z > -8.8f)
                        {
                            transform.position = targetpos;
                        }
                    }
                }
            }
        }
   }
}
