using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityStandardAssets.ImageEffects;

public class LevelController : MonoBehaviour {

    private int level_no = 1;
    private int wave_no = 0;
    public Text level_text;
    public GameObject tank_player;
    public bool tank_canshoot = false;
    Hashtable level_ht , wave_ht;
    bool canshowlevel = false;
    public GameObject victory_particle;
    public GameObject[] wave_rend;
    GameObject current_wave_object;
    bool can_render_next = false;
    public GameObject[] monster_gameobjects;
    public GameObject[] wave_parents;
    public GameObject after_game_panel;
    public Text after_game_text;
    public Text after_game_marble_count , after_game_wall_health , after_game_coins;
    GameObject marble_controller, wall_health_controller;
    bool game_over = false;
    JsonData config_data;
    public GameObject power_select_panel;
    public GameObject[] powers , displayed_powers;
    int[] powers_selected = { 1, 2 };
    public RectTransform[] display_positions;
    private bool gamepaused = false;
    public GameObject pause_button;

   // AudioSource back_audio;
    //public AudioSource victory_sound , crowd_boo_sound;
    public GameObject mechimvsbosspanel;


    //declaring variable for bullet , powers damage
    int damage_by_bullet, damage_by_chatter, damage_by_pan, damage_by_monsterfriend;
    int wall_health;
    JsonData progress_data;
    public GameObject infinite_monster_controller, background_plane;
    public Texture plane_infinite_texture , arena2_texture;

    AudioSource back_audio;
    public AudioSource victory_sound, crowd_boo_sound;

