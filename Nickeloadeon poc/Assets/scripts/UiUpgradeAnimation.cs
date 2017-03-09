using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiUpgradeAnimation : MonoBehaviour {

    Hashtable anim_ht , anim_hide_ht;
    public float move_x_factor = 0.2f, move_y_factor = 0.2f;
    public float time_factor;
    Vector3 initpos;

	// Use this for initialization
	void Start () {
        initpos = gameObject.GetComponent<RectTransform>().position;

        anim_ht = new Hashtable();
        anim_ht.Add("x",initpos.x - move_x_factor);
        anim_ht.Add("y", initpos.y - move_y_factor);
        anim_ht.Add("time", time_factor);
        anim_ht.Add("easetype", iTween.EaseType.linear);
        animate_ui();

        anim_hide_ht = new Hashtable();
        anim_hide_ht.Add("x",initpos.x);
        anim_hide_ht.Add("y", initpos.y);
        anim_hide_ht.Add("time", time_factor);
        anim_hide_ht.Add("easetype", iTween.EaseType.linear);
        anim_hide_ht.Add("oncomplete", "hideanimcomplete");
    }

    public void animate_ui()
    {
        anim_ht = new Hashtable();
        anim_ht.Add("x", initpos.x - move_x_factor);
        anim_ht.Add("y", initpos.y - move_y_factor);
        anim_ht.Add("time", time_factor);
        anim_ht.Add("easetype", iTween.EaseType.linear);
        iTween.MoveTo(gameObject, anim_ht);
    }

    public void hide_ui()
    {
        iTween.MoveTo(gameObject, anim_hide_ht);
    }

    public void hideanimcomplete()
    {
        gameObject.SetActive(false);
    }
}
