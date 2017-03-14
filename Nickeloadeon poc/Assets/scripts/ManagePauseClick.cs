using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePauseClick : MonoBehaviour {

    public GameObject game_paused_panel;
    GameObject level_controller;

	public void onPauseClicked()
    {
        level_controller = GameObject.FindGameObjectWithTag("LevelController");
        level_controller.GetComponent<LevelController>().tank_canshoot = false;
        level_controller.GetComponent<LevelController>().setGamePaused(true);
        game_paused_panel.SetActive(true);
    }
}
