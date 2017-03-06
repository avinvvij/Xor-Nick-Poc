using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour {

    Hashtable ht_move_in , ht_move_out;
    private GameObject level_controller;

	// Use this for initialization
	void Start () {
        level_controller = GameObject.FindGameObjectWithTag("LevelController");

        ht_move_in = new Hashtable();
        ht_move_in.Add("x", 0.2f);
        ht_move_in.Add("easetype", iTween.EaseType.linear);
        ht_move_in.Add("time", 0.8f);
        ht_move_in.Add("oncomplete", "onWaveControllerAnimationComplete");
        iTween.MoveTo(gameObject , ht_move_in);

        ht_move_out = new Hashtable();
        ht_move_out.Add("x", 15.5f);
        ht_move_out.Add("easetype", iTween.EaseType.linear);
        ht_move_out.Add("delay", 0.3f);
        ht_move_out.Add("time", 0.8f);
        ht_move_out.Add("oncomplete", "onWaveAnimationComplete");
        ht_move_out.Add("oncompletetarget", level_controller);

    }


    public void onWaveControllerAnimationComplete()
    {
        iTween.MoveTo(gameObject, ht_move_out);
    }


}
