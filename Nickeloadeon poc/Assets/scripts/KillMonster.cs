using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonster : MonoBehaviour {

    bool monsterkilled = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "monster" && monsterkilled == false)
        {
            monsterkilled = true;
            //Destroy(other.gameObject);
            MonsterHealthController mhc = other.gameObject.GetComponent<MonsterHealthController>();
            mhc.hitByBullet();
            mhc.setHealth(mhc.getHealth() - 10);
            Destroy(gameObject);
        }
    }
}
