using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCrate : MonoBehaviour {

    bool collisiontocrate = false;
    float hurt_time = 0f;
    public float time_interval = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "crate")
        {
            //print("collided to crate");
            //we need to stop the monster here
            hurt_time = Time.time + time_interval;
            if(gameObject.GetComponent<FlyingMonsterPath>() != null)
            {
                gameObject.GetComponent<FlyingMonsterPath>().enabled = false;
            }
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().drag = 1000f;
            Animator anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
            anim.SetBool("attack", true);
            collisiontocrate = true;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "crate")
        {
            GameObject monster_wall = other.gameObject.transform.parent.gameObject;
            WallHealthController whc = monster_wall.GetComponent<WallHealthController>();
            if (hurt_time <= Time.time)
            {
                whc.setWallHealth(whc.getWallHealth() - gameObject.GetComponent<WallDamageController>().getDamage_done());
                hurt_time = Time.time + time_interval;
                iTween.ShakePosition(Camera.main.gameObject,new Vector3(0.5f,0f,0.2f),0.2f);
            }
        }
    }

    public bool getcollisiontocrate()
    {
        return this.collisiontocrate;
    }

}
