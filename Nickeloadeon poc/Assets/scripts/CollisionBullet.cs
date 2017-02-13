using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour {

    

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            //print("bullet collided with monster");
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
       
    }

    
}
