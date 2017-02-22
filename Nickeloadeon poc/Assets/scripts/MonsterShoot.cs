using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour {

    public GameObject monster_bullet;
    public float time_interval = 0.8f;
    float start_time = 0f;


	// Use this for initialization
	void Start () {
        transform.GetChild(0).GetComponent<Animator>().SetBool("attack", true);
        start_time = Time.time + time_interval;
	}
	
	// Update is called once per frame
	void Update () {
		if(start_time <= Time.time)
        {
            Instantiate(monster_bullet, gameObject.transform.position+new Vector3(0f , 1.2f , 0f), monster_bullet.transform.rotation);
            start_time = Time.time + time_interval;
        }
	}
}
