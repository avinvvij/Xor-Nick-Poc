using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUpgradeAnimation : MonoBehaviour {

    public GameObject coins;
    Hashtable anim_ht;
    Vector3 destination;
    float invoke_time = 0.1f;

	// Use this for initialization
	void Start () {
        
    }
	
    public void coin_generate()
    {
        GameObject temp_coins = (GameObject)Instantiate(coins, gameObject.GetComponent<RectTransform>().localPosition, coins.transform.rotation);
        temp_coins.transform.SetParent(gameObject.transform);
        temp_coins.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
        iTween.MoveTo(temp_coins, anim_ht);
    }

    public void HandleUpgradeClick()
    {
        destination = gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>().position;
        anim_ht = new Hashtable();
        anim_ht.Add("x", destination.x);
        anim_ht.Add("y", destination.y);
        anim_ht.Add("time", 0.3f);
        anim_ht.Add("oncomplete", "onCoinAnimationComplete");
        anim_ht.Add("oncompleteparams", gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject);
        for (int i = 0; i<5; i++)
        {
            Invoke("coin_generate", invoke_time);
            invoke_time += 0.1f;
        }
        invoke_time = 0.1f;
    }


}
