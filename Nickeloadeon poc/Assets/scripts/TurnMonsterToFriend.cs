using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnMonsterToFriend : MonoBehaviour {

    GameObject[] monsters;
    GameObject selected_monster;
    public float shootafter = 0.8f;
    public float friendtomonster_time = 1f;
    public GameObject special_bullet;
    public Image loading_image;
    float start_time;
    public float time_interval = 1f;
    GameObject marble_controller;
    // Use this for initialization
    void Start () {
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");
        start_time = Time.time;
        loading_image.fillAmount = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (start_time > Time.time)
        {
            loading_image.fillAmount += 1.0f / time_interval * Time.deltaTime;
        }
    }

    public void TurnMonsterIntoFriend()
    {
        if (start_time < Time.time && marble_controller.GetComponent<MarbleScoreController>().getMarbleCount() >= 5)
        {
            monsters = GameObject.FindGameObjectsWithTag("monster");
            if (monsters.Length != 0 && monsters != null)
            {
                selected_monster = monsters[0];
                selected_monster.tag = "monsterfriend";
                //selected_monster.transform.rotation = Quaternion.Euler(new Vector3(selected_monster.transform.eulerAngles.x - 50f, 180f , selected_monster.transform.eulerAngles.z));
                Hashtable ht = new Hashtable();
                ht.Add("x", selected_monster.transform.rotation.eulerAngles.x - 50f);
                ht.Add("y", 180f);
                ht.Add("time", 0.2f);
                ht.Add("easetype", iTween.EaseType.linear);
                iTween.RotateTo(selected_monster, ht);
                selected_monster.GetComponent<MonsterMove>().enabled = false;
                selected_monster.GetComponent<MeshCollider>().enabled = false;
                selected_monster.GetComponent<Rigidbody>().velocity = Vector3.zero;
                selected_monster.GetComponent<CollisionMonster>().enabled = false;
                marble_controller.GetComponent<MarbleScoreController>().add_to_marble_count(-5);
                Invoke("shootspecialbullet", shootafter);

            }
            start_time = Time.time + time_interval;
            loading_image.fillAmount = 0f;
        }
    }

    public void shootspecialbullet()
    {
        Instantiate(special_bullet, selected_monster.transform.position, Quaternion.identity);
        Invoke("FriendToMonster", friendtomonster_time);
    }

    public void FriendToMonster()
    {
        Destroy(selected_monster);
        //selected_monster.tag = "monster";
        //Hashtable ht = new Hashtable();
        //ht.Add("x", selected_monster.transform.rotation.eulerAngles.x + 50f);
        //ht.Add("y", 0f);
        //ht.Add("time", 0.2f);
        //ht.Add("easetype", iTween.EaseType.linear);
        //iTween.RotateTo(selected_monster, ht);
        //selected_monster.GetComponent<MonsterMove>().enabled = true;
        //selected_monster.GetComponent<MeshCollider>().enabled = true;
        //selected_monster.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1f) * selected_monster.GetComponent<MonsterMove>().getMonsterSpeed(), ForceMode.Impulse);
        //selected_monster.GetComponent<CollisionMonster>().enabled = true;
    }
}
