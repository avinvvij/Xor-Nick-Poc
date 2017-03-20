using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMenuScreenSounds : MonoBehaviour {

    public AudioSource water_flowing, background_music;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("back_music" , 1) == 1)
        {
            background_music.Play();
        }else
        {
            background_music.Pause();
        }

        if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
        {
            water_flowing.Play();
        }
        else
        {
            water_flowing.Pause();
        }
    }

    public void soundStatusChanged()
    {
        if (PlayerPrefs.GetInt("back_music", 1) == 1)
        {
            background_music.Play();
        }
        else
        {
            background_music.Pause();
        }
    }

    public void sound_effectStatusChanged()
    {
        if (PlayerPrefs.GetInt("sound_effect", 1) == 1)
        {
            water_flowing.Play();
        }
        else
        {
            water_flowing.Pause();
        }
    }
}
