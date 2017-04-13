using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonsterPathNodesUpdate : MonoBehaviour {

    public float min_val, max_val;

	// Use this for initialization
	void Start () {
        float my_random_x = Random.Range(min_val, max_val);
        gameObject.transform.GetChild(1).position = new Vector3(my_random_x, gameObject.transform.GetChild(1).position.y, gameObject.transform.GetChild(1).position.z);
        my_random_x = Random.Range(min_val, max_val);
        gameObject.transform.GetChild(2).position = new Vector3(my_random_x, gameObject.transform.GetChild(2).position.y, gameObject.transform.GetChild(2).position.z);
    }
	
}
