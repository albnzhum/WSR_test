using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public void Clicked()
    {
        // ��������� ������� ����� ������ ����

            // ������� ���, ������� ����� ������ ���������� ��������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���������, ���� �� ��������� � ����� �������
            /*if (Physics.Raycast(ray, out hit))
            {
                // ���������, �������� �� ��������� ������ ����� �� ���������� ��������
                if (Connectable.connectedObjects.Contains(hit.collider.gameObject))
                {
                    // ��������� ������� �� ��������� ������
                    Debug.Log("�� ������� ������: " + hit.collider.gameObject.name);
                }
            }*/
        }
    }

