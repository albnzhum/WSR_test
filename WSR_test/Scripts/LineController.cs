using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private List<Transform> points = new List<Transform>();

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;

        //DragDrop.children = new List<Transform> ();
    }

    public void AddPoint(Transform point)
    {
        lr.positionCount++;
        points.Add(point);
    }

    private void LateUpdate()
    {
        if (points.Count >=2)
        {
            for (int i = 0; i < points.Count; i++)
            {
                lr.SetPosition(i, points[i].position);
                LineRendererData lineRendererData = new LineRendererData(lr);
                string json = JsonUtility.ToJson(lineRendererData);

            }
        }
    }
}
