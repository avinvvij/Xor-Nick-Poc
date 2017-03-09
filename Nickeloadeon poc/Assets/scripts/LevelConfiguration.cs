using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class LevelConfiguration : MonoBehaviour {

    private JsonData configdata;
    GameObject[] level_buttons;
    List<GameObject> button_names;
    public GameObject tank;
    public float move_factor = 1.2f;
    public Text coin_count;

	// Use this for initialization
	void Start () {
        level_buttons = GameObject.FindGameObjectsWithTag("level_buttons");
        button_names = new List<GameObject>();
        for(int i = 0;i<level_buttons.Length; i++)
        {
            button_names.Add(level_buttons[i]);
        }

        button_names.Sort(SortByName);

        
        
        if(!File.Exists(Application.persistentDataPath + "\\configuration.json"))
        {
            string json_text_string = "{\"version\":\"1\" , \"level_reached\":\"1\" , \"coins_collected\":\"0\"}";
            File.WriteAllText(Application.persistentDataPath + "\\configuration.json", json_text_string);
        }
        string jsonString = File.ReadAllText(Application.persistentDataPath + "\\configuration.json");
        configdata = JsonMapper.ToObject(jsonString);
        int level_reached = int.Parse(configdata["level_reached"].ToString());
        try
        {
            int version = int.Parse(configdata["version"].ToString());
        }catch(Exception e)
        {
            string json_text_string = "{\"version\":\"1\" , \"level_reached\":\""+level_reached+"\" , \"coins_collected\":\"0\"}";
            File.WriteAllText(Application.persistentDataPath + "\\configuration.json", json_text_string);
        }
        for (int i = 0;i < int.Parse(configdata["level_reached"].ToString()) ; i++)
        {
            button_names[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            button_names[i].transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            button_names[i].transform.GetChild(0).GetComponent<Button>().enabled = true;
            tank.transform.position = button_names[i].GetComponent<RectTransform>().position - new Vector3(move_factor , 0.0f , 0.0f);
        }
        coin_count.text = configdata["coins_collected"].ToString();
    }
	
	
    private static int SortByName(GameObject g1 , GameObject g2)
    {
        int g1int = int.Parse(Regex.Match(g1.name, @"\d+").Value);
        int g2int = int.Parse(Regex.Match(g2.name, @"\d+").Value);
        if(g1int > g2int)
        {
            return 1;

        }else if (g1int < g2int)
        {
            return -1;

        }else
        {
            return 0;
        }
        
    }



}
