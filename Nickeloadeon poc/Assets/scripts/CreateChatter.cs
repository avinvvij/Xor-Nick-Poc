using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateChatter : MonoBehaviour {

    public GameObject chatter , instantiateposition;
    public Image loading_image;
    float start_time;
    public float time_interval = 1f;
    GameObject marble_controller;
    MarbleScoreController marble_score;
    GameObject level_controller;
    bool update_flag = false;

    private void Start()
    {
        level_controller = GameObject.FindGameObjectWithTag("LevelController");
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");
        marble_score = marble_controller.GetComponent<MarbleScoreController>();
        start_time = Time.time;
        loading_image.fillAmount = 1f;
    }

    private void Update()
    {
            if (start_time > Time.time)
            {
                loading_image.fillAmount += 1.0f / time_interval * Time.deltaTime;
            }
        
    }

    public void createChatter()
    {
        bool tank_shoot_status = true;
        try
        {
            tank_shoot_status = level_controller.GetComponent<LevelController>().getTankShootStatus();
        }catch(System.Exception e)
        {
            tank_shoot_status = level_controller.GetComponent<InfiniteLevelController>().getTankShootStatus();
        }
        if (start_time < Time.time && marble_score.getMarbleCount() >= 5 && tank_shoot_status)
        {
            Instantiate(chatter, instantiateposition.transform.position, chatter.transform.rotation);
            start_time = Time.time + time_interval;
            loading_image.fillAmount = 0f;
            marble_score.add_to_marble_count(-5);
        }
    }
}
