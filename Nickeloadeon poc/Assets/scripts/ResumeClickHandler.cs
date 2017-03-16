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
        level_controller = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        level_controller.displayPowers();
        gameObject.transform.parent.gameObject.GetComponent<AnimateUpgradePanel>().playDownAnimation();
        Camera.main.gameObject.GetComponent<Grayscale>().enabled = false;
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = false;
        level_controller.setGamePaused(false);
        level_controller.tank_canshoot = true;
        monsters_on_screen = GameObject.FindGameObjectsWithTag("monster");
        for (int i = 0; i < monsters_on_screen.Length; i++)
        {
            monsters_on_screen[i].GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1f) * monsters_on_screen[i].GetComponent<MonsterMove>().getMonsterSpeed(), ForceMode.Impulse);
        }
        Time.timeScale = 1;
    }
}
