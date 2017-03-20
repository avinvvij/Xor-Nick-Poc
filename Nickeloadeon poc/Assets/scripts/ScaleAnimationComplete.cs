using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimationComplete : MonoBehaviour {

    Hashtable scale_down_ht;

	public void scaleanimationcomplete(Vector3 init_scale)
    {
        scale_down_ht = new Hashtable();
        scale_down_ht.Add("x", init_scale.x);
        scale_down_ht.Add("y", init_scale.y);
        scale_down_ht.Add("z", init_scale.z);
        scale_down_ht.Add("time", 0.001f);
        iTween.ScaleTo(gameObject, scale_down_ht);
    }
}
