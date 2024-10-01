using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BSpline : MonoBehaviour
{
    public List<Transform> points;
    public int vertexDivision;
    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.DrawIcon(points[i].position, "point "+ i.ToString());
        }
        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.color = new Color(0f, 0f, 1f, 0.5f);
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
            if(i < points.Count - 2)
            {
                Gizmos.color = new Color(0, 0.5f, 1f);

                Vector2 p1p2 = Vector2.Lerp(points[i].position, points[i + 1].position, 0.66f);
                Vector2 p2p3 = Vector2.Lerp(points[i + 1].position, points[i + 2].position, 0.33f);
                //Gizmos.DrawLine(p1p2, p2p3);
            }
        }
        for(int i = 0; i < points.Count - 3; i++)
        {
            Gizmos.color = new Color(1f, 1f, 1f);
            Vector2 p0 = points[i].position;
            Vector2 p1 = points[i+1].position;
            Vector2 p2 = points[i+2].position;
            Vector2 p3 = points[i+3].position;

            float interval = 1f / vertexDivision;
            float t = interval;
            Gizmos.DrawLine(P(0, i), P(t, i));
            while (t < 1)
            {
                Gizmos.DrawLine(P(t, i), P(t+interval, i));
                t += interval;
            }
        }
    }
    private Vector2 P(float t, int index)
    {
        Vector2 p0 = points[index].position;
        Vector2 p1 = points[index + 1].position;
        Vector2 p2 = points[index + 2].position;
        Vector2 p3 = points[index + 3].position;
        return (p0*(1 - 3*t + 3*t*t - t*t*t) + p1*(4 - 6*t*t + 3*t*t*t) + p2*(1 + 3*t + 3*t*t - 3*t*t*t) + p3*t*t*t) / 6f;
    }
    public Vector2 FullLerp(float m)
    {
        m = m * (points.Count - 3);
        int currenIndex = ((int)Mathf.Floor(m));
        float t = m - currenIndex;
        return P(t, currenIndex);
    }
}
