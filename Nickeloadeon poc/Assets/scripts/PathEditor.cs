using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour
{

    public Color rayColor = Color.white;
    public List<Transform> points = new List<Transform>();
    Transform[] tlist;
    Transform node1, node2;

    private void Start()
    {
        if (gameObject.name != "WayPointManager")
        {
            node1 = gameObject.transform.GetChild(1).transform;
            node2 = gameObject.transform.GetChild(2).transform;
            float randomx = Random.Range(-7.2f, 7.2f);
            node1.transform.position = new Vector3(randomx, node1.transform.position.y, node1.transform.position.z);
            randomx = Random.Range(-7.2f, 7.2f);
            node2.transform.position = new Vector3(randomx, node2.transform.position.y, node2.transform.position.z);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        tlist = GetComponentsInChildren<Transform>();
        points.Clear();

        foreach (Transform t in tlist)
        {
            if (t != this.transform)
            {
                points.Add(t);
            }
        }

        for (int i = 0; i < points.Count; i++)
        {
            Vector3 position = points[i].position;
            if (i > 0)
            {
                Vector3 prevposition = points[i - 1].position;
                Gizmos.DrawLine(prevposition, position);
            }
            Gizmos.DrawWireSphere(position, 0.5f);
        }
    }
}
