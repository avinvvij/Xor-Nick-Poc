using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsEventHandler : MonoBehaviour {

    public GameObject back_music_button, sound_effect_button, notification_button;
    GameObject sound_effect_handler;


    private void Start()
    {
        sound_effect_handler = GameObject.FindGameObjectWithTag("SoundEffectHandler");
        if (PlayerPrefs.GetInt("back_music", 1) == 1)
        {
            back_music_button.transform.GetChild(0).gameObject.SetActive(false);
        }else
        {
            back_music_button.transform.GetChild(0).gameObject.SetActive(true);
        }


        if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
        {
            sound_effect_button.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            sound_effect_button.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void onBackMusicClicked()
    {
        if(PlayerPrefs.GetInt("back_music",1) == 1)
        {
            back_music_button.transform.GetChild(0).gameObject.SetActive(true);
            PlayerPrefs.SetInt("back_music", 0);
        }
        else
        {
            back_music_button.transform.GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("back_music", 1);
        }
        sound_effect_handler.GetComponent<ManageMenuScreenSounds>().soundStatusChanged();
    }

    public void onSoundEffectClicked()
    {
        if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
        {
            sound_effect_button.transform.GetChild(0).gameObject.SetActive(true);
            PlayerPrefs.SetInt("sound_effect", 0);
        }
        else
        {
            sound_effect_button.transform.GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("sound_effect", 1);
        }
        sound_effect_handler.GetComponent<ManageMenuScreenSounds>().sound_effectStatusChanged();
    }

    public void onNotificationsClicked()
    {

    }


}
