using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenTool : MonoBehaviour
{
    [Header("Lines")]
    [SerializeField] private GameObject linePrefab;
    [SerializeField] Transform lineParent;
    private LineController currentLine;

    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;

    [Header("Gameobjects")]
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;

    public LineRenderer lineRenderer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity).GetComponent<LineController>();

            }
            foreach (Transform point in ClonedObjectList.objects)
            {
                currentLine.AddPoint(point);
            }

        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }

}
