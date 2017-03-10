using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHorizontalUi : MonoBehaviour {

    public GameObject[] power_panels;
    float move_x;
    Hashtable anim_ht;

    private void Start()
    {
        move_x = power_panels[0].GetComponent<RectTransform>().position.x - power_panels[1].GetComponent<RectTransform>().position.x;
        print(move_x);

        

    }

    public void onNextClicked()
    {
        for(int i = 0; i < power_panels.Length; i++)
        {
            anim_ht = new Hashtable();
            anim_ht.Add("x", power_panels[i].GetComponent<RectTransform>().position.x + move_x);
            anim_ht.Add("time", 0.3f);
            iTween.MoveTo(power_panels[i].gameObject, anim_ht);
        }
    }

    public void onPrevClicked()
    {
        for (int i = 0; i < power_panels.Length; i++)
        {
            anim_ht = new Hashtable();
            anim_ht.Add("x", power_panels[i].GetComponent<RectTransform>().position.x - move_x);
            anim_ht.Add("time", 0.3f);
            iTween.MoveTo(power_panels[i].gameObject, anim_ht);
        }
    }

}
