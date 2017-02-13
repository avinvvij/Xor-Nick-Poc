using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCrate : MonoBehaviour {

    bool collisiontocrate = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "crate")
        {
            //print("collided to crate");
            //we need to stop the monster here
            gameObject.GetComponent<MonsterMove>().enabled = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().drag = 1000f;
            Animator anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
            anim.SetBool("attack", true);
            collisiontocrate = true;
        }
    }

    public bool getcollisiontocrate()
    {
        return this.collisiontocrate;
    }

}
