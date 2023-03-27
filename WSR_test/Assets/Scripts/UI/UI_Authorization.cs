using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Authorization : MonoBehaviour
{
    /// <summary>
    /// ����� Authorization
    /// ��� ����������� �������������
    /// � �������� ��������� ������
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

        if (roleUser == "�������������")
        {
            Debug.Log("�������������");
            canvasTeacher.SetActive(true);
            canvasAuthorization.SetActive(false);
        }
        else if (roleUser == "�������")
        {
            Debug.Log("�������");

            canvasStudent.SetActive(true);
            canvasAuthorization.SetActive(false);
        }
        else if (roleUser == "�������������")
        {
            Debug.Log("�������������");

            canvasAdmin.SetActive(true);
            canvasAuthorization.SetActive(false);
        }

        database.SetTimeAuth(loginInput.text, passwordInput.text);

    }
}
