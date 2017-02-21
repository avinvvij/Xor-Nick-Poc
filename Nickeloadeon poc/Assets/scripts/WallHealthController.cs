using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealthController : MonoBehaviour {

    public int wallhealth = 100;
    GameObject[] crate_children;
    bool color_changed = false;
    bool game_over = false;

	// Use this for initialization
	void Start () {
        crate_children = new GameObject[transform.childCount - 1];
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).tag == "crate")
            {
                crate_children[i] = transform.GetChild(i).gameObject;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(wallhealth <= 50 && color_changed == false)
        {
            color_changed = true;
            
            for(int i = 0; i <crate_children.Length; i++)
            {
                crate_children[i].GetComponent<Renderer>().material.color = Color.Lerp(crate_children[i].GetComponent<Renderer>().material.color, Color.red, 45f * Time.deltaTime );
            }
        }
		if(wallhealth <= 0 && game_over == false)
        {
            print("game over");
            game_over = true;
            for (int i = 0; i < crate_children.Length; i++)
            {
                crate_children[i].GetComponent<Renderer>().material.color = Color.Lerp(crate_children[i].GetComponent<Renderer>().material.color, Color.black, 45f * Time.deltaTime);
            }
        }
	}

    public int getWallHealth()
    {
        return this.wallhealth;
    }

    public void setWallHealth(int new_health)
    {
        this.wallhealth = new_health;
    }

}
