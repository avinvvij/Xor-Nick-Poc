using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class ManagePauseClick : MonoBehaviour {

    public GameObject game_paused_panel;
    GameObject level_controller;

	public void onPauseClicked()
    {
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
        gameObject.GetComponent<Button>().enabled = false;
        level_controller = GameObject.FindGameObjectWithTag("LevelController");
        level_controller.GetComponent<LevelController>().tank_canshoot = false;
        level_controller.GetComponent<LevelController>().setGamePaused(true);
        game_paused_panel.SetActive(true);
        game_paused_panel.GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
        Camera.main.gameObject.GetComponent<Grayscale>().enabled = true;
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = true;
        Invoke("HidePowers", game_paused_panel.GetComponent<AnimateUpgradePanel>().time_factor);
    }

    public void HidePowers()
    {
        GameObject[] selectedpowers = GameObject.FindGameObjectsWithTag("selected_power");
        for (int i = 0; i < selectedpowers.Length; i++)
        {
            selectedpowers[i].SetActive(false);
        }
    }
}
