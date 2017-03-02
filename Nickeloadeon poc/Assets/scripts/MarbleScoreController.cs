using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleScoreController : MonoBehaviour {

    int marble_count = 0;
    public Text marble_count_text;

	// Use this for initialization
	void Start () {
        marble_count_text.text = marble_count + "";
	}
	
    public int getMarbleCount()
    {
        return this.marble_count;
    }

    public void setMarbleCount(int new_count)
    {
        this.marble_count = new_count;
        marble_count_text.text = marble_count + "";
    }

    public void add_to_marble_count(int add_factor)
    {
        this.marble_count = marble_count + add_factor;
        marble_count_text.text = marble_count + "";
    }

}
