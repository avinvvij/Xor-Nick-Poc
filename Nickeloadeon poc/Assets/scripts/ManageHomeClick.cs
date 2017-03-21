using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHomeClick : MonoBehaviour {

    public GameObject exit_panel;

	public void onHomeClicked()
    {
        exit_panel.SetActive(true);
    }

    public void onYesClicked()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void onNoClicked()
    {
        exit_panel.SetActive(false);
    }
}
