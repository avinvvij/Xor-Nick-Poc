﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    private int level_no = 1;
    private int wave_no = 0;
    public Text level_text;
    public bool tank_canshoot = false;
    Hashtable level_ht , wave_ht;
    bool canshowlevel = false;
    public GameObject victory_particle;
    public GameObject[] wave_rend;
    GameObject current_wave_object;
    bool can_render_next = false;
    public GameObject[] monster_gameobjects;
    public GameObject[] wave_parents;

	// Use this for initialization
	void Start () {
        level_text.text = "LEVEL " + level_no;
        level_ht = new Hashtable();
        level_ht.Add("x", 50f);
        level_ht.Add("y", 50f);
        level_ht.Add("z", 50f);
        level_ht.Add("time", 1f);
        level_ht.Add("oncomplete", "onLevelAnimationComplete");
        level_ht.Add("oncompletetarget", gameObject);
        level_ht.Add("easetype", iTween.EaseType.easeInCirc);
        iTween.ShakePosition(level_text.gameObject, level_ht);


        //initializing first wave
        TextAsset json_string = Resources.Load<TextAsset>("level_"+level_no+"wave_0");
        string myjson_string = json_string.text;
        Monster[] monsters = JsonHelper.FromJson<Monster>(myjson_string);
        for (int i = 0; i < monsters.Length; i++)
        {
            GameObject temp_monster = (GameObject) Instantiate(monster_gameobjects[int.Parse(monsters[i].type)], monsters[i].set_pos(), monster_gameobjects[int.Parse(monsters[i].type)].transform.rotation);
            temp_monster.transform.parent = wave_parents[0].transform;
        }
        wave_parents[0].SetActive(false);

        //initializing second wave
        json_string = Resources.Load<TextAsset>("level_" + level_no + "wave_1");
        myjson_string = json_string.text;
        monsters = JsonHelper.FromJson<Monster>(myjson_string);
        for (int i = 0; i < monsters.Length; i++)
        {
            GameObject temp_monster = (GameObject)Instantiate(monster_gameobjects[int.Parse(monsters[i].type)], monsters[i].set_pos(), monster_gameobjects[int.Parse(monsters[i].type)].transform.rotation);
            temp_monster.transform.parent = wave_parents[1].transform;
        }
        wave_parents[1].SetActive(false);

        //initializing third wave
        json_string = Resources.Load<TextAsset>("level_" + level_no + "wave_2");
        myjson_string = json_string.text;
        monsters = JsonHelper.FromJson<Monster>(myjson_string);
        for (int i = 0; i < monsters.Length; i++)
        {
            GameObject temp_monster = (GameObject)Instantiate(monster_gameobjects[int.Parse(monsters[i].type)], monsters[i].set_pos(), monster_gameobjects[int.Parse(monsters[i].type)].transform.rotation);
            temp_monster.transform.parent = wave_parents[2].transform;
        }
        wave_parents[2].SetActive(false);

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
        if (wave_no <= 2)
        {
            wave_parents[wave_no].SetActive(true);
            current_wave_object = wave_parents[wave_no];
            wave_rend[wave_no].SetActive(false);
            wave_no++;
            can_render_next = true;
        }
    }

    public void render_next_wave()
    {
        wave_rend[wave_no].SetActive(true);
        if(wave_no == 3)
        {
            Instantiate(victory_particle, victory_particle.transform.position, victory_particle.transform.rotation);
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