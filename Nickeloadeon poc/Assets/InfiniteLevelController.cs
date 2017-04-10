using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityStandardAssets.ImageEffects;

public class InfiniteLevelController : MonoBehaviour
{
    
    private int wave_no = 0;
    public GameObject tank_player;
    public bool tank_canshoot = false;
    Hashtable level_ht, wave_ht;
    bool canshowlevel = false;
    public GameObject victory_particle;
    public GameObject[] wave_rend;
    GameObject current_wave_object;
    bool can_render_next = false;
    public GameObject[] monster_gameobjects;
    public GameObject[] wave_parents;
    public GameObject after_game_panel;
    public Text after_game_text;
    public Text after_game_marble_count, after_game_wall_health, after_game_coins;
    GameObject marble_controller, wall_health_controller;
    bool game_over = false;
    JsonData config_data;
    public GameObject power_select_panel;
    public GameObject[] powers, displayed_powers;
    int[] powers_selected = { 1, 2 };
    public RectTransform[] display_positions;
    private bool gamepaused = false;
    public GameObject pause_button;
    
    public GameObject infinitemontercontroller;

    //declaring variable for bullet , powers damage
    int damage_by_bullet, damage_by_chatter, damage_by_pan, damage_by_monsterfriend;
    int wall_health;
    JsonData progress_data;

