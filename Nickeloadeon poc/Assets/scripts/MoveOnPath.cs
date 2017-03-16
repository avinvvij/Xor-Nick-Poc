using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    
    public PathEditor mypathmanager;
    public int currentwypointid;
    public float speed;
    public float reachDist = 0.05f;
    public float rotspeed = 0.5f;
    public string pathname;

    Vector3 last_position;
    Vector3 current_position;
    LevelController level_controller_script;

    // Use this for initialization
    void Start()
    {
        level_controller_script = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        mypathmanager = GameObject.Find(pathname).GetComponent<PathEditor>();
        last_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_controller_script.getGamePaused() == false)
        {
            float distance = Vector3.Distance(mypathmanager.points[currentwypointid].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, mypathmanager.points[currentwypointid].position, speed * Time.deltaTime);

            var rotation = Quaternion.LookRotation(mypathmanager.points[currentwypointid].position - transform.position);
            rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x - 90f, rotation.eulerAngles.y, gameObject.transform.rotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

            if (distance <= reachDist)
            {
                currentwypointid += 1;
            }
            if (currentwypointid == mypathmanager.points.Count)
            {
                Destroy(gameObject);
            }
        }
    }
}
