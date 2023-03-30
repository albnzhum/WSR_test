using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OutputData : MonoBehaviour
{
    /// <summary>
    /// Класс OutputData
    /// для вывода существующих пользователей
    /// </summary>

    public Transform contentFIO;
    public GameObject textFIO;
    public Transform contentRole;
    public GameObject textRole;

    public GameObject canvas1;
    private static int count = 0; //подсчет вызовов метода

    void OnEnable()
    {
        InsertIntoDB database = new InsertIntoDB();
        count++;
        if (count == 1)
        {
            database.FindUsers(contentFIO, textFIO, contentRole, textRole);
        }
        else if (count > 1)
        {
            GameObject[] arrayFIO = GameObject.FindGameObjectsWithTag("TextFIO");
            foreach (var fio in arrayFIO)
            {
                Destroy(fio);
            }
            GameObject[] arrayRole = GameObject.FindGameObjectsWithTag("TextRole");
            foreach (var role in arrayRole)
            {
                Destroy(role);
            }
            database.FindUsers(contentFIO, textFIO, contentRole, textRole);

        }
    }

}
