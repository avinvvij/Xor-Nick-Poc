using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHomeClick : MonoBehaviour {

	public void onHomeClicked()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
