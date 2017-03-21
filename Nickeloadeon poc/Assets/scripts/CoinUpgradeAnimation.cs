using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class CoinUpgradeAnimation : MonoBehaviour {

    public GameObject coins;
    Hashtable anim_ht;
    Vector3 destination;
    float invoke_time = 0.1f;
    JsonData coin_data, progress_data;
    public string type, data_name;
    public GameObject out_of_coins_panel;

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
        coin_data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "\\configuration.json"));
        int coins = int.Parse(coin_data["coins_collected"].ToString());
        progress_data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "\\playerprogress.json"));
        int required_coins = coins + 1;
        for (int i = 0; i < progress_data["" + type + ""].Count; i++)
        {
            if(progress_data[""+type+""][i]["name"].ToString() == data_name)
            {
                required_coins = int.Parse(progress_data[type][i]["update_cost"].ToString());
            }
        }
        if (coins >= required_coins)
        {
            destination = gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>().position;
            anim_ht = new Hashtable();
            anim_ht.Add("x", destination.x);
            anim_ht.Add("y", destination.y);
            anim_ht.Add("time", 0.3f);
            anim_ht.Add("oncomplete", "onCoinAnimationComplete");
            anim_ht.Add("oncompleteparams", gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject);
            for (int i = 0; i < 5; i++)
            {
                Invoke("coin_generate", invoke_time);
                invoke_time += 0.1f;
            }
            invoke_time = 0.1f;
            int updated_coins = coins - required_coins;
            coin_data["coins_collected"] = ""+updated_coins+"";
            File.WriteAllText (Application.persistentDataPath+"\\configuration.json" ,  JsonMapper.ToJson(coin_data).ToString());
            for (int i = 0; i < progress_data["" + type + ""].Count; i++)
            {
                if (progress_data["" + type + ""][i]["name"].ToString() == data_name)
                {
                    int new_attack = int.Parse(progress_data[type][i]["attack"].ToString()) + (int.Parse(progress_data[type][i]["next_update"].ToString()) - int.Parse(progress_data[type][i]["attack"].ToString()));
                    int new_req_coins = required_coins*2;
                    int new_next_update = int.Parse(progress_data[type][i]["next_update"].ToString()) + (int.Parse(progress_data[type][i]["next_update"].ToString()) - int.Parse(progress_data[type][i]["attack"].ToString()));
                    //print(new_attack + " " + new_req_coins + " " + new_next_update);
                    progress_data[type][i]["attack"] = ""+new_attack+"";
                    progress_data[type][i]["next_update"] = ""+new_next_update+"";
                    progress_data[type][i]["update_cost"] = ""+new_req_coins+""; 
                }
            }
            File.WriteAllText(Application.persistentDataPath + "\\playerprogress.json", JsonMapper.ToJson(progress_data).ToString());
            GameObject.FindGameObjectWithTag("LevelConfigHandler").GetComponent<LevelConfiguration>().UiUpdate();
        } else
        {
            out_of_coins_panel.SetActive(true);
            out_of_coins_panel.GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
        }
    }


}
