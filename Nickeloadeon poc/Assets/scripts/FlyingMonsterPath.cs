using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlyingMonsterPath : MonoBehaviour
{

    public PathEditor mypathmanager;
    public int currentwypointid;
    public float speed;
    public float reachDist = 0.05f;
    public float rotspeed = 0.5f;
    GameObject path;
    Animator anim;
    public bool isboss = false;
    public float boss_shoot_time = 0.55f , boss_nextmove_time = 0.75f;

    Vector3 last_position;
    Vector3 current_position;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        last_position = transform.position;
        makeNextMove();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(new Vector3(mypathmanager.points[currentwypointid].position.x , 0f , mypathmanager.points[currentwypointid].position.z), new Vector3(transform.position.x ,0f, transform.position.z));
        //Debug.Log(distance + " " + mypathmanager.points[currentwypointid].position + " " + transform.position) ;
        //var rotation = Quaternion.LookRotation(mypathmanager.points[currentwypointid].position - transform.position);
        //rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x - 90f, rotation.eulerAngles.y, gameObject.transform.rotation.z);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

        if (distance <= reachDist)
        {
            if (isboss) {
                currentwypointid = (currentwypointid + 1) % (mypathmanager.points.Count);
                anim.SetBool("attack", true);
                anim.speed = 6f;
                Invoke("makeBossShoot", boss_shoot_time);
                Invoke("makeNextMove", boss_nextmove_time);
            } else
            {
                currentwypointid += 1;
                makeNextMove();
            }
        }
       

    }

    private void makeNextMove()
    {
        if (isboss)
        {
            anim.SetBool("attack", false);
            anim.speed = 3f;
        }
        Hashtable ht = new Hashtable();
        ht.Add("x", mypathmanager.points[currentwypointid].position.x);
        ht.Add("z", mypathmanager.points[currentwypointid].position.z);
        ht.Add("speed", speed);
        ht.Add("easetype", iTween.EaseType.linear);
        iTween.MoveTo(gameObject, ht);
    }

    public void makeBossShoot()
    {
        gameObject.GetComponent<BossShoot>().makeAShoot();
    }

    public void setpathManager( GameObject pathmanager) 
    {
        this.mypathmanager = pathmanager.GetComponent<PathEditor>();
    }

}
