using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AddUser : MonoBehaviour
{
    /// <summary>
    /// Класс AddUser
    /// для добавления новых пользователей
    /// </summary>
    
    public InputField FIO;
    public InputField login;
    public InputField password;
    public Dropdown userRole;

    public void AddUser()
    {
        InsertIntoDB database = new InsertIntoDB();
        database.InsertInto(login, password, FIO, userRole);
    }
}
