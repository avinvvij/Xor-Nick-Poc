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

    private void Start()
    {
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");
        marble_score = marble_controller.GetComponent<MarbleScoreController>();
        start_time = Time.time;
        loading_image.fillAmount = 1f;
    }

    private void Update()
    {
        if(start_time > Time.time)
        {
            loading_image.fillAmount += 1.0f / time_interval * Time.deltaTime;
        }
    }

    public void createChatter()
    {
        if (start_time < Time.time && marble_score.getMarbleCount() >= 5)
        {
            Instantiate(chatter, instantiateposition.transform.position, chatter.transform.rotation);
            start_time = Time.time + time_interval;
            loading_image.fillAmount = 0f;
            marble_score.add_to_marble_count(-5);
        }
    }
}
