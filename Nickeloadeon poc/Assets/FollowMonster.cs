using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMonster : MonoBehaviour {

    GameObject[] monsters;
    Transform monster;
    NavMeshAgent navagent;
	// Use this for initialization
	void Start () {
        navagent = GetComponent<NavMeshAgent>();
        monsters = GameObject.FindGameObjectsWithTag("monster");
        monster = monsters[0].GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        navagent.SetDestination(monster.position);
	}
}
