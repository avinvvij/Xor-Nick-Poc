using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWall : MonoBehaviour {

    

    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "boundarywall")
        {
            Destroy(gameObject);
        }
    }
}
