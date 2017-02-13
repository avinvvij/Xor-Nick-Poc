using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public float monsterspeed = -10f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.0f , 0.0f , 1f)*monsterspeed, ForceMode.Impulse);
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
