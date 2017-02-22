using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletController : MonoBehaviour {

    public GameObject blast_prefab;
    public float bullet_speed = 5f;
    public float increment_factor = 10f;
    public int damage_to_crate = 1;
    Rigidbody rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f,0f,1f)*bullet_speed * increment_factor);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "crate")
        {
            Instantiate(blast_prefab, gameObject.transform.position , blast_prefab.transform.rotation);
            Destroy(gameObject);
            other.gameObject.transform.parent.gameObject.GetComponent<WallHealthController>().setWallHealth(other.gameObject.transform.parent.gameObject.GetComponent<WallHealthController>().getWallHealth() - damage_to_crate);
            iTween.ShakePosition(Camera.main.gameObject, new Vector3(0.1f, 0.1f, 0.1f), 0.2f);
        }
    }
}
