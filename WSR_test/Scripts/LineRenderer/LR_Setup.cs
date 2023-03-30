using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Setup: MonoBehaviour
{
    [SerializeField] private LineRender line;
    //[SerializeField] BoxCollider2D col;

    public void Objects()
    {
        line.SetUpLine(Connectable.connectedObjects);
    }
}