    // Use this for initialization
    void Start()
    {

        //initializing damages
        progress_data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "\\playerprogress.json"));
        damage_by_bullet = int.Parse(progress_data["attack"][0]["attack"].ToString());
        wall_health = int.Parse(progress_data["defence"][0]["attack"].ToString());
        for (int i = 0; i < progress_data["powers"].Count; i++)
        {
            switch (progress_data["powers"][i]["name"].ToString())
            {
                case "creepychatter":
                    damage_by_chatter = int.Parse(progress_data["powers"][i]["attack"].ToString());
                    break;
                case "hitpan":
                    damage_by_pan = int.Parse(progress_data["powers"][i]["attack"].ToString());
                    break;
                case "monsterfriend":
                    damage_by_monsterfriend = int.Parse(progress_data["powers"][i]["attack"].ToString());
                    break;
            }
        }

        string json_text = File.ReadAllText(Application.persistentDataPath + "\\configuration.json");
        config_data = JsonMapper.ToObject(json_text);
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");
        wall_health_controller = GameObject.FindGameObjectWithTag("wallhealthcontroller");
        
      


        

        //initializing first wave
        //TextAsset json_string = Resources.Load<TextAsset>("level_"+level_no+"wave_0");
        //string myjson_string = json_string.text;
        //Monster[] monsters = JsonHelper.FromJson<Monster>(myjson_string);
        //for (int i = 0; i < monsters.Length; i++)
        //{
        //    GameObject temp_monster = (GameObject) Instantiate(monster_gameobjects[int.Parse(monsters[i].type)], monsters[i].set_pos(), monster_gameobjects[int.Parse(monsters[i].type)].transform.rotation);
        //    temp_monster.transform.parent = wave_parents[0].transform;
        //}
        //wave_parents[0].SetActive(false);

        //initializing second wave
        //json_string = Resources.Load<TextAsset>("level_" + level_no + "wave_1");
        //myjson_string = json_string.text;
        //monsters = JsonHelper.FromJson<Monster>(myjson_string);
        //for (int i = 0; i < monsters.Length; i++)
        //{
        //    GameObject temp_monster = (GameObject)Instantiate(monster_gameobjects[int.Parse(monsters[i].type)], monsters[i].set_pos(), monster_gameobjects[int.Parse(monsters[i].type)].transform.rotation);
        //    temp_monster.transform.parent = wave_parents[1].transform;
        //}
        //wave_parents[1].SetActive(false);

        //initializing third wave
        //json_string = Resources.Load<TextAsset>("level_" + level_no + "wave_2");
        //myjson_string = json_string.text;
        //monsters = JsonHelper.FromJson<Monster>(myjson_string);
        //for (int i = 0; i < monsters.Length; i++)
        //{
        //    GameObject temp_monster = (GameObject)Instantiate(monster_gameobjects[int.Parse(monsters[i].type)], monsters[i].set_pos(), monster_gameobjects[int.Parse(monsters[i].type)].transform.rotation);
        //    temp_monster.transform.parent = wave_parents[2].transform;
        //}
        //wave_parents[2].SetActive(false);

    }

    public void Update()
    {
       
    }

    

    

    
    

   

   

    public void display_GameoverPanel()
    {
        iTween.Pause(tank_player, true);
        Camera.main.gameObject.GetComponent<Grayscale>().enabled = true;
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = true;
        for (int i = 0; i < powers_selected.Length; i++)
        {
            displayed_powers[powers_selected[i] - 1].SetActive(false);
        }
        after_game_marble_count.text = marble_controller.GetComponent<MarbleScoreController>().getMarbleCount() + "";
        after_game_wall_health.text = wall_health_controller.GetComponent<WallHealthController>().getWallHealth() + "%";
        int coins = marble_controller.GetComponent<MarbleScoreController>().getMarbleCount() + wall_health_controller.GetComponent<WallHealthController>().getWallHealth();
        after_game_coins.text = coins + "";

        for (int i = 0; i < wave_parents.Length; i++)
        {
            wave_parents[i].SetActive(false);
        }
        after_game_panel.SetActive(true);
        tank_canshoot = false;
        pause_button.SetActive(false);
        
    }

    public bool getTankShootStatus()
    {
        return this.tank_canshoot;
    }


    public void onSelectmenupowerclicked(int power_status)
    {
        if (power_status != powers_selected[0] && power_status != powers_selected[1])
        {
            powers_selected[0] = powers_selected[1];
            powers_selected[1] = power_status;
            for (int i = 0; i < powers.Length; i++)
            {
                if (powers[i].GetComponent<MyPowerStatus>().getPower_status() == powers_selected[0] || powers[i].GetComponent<MyPowerStatus>().getPower_status() == powers_selected[1])
                {
                    powers[i].transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    powers[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }

        }

    }

    public int getBulletDamage()
    {
        return this.damage_by_bullet;
    }

    public int getDamageByChatter()
    {
        return this.damage_by_chatter;
    }

    public int getDamageByPan()
    {
        return this.damage_by_pan;
    }

    public void setGamePaused(bool new_game_paused)
    {
        this.gamepaused = new_game_paused;
    }

    public bool getGamePaused()
    {
        return this.gamepaused;
    }
    public void onPowersSelected()
    {
        
            Camera.main.GetComponent<Grayscale>().enabled = false;
            Camera.main.GetComponent<BlurOptimized>().enabled = false;
            pause_button.SetActive(true);
            displayPowers();
            power_select_panel.GetComponent<AnimateUpgradePanel>().playDownAnimation();
        infinitemontercontroller.SetActive(true);
        tank_canshoot = true;
        iTween.Resume(tank_player, true);
    }

   

    public void displayPowers()
    {
        for (int i = 0; i < powers_selected.Length; i++)
        {
            displayed_powers[powers_selected[i] - 1].SetActive(true);
            displayed_powers[powers_selected[i] - 1].GetComponent<RectTransform>().anchorMin = display_positions[i].anchorMin;
            displayed_powers[powers_selected[i] - 1].GetComponent<RectTransform>().anchorMax = display_positions[i].anchorMax;
            displayed_powers[powers_selected[i] - 1].GetComponent<RectTransform>().pivot = display_positions[i].pivot;
            displayed_powers[powers_selected[i] - 1].GetComponent<RectTransform>().anchoredPosition = display_positions[i].anchoredPosition;
            displayed_powers[powers_selected[i] - 1].tag = "selected_power";
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }


    [System.Serializable]
    public class Monster
    {
        public string type;
        public string position_x, position_y, position_z;
        Vector3 pos;

        public Vector3 set_pos()
        {
            pos = new Vector3(float.Parse(position_x), float.Parse(position_y), float.Parse(position_z));
            return pos;
        }

        public void print_info()
        {
            pos = new Vector3(float.Parse(position_x), float.Parse(position_y), float.Parse(position_z));
            print(type + " " + pos);
        }


    }


}
