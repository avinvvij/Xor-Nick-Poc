﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePan : MonoBehaviour {

    public GameObject pan;
    bool generatepan = false;
    public Image loading_image;
    float start_time;
    public float time_interval = 1f;
    GameObject marble_controller;
    MarbleScoreController marble_score;
    GameObject level_controller;
    AudioSource pan_hit;

    // Use this for initialization
    void Start () {
        //initializing sound
        pan_hit = gameObject.GetComponent<AudioSource>();

        level_controller = GameObject.FindGameObjectWithTag("LevelController");
        start_time = Time.time;
        loading_image.fillAmount = 1f;
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");
        marble_score = marble_controller.GetComponent<MarbleScoreController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (start_time > Time.time)
        {
            loading_image.fillAmount += 1.0f / time_interval * Time.deltaTime;
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (Input.GetMouseButtonDown(0) && generatepan == true)
            {
                Vector3 instantiate_pan_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiate_pan_position = new Vector3(instantiate_pan_position.x, 2.313f, instantiate_pan_position.z);
                GameObject mypan = (GameObject)Instantiate(pan, instantiate_pan_position, pan.transform.rotation);
                //playing pan sound
                if(PlayerPrefs.GetInt("sound_effect",1)==1)
                    pan_hit.Play();
                mypan.transform.position = new Vector3(instantiate_pan_position.x, 2.313f, instantiate_pan_position.z - Mathf.Abs(instantiate_pan_position.z - mypan.transform.GetChild(0).transform.position.z));
                generatepan = false;
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && generatepan == true)
                {

                    Vector3 instantiate_pan_position = Camera.main.ScreenToWorldPoint(touch.position);
                    instantiate_pan_position = new Vector3(instantiate_pan_position.x, 2.313f, instantiate_pan_position.z);
                    GameObject mypan = (GameObject) Instantiate(pan, instantiate_pan_position, pan.transform.rotation);
                    mypan.transform.position = new Vector3(instantiate_pan_position.x, 2.313f, instantiate_pan_position.z - Mathf.Abs(instantiate_pan_position.z - mypan.transform.GetChild(0).transform.position.z));
                    //playing pan sound
                    pan_hit.Play();
                    generatepan = false;
                }
            }
        }
	}

    public void createPan()
    {
        bool tank_shoot_status = true;
        
            tank_shoot_status = level_controller.GetComponent<LevelController>().getTankShootStatus();
        
        if (start_time < Time.time && marble_score.getMarbleCount() >= 5 && tank_shoot_status)
        {
            generatepan = true;
            start_time = Time.time + time_interval;
            loading_image.fillAmount = 0f;
            marble_score.add_to_marble_count(-5);
        }
     }
}
