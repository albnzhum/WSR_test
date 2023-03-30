using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LINERENDER1 : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 mousepos;
    private int currlines = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
            {
                createLine();
            }
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;
            line.SetPosition(0, mousepos);
            line.SetPosition(1, mousepos);

        }

        else if (Input.GetMouseButtonUp(0) && line)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;
            line.SetPosition(1, mousepos);
            line = null;
            currlines++;

        }

        else if (Input.GetMouseButton(0) && line)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;
            line.SetPosition(1, mousepos);

        }
    }

        void createLine()
        {
            line = new GameObject("Line" + currlines).AddComponent<LineRenderer>();
            line.positionCount = 2;
            line.startWidth = 0.15f;
            line.endWidth = 0.15f;
            line.useWorldSpace = false;
            line.numCapVertices = 50;
        }
    }

