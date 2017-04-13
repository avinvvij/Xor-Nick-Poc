using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonsters : MonoBehaviour {

    public GameObject[] monsters;
    public float timeinterval;
    float createtime = 0f;

    // x ranges in -7.2 to +7.2
	// Use this for initialization
	void Start () {
        createtime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (createtime <= Time.time)
        {
            float randomx = Random.Range(-7.2f, 7.2f);
            int monsterselect = Random.Range(0, monsters.Length);
            GameObject monster = null;
            switch (monsterselect) {
                case 0:
                    monster = (GameObject)Instantiate(monsters[0], new Vector3(randomx, 2.21f, 15.6f), monsters[0].transform.rotation);
                    break;
                case 1:
                    monster = (GameObject)Instantiate(monsters[1], new Vector3(randomx, 2.21f, 15.6f), monsters[1].transform.rotation);
                    break;
                case 2:
                    monster = (GameObject)Instantiate(monsters[2], new Vector3(randomx, 2.21f, 15.6f), monsters[2].transform.rotation);
                    break;
                case 3:
                    monster = (GameObject)Instantiate(monsters[3], new Vector3(randomx, 2.21f, 15.6f), monsters[3].transform.rotation);
                    break;
                case 4:
                    monster = (GameObject)Instantiate(monsters[4], new Vector3(randomx, 2.21f, 15.6f), monsters[4].transform.rotation);
                    break;

            }
            createtime = Time.time + timeinterval;
        }
	}
}
