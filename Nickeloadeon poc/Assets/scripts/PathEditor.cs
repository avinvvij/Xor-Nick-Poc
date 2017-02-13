using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour
{

    public Color rayColor = Color.white;
    public List<Transform> points = new List<Transform>();
    Transform[] tlist;

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
