using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimateUpgradePanel : MonoBehaviour {

    float move_factor;
    public float time_factor = 0.2f;
    Hashtable anim_ht , anim_down_ht;
    Vector3 initpos;

	// Use this for initialization
	void Start () {

        initpos = gameObject.GetComponent<RectTransform>().position;
        anim_ht = new Hashtable();
        move_factor = gameObject.transform.parent.transform.position.y;
        anim_ht.Add("y", move_factor);
        anim_ht.Add("time", time_factor);
        anim_ht.Add("oncomplete", "onUpAnimationComplete");
        iTween.MoveTo(gameObject, anim_ht);
        anim_down_ht = new Hashtable();
        anim_down_ht.Add("y", initpos.y);
        anim_down_ht.Add("time", time_factor);
        anim_down_ht.Add("oncomplete", "ondownanimationcomplete");

    }
	
    public void animateTheUpgradePanel()
    {
        anim_ht = new Hashtable();
        move_factor = gameObject.transform.parent.transform.position.y;
        anim_ht.Add("y", move_factor);
        anim_ht.Add("time", time_factor);
        anim_ht.Add("oncomplete", "onUpAnimationComplete");
        iTween.MoveTo(gameObject, anim_ht);
        
    }

    public void onUpAnimationComplete()
    {
        //if pause screen panel
        if (gameObject.name == "game_paused_panel")
        {
            Time.timeScale = 0;
        }
    }

    public void onCloseClicked()
    {
        anim_down_ht = new Hashtable();
        anim_down_ht.Add("y", initpos.y);
        anim_down_ht.Add("time", time_factor);
        anim_down_ht.Add("oncomplete", "ondownanimationcomplete");
        iTween.MoveTo(gameObject, anim_down_ht);
    }

    public void playDownAnimation()
    {
        anim_down_ht = new Hashtable();
        anim_down_ht.Add("y", initpos.y);
        anim_down_ht.Add("time", time_factor);
        iTween.MoveTo(gameObject, anim_down_ht);
    }

    public void ondownanimationcomplete()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
