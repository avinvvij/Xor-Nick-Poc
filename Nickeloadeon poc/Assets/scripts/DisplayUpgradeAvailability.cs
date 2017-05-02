using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class DisplayUpgradeAvailability : MonoBehaviour {

    public GameObject avl_def, avl_power , avl_attack ,self_avl;
    
    public void checkAvailability(JsonData configdata , JsonData progress_data)
    {
        self_avl.SetActive(false);
        avl_attack.SetActive(false);
        avl_def.SetActive(false);
        avl_power.SetActive(false);
        int total_coins = int.Parse(configdata["coins_collected"].ToString());
        if (total_coins >= int.Parse(progress_data["attack"][0]["update_cost"].ToString()))
        {
            avl_attack.SetActive(true);
            self_avl.SetActive(true);
        }else
        {
            avl_attack.SetActive(false);
        }
        if(total_coins >= int.Parse(progress_data["defence"][0]["update_cost"].ToString())){
            avl_def.SetActive(true);
            self_avl.SetActive(true);
        }
        else
        {
            avl_def.SetActive(false);
        }
        for (int i = 0; i < progress_data["powers"].Count; i++)
        {
            if(total_coins >= int.Parse(progress_data["powers"][i]["update_cost"].ToString()))
            {
                avl_power.SetActive(true);
                self_avl.SetActive(true);
                break;
            }else
            {
                avl_power.SetActive(false);
            }
        }
    }
    

}
