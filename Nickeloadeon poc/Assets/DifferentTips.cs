using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferentTips : MonoBehaviour {

    Text infotext;
    string[] tips = {"The more marbles you collect, the more powers you can use" , "Different levels require different stratergies" , "Combine different powers to gain more from a level" , "Killing the right monster at the right time is the key to win"}; 

	// Use this for initialization
	void Start () {
        changeTip();
    }
	

    public void changeTip()
    {
        infotext = GetComponent<Text>();
        int random_tip_no = Random.Range(0, 4);
        infotext.text = tips[random_tip_no];
    }

}
