using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public float monsterspeed = -10f;
    Rigidbody rb;
    float random_z; //range from 2.12 to 8.9

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.0f , 0.0f , 1f)*monsterspeed, ForceMode.Impulse);
        if(gameObject.tag == "shootingmonster")
        {
            random_z = Random.Range(2.12f , 8.9f);
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.z <= random_z && gameObject.tag == "shootingmonster")
        {
            rb.velocity = Vector3.zero;
            gameObject.GetComponent<MonsterShoot>().enabled = true;
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
