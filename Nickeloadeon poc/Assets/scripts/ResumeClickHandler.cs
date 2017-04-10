using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class ResumeClickHandler : MonoBehaviour {

    LevelController level_controller;
    GameObject[] monsters_on_screen;
    public GameObject pause_button;

    public void onResume_Clicked()
    {
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
        pause_button.GetComponent<Button>().enabled = true;
        try
        {
            level_controller = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
            level_controller.displayPowers();
            level_controller.setGamePaused(false);
            level_controller.tank_canshoot = true;
        }catch(System.Exception e)
        {
            GameObject.FindGameObjectWithTag("LevelController").GetComponent<InfiniteLevelController>().displayPowers();
            GameObject.FindGameObjectWithTag("LevelController").GetComponent<InfiniteLevelController>().setGamePaused(false);
            GameObject.FindGameObjectWithTag("LevelController").GetComponent<InfiniteLevelController>().tank_canshoot = true;
        }
        gameObject.transform.parent.gameObject.GetComponent<AnimateUpgradePanel>().playDownAnimation();
        Camera.main.gameObject.GetComponent<Grayscale>().enabled = false;
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = false;
        
        Time.timeScale = 1;
    }
}
