﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatterKillMonster : MonoBehaviour {


    public int damage_done = 20;
    public GameObject monsterhit_particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster" )
        {
            //Destroy(other.gameObject);
            Instantiate(monsterhit_particle, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 1f), other.transform.rotation);
            MonsterHealthController mhc = other.gameObject.GetComponent<MonsterHealthController>();
            mhc.hitByBullet();
            mhc.setHealth(mhc.getHealth() - damage_done);
        }
    }
}
