using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastHandler : MonoBehaviour {

    private AndroidJavaObject toastExample = null;
    private AndroidJavaObject activityContext = null;

    void Start()
    {

        if (toastExample == null)
        {

            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            }


            using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.vij_a.unittoastplugin.ToastPlugin"))
            {
                if (pluginClass != null)
                {
                    toastExample = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    toastExample.Call("setContext", activityContext);
                    activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        toastExample.Call("showNotification");
                    }));
                    activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        toastExample.Call("startService");
                    }));

                }
            }
        }

    }


    public void showToast(string message)
    {
        toastExample = null;
        activityContext = null;
        if(toastExample == null) {

            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            }


            using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.vij_a.unittoastplugin.ToastPlugin"))
            {
                if (pluginClass != null)
                {
                    toastExample = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    toastExample.Call("setContext", activityContext);
                    activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        toastExample.Call("showMessage", message);
                    }));
                    activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        toastExample.Call("showNotification");
                    }));
                }
            }
        }
    }

}
