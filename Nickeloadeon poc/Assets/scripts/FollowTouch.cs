using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Vector3 targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(targetpos.x, gameObject.transform.position.y, targetpos.z);
        }else
        {
            //Vector3 targetpos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);
            //gameObject.transform.position = new Vector3(targetpos.x, gameObject.transform.position.y, targetpos.z);
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    // If the finger is on the screen, move the object smoothly to the touch position
                    Plane plane = new Plane(Vector3.up, transform.position);
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    float dist;
                    if (plane.Raycast(ray, out dist))
                    {
                        transform.position = ray.GetPoint(dist);
                    }
                }
            }
        }
   }
}
