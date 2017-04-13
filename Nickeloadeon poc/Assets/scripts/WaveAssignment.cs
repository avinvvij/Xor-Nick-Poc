using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class WaveAssignment : MonoBehaviour {


    JsonData level_data;
    int wave_count = 0;
    GameObject way_pointManager;

    // Use this for initialization
    void Start () {
        
        
    }
	
	public void generate_waves(GameObject[] wave_parents , GameObject[] monster_gameobjects)
    {
        try
        {
            int level_no = PlayerPrefs.GetInt("level_no", 1);
            string level_data_string = Resources.Load<TextAsset>("level" + level_no).text;
            level_data = JsonMapper.ToObject(level_data_string);
            wave_count = int.Parse(level_data["waves_count"].ToString());
            for (int i = 1; i <= wave_count; i++)
            {
                int r_color = UnityEngine.Random.Range(0, 3);
                for (int j = 0; j < level_data["wave" + i].Count; j++)
                {
                    Vector3 monster_pos = new Vector3(float.Parse(level_data["wave" + i][j]["position_x"].ToString()), float.Parse(level_data["wave" + i][j]["position_y"].ToString()), float.Parse(level_data["wave" + i][j]["position_z"].ToString()));
                    GameObject temp_monster = (GameObject)Instantiate(monster_gameobjects[int.Parse(level_data["wave" + i][j]["type"].ToString())], monster_pos, monster_gameobjects[int.Parse(level_data["wave" + i][j]["type"].ToString())].transform.rotation);
                    switch (r_color)
                    {
                        case 0:

                            break;
                        case 1:
                            temp_monster.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.341176f, 0.0980392157f, 0.662745098f));
                            break;
                        case 2:
                            temp_monster.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.0235294118f, 0.678431373f, 0f));
                            break;
                    }
                    //check if there is a waypoint system for monster
                    try
                    {
                        if (level_data["wave" + i][j]["waypoint"].Count > 0)
                        {
                            way_pointManager = new GameObject("way_point_manager");
                            way_pointManager.AddComponent<PathEditor>();
                            Destroy(temp_monster.GetComponent<MonsterMove>());
                        }
                        GameObject temp_node;
                        for (int k = 0; k < level_data["wave" + i][j]["waypoint"].Count; k++)
                        {
                            temp_node = new GameObject("temp_node" + k);
                            temp_node.transform.parent = way_pointManager.transform;
                            temp_node.transform.localPosition = new Vector3(float.Parse(level_data["wave" + i][j]["waypoint"][k]["x"].ToString()), float.Parse(level_data["wave" + i][j]["waypoint"][k]["y"].ToString()), float.Parse(level_data["wave" + i][j]["waypoint"][k]["z"].ToString()));
                        }
                        temp_monster.AddComponent<FlyingMonsterPath>();
                        way_pointManager.GetComponent<PathEditor>().assign_node_positions();
                        temp_monster.GetComponent<FlyingMonsterPath>().setpathManager(way_pointManager);
                        temp_monster.GetComponent<FlyingMonsterPath>().speed = float.Parse(level_data["wave" + i][j]["waypoint_speed"].ToString());
                        temp_monster.GetComponent<FlyingMonsterPath>().reachDist = 0.5f;
                    }
                    catch (Exception e)
                    {

                    }

                    try
                    {
                        temp_monster.transform.localScale = new Vector3(float.Parse(level_data["wave" + i][j]["scale"]["x"].ToString()), float.Parse(level_data["wave" + i][j]["scale"]["y"].ToString()), float.Parse(level_data["wave" + i][j]["scale"]["z"].ToString()));
                    }
                    catch (Exception e)
                    {

                    }
                    try
                    {
                        temp_monster.GetComponent<MonsterHealthController>().setHealth(int.Parse(level_data["wave" + i][j]["health"].ToString()));
                    }
                    catch (Exception e)
                    {

                    }
                    temp_monster.transform.parent = wave_parents[i - 1].transform;
                }
                wave_parents[i - 1].SetActive(false);
            }
        }catch(System.Exception e)
        {

        }
    }

    public int getWaveCount()
    {
        return this.wave_count;
    }

}
