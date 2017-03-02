using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleAnimation : MonoBehaviour {

    RectTransform rect_transform;

    Hashtable anim_up , anim_down , anim_to_marbles;
    public float animation_factor;


	// Use this for initialization
	void Start () {
        //animation to move the marble up
        anim_up = new Hashtable();
        anim_up.Add("z" , gameObject.transform.position.z + 2f);
        anim_up.Add("time",animation_factor);
        anim_up.Add("oncomplete", "onUpAnimationComplete");
        anim_up.Add("easetype", iTween.EaseType.linear);
        iTween.MoveTo(gameObject , anim_up);

        //animation initializatiion of moving marble down
        anim_down = new Hashtable();
        anim_down.Add("z", gameObject.transform.position.z - 2f);
        anim_down.Add("time", animation_factor);
        anim_down.Add("oncomplete", "onAnimationDownComplete");
        anim_down.Add("easetype", iTween.EaseType.linear);

        //animation initialization of moving the marble towards marbles
        anim_to_marbles = new Hashtable();
        rect_transform = GameObject.FindGameObjectWithTag("marbles").GetComponent<RectTransform>();
        Vector3 result;
        result = Camera.main.ScreenToWorldPoint(rect_transform.TransformPoint(0.0f, 0.0f, 0.0f));
        result = new Vector3(result.x, 2.313f, result.z);
        anim_to_marbles.Add("x", result.x);
        anim_to_marbles.Add("y", result.y);
        anim_to_marbles.Add("z", result.z);
        anim_to_marbles.Add("time", 0.3f);
        anim_to_marbles.Add("easetype", iTween.EaseType.linear);
        anim_to_marbles.Add("oncomplete", "onAnimToMarbleComplete");
        

    }
	
    public void onUpAnimationComplete()
    {
        iTween.MoveTo(gameObject, anim_down); 
    }


    public void onAnimationDownComplete()
    {
        iTween.MoveTo(gameObject, anim_to_marbles);
    }

    public void onAnimToMarbleComplete()
    {
        GameObject.FindGameObjectWithTag("marbles").GetComponent<ManageMarbleAnimation>().playAnimation();
        Destroy(gameObject);
    }

}
