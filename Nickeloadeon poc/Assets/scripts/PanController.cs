using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanController : MonoBehaviour {

    public float animation_time = 0.5f;
    Hashtable ht = new Hashtable();

	// Use this for initialization
	void Start () {
        ht.Add("x", -90f);
        ht.Add("time", animation_time);
        ht.Add("oncomplete", "pananimationdone");

        // gameObject.transform.rotation = Quaternion.Euler(new Vector3(-130f , 0f , -90f));
        iTween.RotateTo(gameObject, ht);
    }
    
    public void pananimationdone()
    {
        Destroy(gameObject);
    }

}
