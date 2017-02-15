using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class FollowMonster : MonoBehaviour {

    GameObject[] monsters;
    Transform monster;
    NavMeshAgent navagent;

	// Use this for initialization
	void Start () {
        try
        {
            navagent = GetComponent<NavMeshAgent>();
            monsters = GameObject.FindGameObjectsWithTag("monster");
            monster = monsters[0].GetComponent<Transform>();
        }catch(Exception e)
        {
            Destroy(gameObject);
        }
     }
	
	// Update is called once per frame
	void FixedUpdate () {
        try
        {
            navagent.SetDestination(monster.position);
        }catch(Exception e)
            {
            Destroy(gameObject);
            }
        }
}
