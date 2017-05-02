using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour {

    public GameObject monster_bullet;
    float start_time = 0f;
    public GameObject instantiate_position;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public void makeAShoot()
    {
        Instantiate(monster_bullet, new Vector3(instantiate_position.transform.position.x , 2.231399f , instantiate_position.transform.position.z), monster_bullet.transform.rotation);
    }
}
