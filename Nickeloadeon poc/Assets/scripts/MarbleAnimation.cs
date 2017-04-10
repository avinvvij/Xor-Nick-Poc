using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleAnimation : MonoBehaviour {

    RectTransform rect_transform;

    Hashtable anim_up , anim_down , anim_half_up , anim_half_down, anim_to_marbles;
    public float animation_factor;
    public float min_move_factor = 1f, max_move_factor = 2f;
    GameObject marble_controller;


    // Use this for initialization
    void Start () {
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");

        //animation to move the marble up
        anim_up = new Hashtable();
        anim_up.Add("z" , gameObject.transform.position.z + Random.Range(min_move_factor , max_move_factor));
        anim_up.Add("time",animation_factor);
        anim_up.Add("oncomplete", "onUpAnimationComplete");
        iTween.MoveTo(gameObject , anim_up);

        //animation initializatiion of moving marble down
        anim_down = new Hashtable();
        anim_down.Add("z", gameObject.transform.position.z - Random.Range(min_move_factor, max_move_factor));
        anim_down.Add("time", animation_factor);
        anim_down.Add("oncomplete", "onAnimationDownComplete");


        //animation initialization of moving marble half up
        anim_half_up = new Hashtable();
        anim_half_up.Add("z", gameObject.transform.position.z + Random.Range(min_move_factor/2, max_move_factor/2));
        anim_half_up.Add("time", animation_factor/2);
        anim_half_up.Add("oncomplete", "onAnimationHalfUpComplete");


        //animation initialization of moving marble half down
        anim_half_down = new Hashtable();
        anim_half_down.Add("z", gameObject.transform.position.z - Random.Range(min_move_factor / 2, max_move_factor / 2));
        anim_half_down.Add("time", animation_factor/2);
        anim_half_down.Add("oncomplete", "onAnimationHalfDownComplete");

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
        iTween.MoveTo(gameObject,  anim_half_up);
    }

    public void onAnimToMarbleComplete()
    {
        try
        {
            GameObject.FindGameObjectWithTag("marbles").GetComponent<ManageMarbleAnimation>().playAnimation();
        }catch(System.Exception e)
        {

        }
        marble_controller.GetComponent<MarbleScoreController>().add_to_marble_count(1);
        Destroy(gameObject);

    }

    public void onAnimationHalfUpComplete()
    {
        iTween.MoveTo(gameObject, anim_half_down);
    }

    public void onAnimationHalfDownComplete()
    {
        iTween.MoveTo(gameObject, anim_to_marbles);
    }

}
