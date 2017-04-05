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
    private JsonData progress_data;
    GameObject[] level_buttons;
    List<GameObject> button_names;
    public GameObject tank;
    public float move_factor = 1.2f;
    public Text coin_count;
    public GameObject attack_panel, defence_panel;
    public GameObject[] power_panels; 

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

        coin_count.text = configdata["coins_collected"].ToString();
        try
        {
            for (int i = 0; i < int.Parse(configdata["level_reached"].ToString()); i++)
            {
                button_names[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                button_names[i].transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                button_names[i].transform.GetChild(0).GetComponent<Button>().enabled = true;
                tank.transform.position = button_names[i].GetComponent<RectTransform>().position - new Vector3(move_factor, 0.0f, 0.0f);
            }
        }catch(Exception e)
        {

        }

        //playerprogess setup
        if (!File.Exists(Application.persistentDataPath + "\\playerprogress.json"))
        {
            string json_text_string = "{\"version\":\"1\",\"attack\":[{\"name\":\"mechimgun\",\"attack\":\"10\",\"next_update\":\"20\",\"update_cost\":\"500\"}],"+
	        "\"defence\":[{\"name\":\"cratewall\",\"attack\":\"100\",\"next_update\":\"150\",\"update_cost\":\"700\"}],\"powers\":[{\"name\":\"creepychatter\",\"attack\":\"20\",\"next_update\":\"30\",\"update_cost\":\"300\"},{"+
	        "\"name\":\"hitpan\",\"attack\":\"20\",\"next_update\":\"30\",\"update_cost\":\"500\"},{\"name\":\"monsterfriend\",\"attack\":\"10\",\"next_update\":\"15\",\"update_cost\":\"200\"}]}";
            File.WriteAllText(Application.persistentDataPath + "\\playerprogress.json", json_text_string);
        }

        progress_data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "\\playerprogress.json"));
        //initialize attack panel
        attack_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = progress_data["attack"][0]["update_cost"].ToString();
        attack_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).GetComponent<Slider>().value = int.Parse(progress_data["attack"][0]["attack"].ToString());
        //initialize defence panel
        defence_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = progress_data["defence"][0]["update_cost"].ToString();
        defence_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).GetComponent<Slider>().value = int.Parse(progress_data["defence"][0]["attack"].ToString());
        //initialize powers panel
        for(int i = 0; i < progress_data["powers"].Count; i++)
        {
            power_panels[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = progress_data["powers"][i]["update_cost"].ToString();
            power_panels[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).GetComponent<Slider>().value = int.Parse(progress_data["powers"][i]["attack"].ToString());
        }
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


    public void UiUpdate()
    {
        string jsonString = File.ReadAllText(Application.persistentDataPath + "\\configuration.json");
        configdata = JsonMapper.ToObject(jsonString);
        coin_count.text = configdata["coins_collected"].ToString();
        progress_data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "\\playerprogress.json"));
        //initialize attack panel
        attack_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = progress_data["attack"][0]["update_cost"].ToString();
        attack_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).GetComponent<Slider>().value = int.Parse(progress_data["attack"][0]["attack"].ToString());
        //initialize defence panel
        defence_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = progress_data["defence"][0]["update_cost"].ToString();
        defence_panel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).GetComponent<Slider>().value = int.Parse(progress_data["defence"][0]["attack"].ToString());
        //initialize powers panel
        for (int i = 0; i < progress_data["powers"].Count; i++)
        {
            power_panels[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = progress_data["powers"][i]["update_cost"].ToString();
            power_panels[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).GetComponent<Slider>().value = int.Parse(progress_data["powers"][i]["attack"].ToString());
        }
    }


}
