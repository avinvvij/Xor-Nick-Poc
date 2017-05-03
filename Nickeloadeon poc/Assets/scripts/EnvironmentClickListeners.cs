using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnvironmentClickListeners : MonoBehaviour {
    Ray ray;
    public GameObject monster_details;
    public Text monster_name, monster_health, monster_description , monster_aps;
    public Image monster_image;
    public Sprite oldy_texture, stoney_texture , yeti_texture , devil_pic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    if(hit.collider.tag == "menumonster" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        monster_details.SetActive(true);
                        monster_details.transform.GetChild(1).GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
                        Camera.main.GetComponent<TouchCameraMover>().setCanScroll(false);
                        update_monster_details(hit.collider.gameObject.name);
                    }
                    if(hit.collider.gameObject.name == "way_to_arcade" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        PlayerPrefs.SetInt("level_no", 1000);
                        AsyncOperation async = SceneManager.LoadSceneAsync(1);
                        
                        async.allowSceneActivation = (false);
                        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
                        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
                    }
                }
            }
        }else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "menumonster" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        monster_details.SetActive(true);
                        monster_details.transform.GetChild(1).GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
                        Camera.main.GetComponent<TouchCameraMover>().setCanScroll(false);
                        update_monster_details(hit.collider.gameObject.name);
                    }
                    if (hit.collider.gameObject.name == "way_to_arcade" && Camera.main.gameObject.GetComponent<TouchCameraMover>().getCanScroll() == true)
                    {
                        PlayerPrefs.SetInt("level_no", 1000);
                        AsyncOperation async = SceneManager.LoadSceneAsync(1);
                        async.allowSceneActivation = (false);
                        Camera.main.gameObject.transform.GetChild(0).GetComponent<AnimateClouds>().AnimateTheClouds(async);
                        Camera.main.gameObject.transform.GetChild(1).GetComponent<AnimateClouds>().CloudJoinSimpleAnimation();
                    }
                }
            }
        }
	}

    public void update_monster_details(string monster_name_new)
    {
        
        switch (monster_name_new)
        {
            case "stoney":
                monster_name.text = "STONEY";
                monster_health.text = "Health : 200";
                monster_description.text = "A stone aged monster, highly durable to the bullets because of his stoned body. BEWARE!!!";
                monster_aps.text = "attack per second : 10";
                monster_image.sprite = stoney_texture;
                break;
            case "oldy_monster":
                monster_name.text = "ABOMAN";
                monster_health.text = "Health : 400";
                monster_description.text = "The ABOMAN orignates from the time of early humans. Throws pointed spear towards your wall. Always carries that angry look on his face, maybe because of the burning volcano!!";
                monster_aps.text = "attack per spear : 2";
                monster_image.sprite = oldy_texture;
                monster_image.gameObject.transform.localScale = new Vector3(1f, 0.37f, 1.00001f);
                break;
            case "yeti_parent":
                monster_name.text = "ICE YETI";
                monster_health.text = "Health : 2000";
                monster_description.text = "The big oval shaped yeti is too powerful. Has big hands to shoot those big snow balls at your wall. ";
                monster_aps.text = "attack per second : 5";
                monster_image.sprite = yeti_texture;
                monster_image.gameObject.transform.localScale = new Vector3(1f, 0.37f, 1.00001f);
                break;
            case "devil_parent":
                monster_name.text = "DEVIL";
                monster_health.text = "Health : 2200";
                monster_description.text = "The Devil directly comes from beneath the hell.";
                monster_aps.text = "attack per second : 10";
                monster_image.sprite = devil_pic;
                monster_image.gameObject.transform.localScale = new Vector3(1f, 0.37f, 1.00001f);
                break;
        }
    }
}
