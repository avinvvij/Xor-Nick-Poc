using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationComplete : MonoBehaviour {

    Hashtable anim_scale_destination_object;
    static Vector3 init_scale;
    static int flag = 0;

    public void onCoinAnimationComplete(GameObject destination_object)
    {
        if(flag == 0)
        {
            init_scale = destination_object.transform.localScale;
            flag = 1;
        }
        anim_scale_destination_object = new Hashtable();
        anim_scale_destination_object.Add("x", destination_object.transform.localScale.x * 1.01);
        anim_scale_destination_object.Add("y", destination_object.transform.localScale.y * 1.01);
        anim_scale_destination_object.Add("z", destination_object.transform.localScale.z * 1.01);
        anim_scale_destination_object.Add("time", 0.001f);
        anim_scale_destination_object.Add("oncomplete", "scaleanimationcomplete");
        anim_scale_destination_object.Add("oncompleteparams", init_scale);
        iTween.ScaleTo(destination_object, anim_scale_destination_object);
        Destroy(gameObject);
        
    }

}
