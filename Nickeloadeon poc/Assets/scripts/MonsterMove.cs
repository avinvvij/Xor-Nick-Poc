using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public float monsterspeed = -10f;
    Rigidbody rb;
    float random_z; //range from 2.12 to 8.9
    GameObject levelcontroller;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.0f , 0.0f , 1f)*monsterspeed, ForceMode.Impulse);
        if(gameObject.tag == "shootingmonster")
        {
            random_z = Random.Range(2.12f , 8.9f);
        }
        levelcontroller = GameObject.FindGameObjectWithTag("LevelController");
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.z <= random_z && gameObject.tag == "shootingmonster")
        {
            rb.velocity = Vector3.zero;
            gameObject.GetComponent<MonsterShoot>().enabled = true;
        }
        if(levelcontroller.GetComponent<LevelController>().getGamePaused() == true)
        {
            rb.velocity = Vector3.zero;
        }


        if(gameObject.transform.position.x <= -7.1f)
        {
            Hashtable anim_move = new Hashtable();
            anim_move.Add("x", -7.0f);
            anim_move.Add("time", 0.2f);
            anim_move.Add("easetype", iTween.EaseType.linear);
            iTween.MoveTo(gameObject, anim_move);
        }

        if (gameObject.transform.position.x >=  7.1f)
        {
            Hashtable anim_move = new Hashtable();
            anim_move.Add("x", 7.0f);
            anim_move.Add("time", 0.2f);
            anim_move.Add("easetype", iTween.EaseType.linear);
            iTween.MoveTo(gameObject, anim_move);
        }

    }

    public float getMonsterSpeed()
    {
        return this.monsterspeed;
    }

    public void setMonsterSpeed(float monsterspeed)
    {
        this.monsterspeed = monsterspeed;
    }

}
