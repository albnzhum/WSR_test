using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    /// <summary>
    /// Класс DragDrop
    /// для перетаскивания объектов
    /// и создания их дубликатов
    /// </summary>
    
    [SerializeField] Camera cam;

    public GameObject dublicate; //объект для дублирования
    public GameObject parent;
    private GameObject clone;


    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curPosition;

    //public static List<Transform> children = new List<Transform>();

    private Vector3 GetMouseWorldPosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - GetMouseWorldPosition();
        clone = Instantiate(dublicate, transform);
        DraggalbeObject draggable = clone.AddComponent<DraggalbeObject>();
        //Connectable connectable = clone.GetComponent<Connectable>();
        Connectable.connectedObjects.Add(clone.transform);
        //ClonedObjectList.objects.Add(clone.transform);
        
        
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        clone.transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        clone.transform.position = curPosition ;
        clone.transform.SetParent(parent.transform);
    }




}
