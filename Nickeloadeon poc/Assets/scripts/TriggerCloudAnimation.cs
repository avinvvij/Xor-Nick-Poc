using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloudAnimation : MonoBehaviour {

    public Vector3 start_position;
    public int move_factor;

    private void Start()
    {
        GetComponent<AnimateClouds>().CloudSeperateAnimation(move_factor);
    }

}
