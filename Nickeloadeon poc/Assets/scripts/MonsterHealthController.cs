using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthController : MonoBehaviour {

    public int health = 10;
    Animator animation_handler;
    public GameObject blood_puddle , blood_mash;
    Image blood_pd_img;
	
	void Start () {
        animation_handler = this.transform.GetChild(0).GetComponent<Animator>();
	}
	
	
	void Update () {
        if (this.health <= 0)
        {
            //Instantiate(blood_mash, gameObject.transform.position - new Vector3(0f, 2f, 0f), Quaternion.Euler(90f, 0f, 0f));
            GameObject bp = (GameObject) Instantiate(blood_puddle, gameObject.transform.position - new Vector3(0f,2f,0f) , Quaternion.Euler(90f , 0f, 0f));
            blood_pd_img = bp.GetComponentInChildren<Image>();
            blood_pd_img.color = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.GetColor("_Color");
            if (gameObject.name == "monster4_main")
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            }
    }

    public int getHealth()
    {
        return this.health;
    }

    public void setHealth(int new_health)
    {
        this.health = new_health;
    }

    public void hitByBullet()
    {
        animation_handler.SetBool("hitbybullet" , true);
        if (gameObject.name != "monster4_main")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }else
        {
            GetComponent<FlyingMonsterPath>().enabled = false;
        }
            Invoke("stopBulletAnimation", 0.1f);
    }

    public void stopBulletAnimation()
    {
        animation_handler.SetBool("hitbybullet", false);
        if (gameObject.name != "monster4_main")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1f) * gameObject.GetComponent<MonsterMove>().getMonsterSpeed(), ForceMode.Impulse);
        }
        else if(gameObject.GetComponent<CollisionCrate>().getcollisiontocrate() == false)
        {
            GetComponent<FlyingMonsterPath>().enabled = true;
        }
    }

}