    // Use this for initialization
    void Start () {

        //setting the background

        if(PlayerPrefs.GetInt("level_no" , 1) == 1000)
        {
            background_plane.GetComponent<Renderer>().material.mainTexture= plane_infinite_texture;
            background_plane.GetComponent<Renderer>().material.mainTextureScale = new Vector2(2.5f, 2.5f);
        }else if(PlayerPrefs.GetInt("level_no",1)>=5 && PlayerPrefs.GetInt("level_no", 1) <= 8)
        {
            background_plane.GetComponent<Renderer>().material.mainTexture = arena2_texture;
            background_plane.GetComponent<Renderer>().material.mainTextureScale = new Vector2(2.5f, 2.5f);
        }

        //initializing damages
        progress_data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "\\playerprogress.json"));
        damage_by_bullet = int.Parse(progress_data["attack"][0]["attack"].ToString());
        wall_health = int.Parse(progress_data["defence"][0]["attack"].ToString());
        for(int i = 0; i < progress_data["powers"].Count; i++)
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
        level_no = PlayerPrefs.GetInt("level_no",1);
        marble_controller = GameObject.FindGameObjectWithTag("marblecontroller");
        wall_health_controller = GameObject.FindGameObjectWithTag("wallhealthcontroller");

        level_ht = new Hashtable();
        level_ht.Add("x", 50f);
        level_ht.Add("y", 50f);
        level_ht.Add("z", 50f);
        level_ht.Add("time", 1f);
        level_ht.Add("oncomplete", "onLevelAnimationComplete");
        level_ht.Add("oncompletetarget", gameObject);
        level_ht.Add("easetype", iTween.EaseType.easeInCirc);

        //initializing sound
        back_audio = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("back_music", 1) == 0)
        {
            back_audio.Stop();
        }


        gameObject.GetComponent<WaveAssignment>().generate_waves(wave_parents , monster_gameobjects);

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
        if(current_wave_object!= null && current_wave_object.transform.childCount == 0 && can_render_next == true)
        {
            can_render_next = false;
            Invoke("render_next_wave", 1f);
        }

        
    }

    public void setLevel_No(int new_level_no)
    {
        this.level_no = new_level_no;

    }

    public int getLevel_No()
    {
        return this.level_no;
    }


    public void onLevelAnimationComplete()
    {
        level_text.text = "";
        Invoke("startWaveAnimation", 0.8f);
    }

    public void startWaveAnimation()
    {
        
            wave_rend[0].SetActive(true);
            tank_canshoot = true;
            can_render_next = true;
        
    }

    public void onWaveAnimationComplete()
    {
        if (wave_no <= gameObject.GetComponent<WaveAssignment>().getWaveCount() -1)
        {
            wave_parents[wave_no].SetActive(true);
            current_wave_object = wave_parents[wave_no];
            wave_rend[wave_no].SetActive(false);
            wave_no++;
            can_render_next = true;
        }else
        {
            after_game_text.text = "Victory";
            display_GameoverPanel();
            
            wave_rend[wave_no].SetActive(false);
            tank_canshoot = false;
        }
    }

    public void render_next_wave()
    {
        wave_rend[wave_no].SetActive(true);
        if(wave_no == gameObject.GetComponent<WaveAssignment>().getWaveCount())
        {
            for(int i = 0;i < 5; i++)
            {
                wave_rend[i].SetActive(false);
            }
            wave_rend[5].SetActive(true);
            Instantiate(victory_particle, victory_particle.transform.position, victory_particle.transform.rotation);
            //unlock the next level
            int temp_level_no = int.Parse(config_data["level_reached"].ToString());
            if (int.Parse(config_data["level_reached"].ToString()) <= level_no)
            {
                temp_level_no = level_no + 1;
            }
            int coins_collected_previously = int.Parse(config_data["coins_collected"].ToString());
            //update amount of coins
            int new_amount_coins = coins_collected_previously + marble_controller.GetComponent<MarbleScoreController>().getMarbleCount() + wall_health_controller.GetComponent<WallHealthController>().getWallHealth();
            config_data["level_reached"] = "" + temp_level_no + "";
            config_data["coins_collected"] = "" + new_amount_coins + "";
            config_data = JsonMapper.ToJson(config_data);
            File.WriteAllText(Application.persistentDataPath + "\\configuration.json", config_data.ToString());

        }
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

        for (int i=0;i<wave_parents.Length; i++)
        {
            wave_parents[i].SetActive(false);
        }
        after_game_panel.SetActive(true);
        tank_canshoot = false;
        pause_button.SetActive(false);
        if (after_game_text.text == "Victory")
        {
            if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
            {
                victory_sound.Play();
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
            {
                crowd_boo_sound.Play();
            }
        }
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
        power_select_panel.GetComponent<AnimateUpgradePanel>().playDownAnimation();
        if (PlayerPrefs.GetInt("level_no",1) == 1000) {
            infinite_monster_controller.SetActive(true);
            tank_canshoot = true;
            Camera.main.GetComponent<Grayscale>().enabled = false;
            Camera.main.GetComponent<BlurOptimized>().enabled = false;
            pause_button.SetActive(true);
            displayPowers();
            iTween.Resume(tank_player , true);
        }
        else if (PlayerPrefs.GetInt("level_no", 1) % 4 == 0)
        {
            mechimvsbosspanel.SetActive(true);
            Invoke("bosspanelover", 1.5f);
        }
        else
        {
            Camera.main.GetComponent<Grayscale>().enabled = false;
            Camera.main.GetComponent<BlurOptimized>().enabled = false;
            pause_button.SetActive(true);
            displayPowers();
            level_text.text = "LEVEL " + level_no;
            iTween.ShakePosition(level_text.gameObject, level_ht);
            iTween.Resume(tank_player, true);
        }
    }

    public void bosspanelover()
    {
        mechimvsbosspanel.GetComponent<AnimateUpgradePanel>().playDownAnimation();
        Camera.main.GetComponent<Grayscale>().enabled = false;
        Camera.main.GetComponent<BlurOptimized>().enabled = false;
        pause_button.SetActive(true);
        displayPowers();
        level_text.text = "LEVEL " + level_no;
        power_select_panel.GetComponent<AnimateUpgradePanel>().playDownAnimation();
        iTween.ShakePosition(level_text.gameObject, level_ht);
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
