﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonster : MonoBehaviour {

    bool monsterkilled = false;
    public GameObject monsterhit_particle;

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "monster" || other.gameObject.tag == "shootingmonster") && monsterkilled == false)
        {
            Instantiate(monsterhit_particle, new Vector3(other.gameObject.transform.position.x , other.gameObject.transform.position.y, other.gameObject.transform.position.z + 1f), other.transform.rotation);
            monsterkilled = true;
            //Destroy(other.gameObject);
            MonsterHealthController mhc = other.gameObject.GetComponent<MonsterHealthController>();
            mhc.hitByBullet();
            mhc.setHealth(mhc.getHealth() - 10);
            Destroy(gameObject);
        }
    }
}
