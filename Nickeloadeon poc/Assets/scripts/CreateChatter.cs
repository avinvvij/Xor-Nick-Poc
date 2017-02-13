using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateChatter : MonoBehaviour {

    public GameObject chatter , instantiateposition;
    public Image loading_image;
    float start_time;
    public float time_interval = 1f;

    private void Start()
    {
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
        print(start_time + " " + Time.time);
        if (start_time < Time.time)
        {
            Instantiate(chatter, instantiateposition.transform.position, chatter.transform.rotation);
            start_time = Time.time + time_interval;
            loading_image.fillAmount = 0f;
        }
    }
}
