using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPoint : MonoBehaviour {

    Ray ray;
    public GameObject tankfollow;
    GameObject playergun;

	// Use this for initialization
	void Start () {
        playergun = GameObject.FindGameObjectWithTag("playergun");
	}
	
	// Update is called once per frame
	void Update () {
        
            Vector3 targetpos = new Vector3(tankfollow.transform.position.x , gameObject.transform.position.y , tankfollow.transform.position.z);
            transform.LookAt(targetpos);
            playergun.GetComponent<RotateGun>().setRotateyangle(transform.rotation.eulerAngles.y);
        
   }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
