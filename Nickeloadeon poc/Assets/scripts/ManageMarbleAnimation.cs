using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMarbleAnimation : MonoBehaviour {



    Hashtable ht_scale_up, ht_scale_down;
    public Vector3 initial_scale;
    public float animation_time = 0.1f;
    public float scale_factor = 0.5f;
    GameObject marble_controller;

	// Use this for initialization
	void Start () {
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");


        //initializing scale up animation
        ht_scale_up = new Hashtable();
        ht_scale_up.Add("x",initial_scale.x + scale_factor);
        ht_scale_up.Add("y", initial_scale.y + scale_factor);
        ht_scale_up.Add("z", initial_scale.z + scale_factor);
        ht_scale_up.Add("time", animation_time);
        ht_scale_up.Add("easetype", iTween.EaseType.linear);
        ht_scale_up.Add("oncomplete", "onScaleUpComplete");

        ht_scale_down = new Hashtable();
        ht_scale_down.Add("x", initial_scale.x);
        ht_scale_down.Add("y", initial_scale.y);
        ht_scale_down.Add("z", initial_scale.z);
        ht_scale_down.Add("time", animation_time);
        ht_scale_down.Add("easetype", iTween.EaseType.linear);
        ht_scale_down.Add("oncomplete", "onScaleDownComplete");
    }
	
    public void playAnimation()
    {
        iTween.ScaleTo(gameObject, ht_scale_up);
    }

    public void onScaleUpComplete()
    {
        iTween.ScaleTo(gameObject, ht_scale_down);
        marble_controller.GetComponent<MarbleScoreController>().add_to_marble_count(1);
    }

}
