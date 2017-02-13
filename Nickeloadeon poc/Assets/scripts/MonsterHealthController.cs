using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthController : MonoBehaviour {

    public int health = 10;
    Animator animation_handler;

	
	void Start () {
        animation_handler = this.transform.GetChild(0).GetComponent<Animator>();
	}
	
	
	void Update () {
        if (this.health <= 0)
        {
            Destroy(gameObject);
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
        Invoke("stopBulletAnimation", 0.03f);
    }

    public void stopBulletAnimation()
    {
        animation_handler.SetBool("hitbybullet", false);
    }

}
