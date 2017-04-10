using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatterKillMonster : MonoBehaviour {


    int damage_done;
    public GameObject monsterhit_particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster" || other.gameObject.tag == "shootingmonster")
        {
            if (gameObject.name == "chatter_main")
            {
                try
                {
                    damage_done = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().getDamageByChatter();
                }
                catch(System.Exception e)
                {
                    damage_done = GameObject.FindGameObjectWithTag("LevelController").GetComponent<InfiniteLevelController>().getDamageByChatter();
                }
           }
            else
            {
                try
                {
                    damage_done = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().getDamageByPan();
                }
                catch(System.Exception e)
                {
                    damage_done = GameObject.FindGameObjectWithTag("LevelController").GetComponent<InfiniteLevelController>().getDamageByPan();
                }
           }
            //Destroy(other.gameObject);
            Instantiate(monsterhit_particle, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 1f), other.transform.rotation);
            MonsterHealthController mhc = other.gameObject.GetComponent<MonsterHealthController>();
            mhc.hitByBullet();
            mhc.setHealth(mhc.getHealth() - damage_done);
        }
    }
}
