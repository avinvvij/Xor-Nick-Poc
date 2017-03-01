using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public GameObject bullet,barrellfollower,shootlight;
    Hashtable ht;
    bool canshoot = true;
    public float bulletspeed = -10f , bulletcreatetime = 0.55f;
    Ray shootray;
    GameObject tank_smoke;
    GameObject level_controller;
    LevelController level_controller_script;
    // Use this for initialization
    void Start () {
        level_controller = GameObject.FindGameObjectWithTag("LevelController");
        level_controller_script = level_controller.GetComponent<LevelController>();
        tank_smoke = transform.GetChild(0).transform.GetChild(0).gameObject;
        ht = new Hashtable();
        ht.Add("z", gameObject.transform.position.z + 0.3f);
        ht.Add("time" , bulletcreatetime);
        ht.Add("looptype",iTween.LoopType.pingPong);
        ht.Add("onstart", "makeashoot");
        iTween.MoveTo(gameObject, ht);
        shootray = new Ray();
    }

    private void FixedUpdate()
    {
        
    }

    public void makeashoot()
    {
        if (canshoot && level_controller_script.tank_canshoot == true)
        {
            //print("ill shoot here");
            //print("" + transform.TransformDirection(gameObject.transform.position));
            //mybullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(gameObject.transform.position));
            shootlight.GetComponent<Light>().enabled = true;
            Vector3 direction = gameObject.transform.position - barrellfollower.transform.position;
            Vector3 direction1 = new Vector3(direction.normalized.x, 0.0f, direction.normalized.z);
            direction1 = direction1.normalized;
            GameObject mybullet = (GameObject)Instantiate(bullet, gameObject.transform.GetChild(0).transform.position,Quaternion.Euler(90f , 0.0f , 0.0f));

            mybullet.GetComponent<Rigidbody>().AddForce(new Vector3(direction1.x , 0.0f , direction1.z)* 30 * bulletspeed, ForceMode.Impulse);
            tank_smoke.SetActive(true);
            shootray.origin = gameObject.transform.GetChild(0).transform.position;
            shootray.direction = direction;
            Invoke("switchOffLight", 0.2f);
        }
        canshoot = !canshoot;
    }

    public void switchOffLight()
    {
        tank_smoke.SetActive(false);
        shootlight.GetComponent<Light>().enabled = false;
    }

}
