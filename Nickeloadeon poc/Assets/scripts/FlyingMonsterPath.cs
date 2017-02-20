using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonsterPath : MonoBehaviour
{

    public PathEditor mypathmanager;
    public int currentwypointid;
    public float speed;
    public float reachDist = 0.05f;
    public float rotspeed = 0.5f;
    GameObject path;

    Vector3 last_position;
    Vector3 current_position;

    // Use this for initialization
    void Start()
    {
        mypathmanager = gameObject.transform.parent.transform.GetChild(0).GetComponent<PathEditor>();
        last_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(mypathmanager.points[currentwypointid].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, mypathmanager.points[currentwypointid].position, speed * Time.deltaTime);

        //var rotation = Quaternion.LookRotation(mypathmanager.points[currentwypointid].position - transform.position);
        //rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x - 90f, rotation.eulerAngles.y, gameObject.transform.rotation.z);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

        if (distance <= reachDist)
        {
            currentwypointid += 1;
        }
        if (currentwypointid == mypathmanager.points.Count)
        {
            
        }

    }
}
