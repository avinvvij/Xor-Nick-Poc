using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleAndroidNotifications;

    public class NotificationHandler : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
        NotificationManager.SendWithAppIcon(System.TimeSpan.FromSeconds(0),"Welcome to the game","test notification" , Color.red);
        }

     
    }

