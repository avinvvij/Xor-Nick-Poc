using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradUiButtonClick : MonoBehaviour {

    bool child_visible = false;
    int visiblecount = 0;
    public GameObject back_panel;


    public void onUpgradeUiClicked()
    {
        if (child_visible == false)
        {
            Camera.main.gameObject.GetComponent<TouchCameraMover>().setCanScroll(false);
            back_panel.SetActive(true);
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                if(gameObject.transform.GetChild(i).gameObject.activeSelf == true)
                    gameObject.transform.GetChild(i).gameObject.GetComponent<UiUpgradeAnimation>().animate_ui();
            }
            child_visible = true;
        }else if(child_visible == true)
        {
            Camera.main.gameObject.GetComponent<TouchCameraMover>().setCanScroll(true);
            back_panel.SetActive(false);
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<UiUpgradeAnimation>().hide_ui();
            }
            child_visible = false;
        }
    }
}
