using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnUpgradeWallClicked : MonoBehaviour {
    public GameObject wall_upgrade_panel;

	public void onUpgradeWallClicked()
    {
        wall_upgrade_panel.SetActive(true);
        for (int i = 1; i < wall_upgrade_panel.transform.childCount; i++)
        {
            try
            {
                wall_upgrade_panel.transform.GetChild(i).GetComponent<AnimateUpgradePanel>().animateTheUpgradePanel();
            }catch(Exception e)
            {

            }
        }
    }
}
