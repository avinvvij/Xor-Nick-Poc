using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraMover : MonoBehaviour {

    int scrolltouchId = -1;
    Vector3 scrolltouchorigin;
    Vector3 camerainitialpos , finalpos;
    bool canscroll = true;

    private void Start()
    {
        camerainitialpos = Camera.main.transform.position;
        finalpos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 14.02f); 
    }

    public bool getCanScroll()
    {
        return this.canscroll;
    }

    public void setCanScroll(bool new_canscroll)
    {
        this.canscroll = new_canscroll;
    }

    private void Update()
    {


        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            
            Vector3 lastPos = Vector3.zero;
            Vector3 delta = Vector3.zero;
                if (Input.GetMouseButtonDown(0))
                {
               
                lastPos = Input.mousePosition;
                lastPos = Camera.main.ScreenToWorldPoint(lastPos);
            }
                else if (Input.GetMouseButton(0))
                {
                    
                    delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastPos;
                // Do Stuff here

                Vector3 CameraPos = Camera.main.transform.position;
                if(CameraPos.z >= -13.5f && CameraPos.z <= 15f && canscroll == true)
                    Camera.main.transform.position = new Vector3(CameraPos.x, CameraPos.y, CameraPos.z + (delta.y * 0.05f));
                
                // End do stuff

                lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
            }else if (Input.GetMouseButtonUp(0))
            {
                if (Camera.main.transform.position.z < -10f)
                {
                    iTween.MoveTo(Camera.main.gameObject,camerainitialpos, 0.5f);
                }
                if (Camera.main.transform.position.z > 15f)
                {
                    iTween.MoveTo(Camera.main.gameObject, finalpos, 0.5f);
                }
            }
        }else {
            foreach (Touch t in Input.touches)
            {
                if (canscroll == true)
                {
                    if (t.phase == TouchPhase.Began)
                    {
                        if (scrolltouchId == -1)
                        {
                            scrolltouchId = t.fingerId;
                            scrolltouchorigin = t.position;
                        }
                    }
                    //Forget it when the touch ends
                    if ((t.phase == TouchPhase.Ended) || (t.phase == TouchPhase.Canceled))
                    {
                        scrolltouchId = -1;
                        if (Camera.main.transform.position.z < -10f)
                        {
                            iTween.MoveTo(Camera.main.gameObject, camerainitialpos, 0.5f);
                        }
                        if (Camera.main.transform.position.z > 15f)
                        {
                            iTween.MoveTo(Camera.main.gameObject, finalpos, 0.5f);
                        }
                    }
                    if (t.phase == TouchPhase.Moved)
                    {
                        //If the finger has moved and it's the finger that started the touch, move the camera along the Y axis.
                        if (t.fingerId == scrolltouchId)
                        {
                            Vector3 CameraPos = Camera.main.transform.position;
                            if (CameraPos.z >= -13.5f && CameraPos.z <= 15f)
                            {
                                Camera.main.transform.position = new Vector3(CameraPos.x, CameraPos.y, CameraPos.z - (t.deltaPosition.y * 0.05f));
                            }
                        }
                    }
                }
            }
        }
    }

}
