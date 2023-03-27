using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public void Clicked()
    {
        // Проверяем нажатие левой кнопки мыши

            // Создаем луч, который будет искать коллайдеры объектов
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, есть ли коллайдер в точке нажатия
            /*if (Physics.Raycast(ray, out hit))
            {
                // Проверяем, является ли выбранный объект одним из выбираемых объектов
                if (Connectable.connectedObjects.Contains(hit.collider.gameObject))
                {
                    // Обработка нажатия на выбранный объект
                    Debug.Log("Вы выбрали объект: " + hit.collider.gameObject.name);
                }
            }*/
        }
    }

