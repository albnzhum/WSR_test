using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggalbeObject : MonoBehaviour
{
    bool isDragging = false;
    public float dist = 4;
    //public Transform T;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curPosition;

    //public static List<Transform> children = new List<Transform>();

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
       transform.position = curPosition;
    }
}
