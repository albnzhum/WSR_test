using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Authorization : MonoBehaviour
{
    /// <summary>
    /// Класс Authorization
    /// для авторизации пользователей
    /// и проверки введенных данных
    /// </summary>

    public InputField loginInput;
    public InputField passwordInput;

    public GameObject canvasStudent;
    public GameObject canvasAdmin;
    public GameObject canvasTeacher;
    public GameObject canvasAuthorization;

    public void UserRole()
    {
        InsertIntoDB database = new InsertIntoDB();
        var roleUser = database.Authorization(loginInput.text, passwordInput.text);

        if (roleUser == "Преподаватель")
        {
            Debug.Log("преподаватель");
            canvasTeacher.SetActive(true);
            canvasAuthorization.SetActive(false);
        }
        else if (roleUser == "Студент")
        {
            Debug.Log("студент");

            canvasStudent.SetActive(true);
            canvasAuthorization.SetActive(false);
        }
        else if (roleUser == "Администратор")
        {
            Debug.Log("администратор");

            canvasAdmin.SetActive(true);
            canvasAuthorization.SetActive(false);
        }

        database.SetTimeAuth(loginInput.text, passwordInput.text);

    }
}
