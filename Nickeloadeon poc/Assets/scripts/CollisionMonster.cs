using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMonster : MonoBehaviour {

    bool triggered = false;
    Collider other;
    bool forceadded = false;
    int count = 0;

    private void Update()
    {
        if(triggered && !other && forceadded == false)
        {
            if (gameObject.GetComponent<MonsterMove>() != null)
                gameObject.GetComponent<MonsterMove>().enabled = true;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (gameObject.GetComponent<MonsterMove>() != null)
                rb.AddForce(new Vector3(0.0f, 0.0f, 1f) * gameObject.GetComponent<MonsterMove>().getMonsterSpeed(), ForceMode.Impulse);
            else
                rb.AddForce(new Vector3(0.0f, 0.0f, 1f) * -2f, ForceMode.Impulse);
            forceadded = true;
            triggered = false;
            count = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster" && triggered == false )
        {
            if (count >= 3)
            {
                if (gameObject.GetComponent<MonsterMove>() != null)
                    gameObject.GetComponent<MonsterMove>().enabled = false;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                triggered = true;
                forceadded = false;
                count = 0;
            }
            else
            {
                count++;
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                if (other.gameObject.transform.position.z < gameObject.transform.position.z)
                {
                    this.other = other;
                    if (gameObject.GetComponent<MonsterMove>() != null)
                        gameObject.GetComponent<MonsterMove>().enabled = false;
                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    triggered = true;
                    forceadded = false;

                    if (gameObject.transform.position.x > other.gameObject.transform.position.x)
                    {
                        rb.AddForce(new Vector3(1f, 0.0f, 0.0f) * 10f, ForceMode.Impulse);
                        //gameObject.transform.position = gameObject.transform.position + new Vector3(0.7f, 0.0f, 0.0f);
                    }
                    else
                    {
                        rb.AddForce(new Vector3(-1f, 0.0f, 0.0f) * 10f, ForceMode.Impulse);
                        //gameObject.transform.position = gameObject.transform.position - new Vector3(0.7f, 0.0f, 0.0f);
                    }
                }
                else
                {
                    if (gameObject.GetComponent<CollisionCrate>().getcollisiontocrate() == false)
                    {
                        if (gameObject.transform.position.x > other.gameObject.transform.position.x)
                        {
                            rb.AddForce(new Vector3(1f, 0.0f, 0.0f) * 10f, ForceMode.Impulse);
                            //gameObject.transform.position = gameObject.transform.position + new Vector3(0.7f, 0.0f, 0.0f);
                        }
                        else
                        {
                            rb.AddForce(new Vector3(-1f, 0.0f, 0.0f) * 10f, ForceMode.Impulse);
                            //gameObject.transform.position = gameObject.transform.position - new Vector3(0.7f, 0.0f, 0.0f);
                        }
                    }
                }
            }
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (forceadded == false)
        {
            if(gameObject.GetComponent<MonsterMove>() != null)
                gameObject.GetComponent<MonsterMove>().enabled = true;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (gameObject.GetComponent<MonsterMove>() != null)
                rb.AddForce(new Vector3(0.0f, 0.0f, 1f) * gameObject.GetComponent<MonsterMove>().getMonsterSpeed(), ForceMode.Impulse);
            else
                rb.AddForce(new Vector3(0.0f, 0.0f, 1f) * -2f, ForceMode.Impulse);

            forceadded = true;
            triggered = false;
        }
    }


}
