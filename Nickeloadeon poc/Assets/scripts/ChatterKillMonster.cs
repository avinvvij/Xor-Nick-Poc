using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatterKillMonster : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster" )
        {
            Destroy(other.gameObject);
        }
    }
}
