using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AnimateClouds : MonoBehaviour {

    Hashtable anim_ht , anim_seperate_ht;
    public float move_factor;
    public float time_factor;
    public GameObject info_panel;

    public void Start()
    {

    }

    public void AnimateTheClouds(AsyncOperation async = null)
    {
        anim_ht = new Hashtable();
        anim_ht.Add("x", transform.position.x + move_factor);
        anim_ht.Add("time", time_factor);
        anim_ht.Add("easaetype", iTween.EaseType.linear);
        anim_ht.Add("oncomplete", "cloudsanimated");
        if (async != null)
            anim_ht.Add("oncompleteparams", async);
        info_panel.GetComponent<RectTransform>().GetChild(0).GetComponent<DifferentTips>().changeTip();
        info_panel.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCanvas").SetActive(false);
        iTween.MoveTo(gameObject, anim_ht);
       
   }

    public void CloudJoinSimpleAnimation()
    {
        anim_ht = new Hashtable();
        anim_ht.Add("x", transform.position.x + move_factor);
        anim_ht.Add("time", time_factor);
        anim_ht.Add("easaetype", iTween.EaseType.linear);
        info_panel.SetActive(true);
        iTween.MoveTo(gameObject, anim_ht);
    }

    public void CloudSeperateAnimation(float move_x_factor)
    {
        anim_seperate_ht = new Hashtable();
        anim_seperate_ht.Add("x", transform.position.x + move_x_factor);
        anim_seperate_ht.Add("time", time_factor);
        anim_seperate_ht.Add("easetype", iTween.EaseType.linear);
        info_panel.SetActive(false);
        iTween.MoveTo(gameObject, anim_seperate_ht);    
    }
    
	
    public void cloudsanimated(AsyncOperation async = null)
    {
        if (async != null)
        {
            async.allowSceneActivation = true;
        }
    }

    public void setMoveFactor(float new_move_factor)
    {
        this.move_factor = new_move_factor;
    }

}
