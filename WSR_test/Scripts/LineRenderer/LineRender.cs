using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    /// <summary>
    /// Класс LineRender
    /// для соединения блок-схем
    /// </summary>

    private LineRenderer lr;
    private List<Transform> lines;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(List<Transform> lines)
    {
        lr.positionCount = lines.Count;
        this.lines = lines;
        Aaa();
    }

    private void Aaa()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            lr.SetPosition(i, new Vector3(lines[i].position.x, lines[i].position.y, 0));
        }

    }
}
