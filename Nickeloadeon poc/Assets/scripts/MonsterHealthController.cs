using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthController : MonoBehaviour {

    public int health = 10;
    Animator animation_handler;
    public GameObject blood_puddle , blood_mash;
    Image blood_pd_img;
    public GameObject blue_marble,green_marble,red_marble;
    public int marbles_generated;
    AudioSource monster_death_sound;
    AudioSource monster_squeak_sound;
    GameObject monster_death_sound_gameobject;
	
	void Start () {
        animation_handler = this.transform.GetChild(0).GetComponent<Animator>();
        monster_death_sound_gameobject = GameObject.FindGameObjectWithTag("monster_death_sound");
        monster_death_sound = monster_death_sound_gameobject.GetComponent<AudioSource>();
        monster_squeak_sound = gameObject.GetComponent<AudioSource>();

    }
	
	
	void Update () {

        if (this.health <= 0)
        {
            if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
            {
                try
                {
                    monster_death_sound.Play();
                }catch(System.Exception e)
                {

                }
            }
                float x_factor = 0.0f;
            for(int i = 0; i < marbles_generated; i++)
            {
                int marble_icon = Random.Range(0,3);
                switch (marble_icon)
                {
                    case 0:
                        Instantiate(blue_marble, gameObject.transform.position + new Vector3(x_factor, 0f , 0f), blue_marble.transform.rotation);
                        break;
                    case 1:
                        Instantiate(green_marble, gameObject.transform.position + new Vector3(x_factor, 0f, 0f), green_marble.transform.rotation);
                        break;
                    case 2:
                        Instantiate(red_marble, gameObject.transform.position + new Vector3(x_factor, 0f, 0f), red_marble.transform.rotation);
                        break;
                }
                x_factor = x_factor + 0.5f;
                
            }

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
        }else if(gameObject.GetComponent<FlyingMonsterPathRandom>()!=null)
        {
            GetComponent<FlyingMonsterPathRandom>().enabled = false;
        }else
        {
            GetComponent<FlyingMonsterPath>().enabled = false;
        }
        if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
        {
            try
            {
                monster_squeak_sound.Play();
            }catch(System.Exception e)
            {

            }
        }
        Invoke("stopBulletAnimation", 0.15f);
    }

    public void stopBulletAnimation()
    {
        animation_handler.SetBool("hitbybullet", false);
        if (gameObject.name != "monster4_main")
        {
            try
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1f) * gameObject.GetComponent<MonsterMove>().getMonsterSpeed(), ForceMode.Impulse);
            }catch( System.Exception e)
            {

            }
        }
        else if(gameObject.GetComponent<CollisionCrate>().getcollisiontocrate() == false)
        {
            if (gameObject.GetComponent<FlyingMonsterPathRandom>() != null)
                GetComponent<FlyingMonsterPathRandom>().enabled = true;
            else
                GetComponent<FlyingMonsterPath>().enabled = true;
        }
    }


    

}
