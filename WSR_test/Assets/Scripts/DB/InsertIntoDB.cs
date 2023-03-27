using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using Newtonsoft.Json.Bson;
using UnityEngine.UI;
using Unity.VisualScripting.Dependencies.Sqlite;
using System;
using System.IO;
using System.Linq;
using UnityEditor.MemoryProfiler;
using UnityEditor.Search;
using Unity.VisualScripting;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using System.Threading;
using static UnityEditor.Progress;

public class InsertIntoDB: MonoBehaviour
{
    /// <summary>
    /// ����� InsertIntoDB
    /// ��� ������ � ����� ������
    /// </summary>

    private static string DataBaseName = "DataBase.db";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
    public InsertIntoDB() 
    {
        DBPath = GetDataBasePath();
    }

    /// �������� ���� ��
    private static string GetDataBasePath()
    {
        return Path.Combine(Application.streamingAssetsPath, DataBaseName);
        string filePath = Path.Combine(Application.dataPath, DataBaseName);
        if (!File.Exists(filePath)) UnpackDatabase(filePath);
        return filePath;
    }

    /// ������������� �� � ����� streamingassets
    private static void UnpackDatabase(string toPath)
    {
        string fromPath = Path.Combine(Application.streamingAssetsPath, DataBaseName);

        WWW reader = new WWW(fromPath);
        while (!reader.isDone) { }

        File.WriteAllBytes(toPath, reader.bytes);
    }

    /// ��������� ����������� � ��
    private static void OpenConnection()
    {
        connection = new SqliteConnection("Data Source=" + DBPath);
        command = new SqliteCommand(connection);
        connection.Open();
    }

    /// ��������� ����������� � ��
    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }

    /// ��������� ������ ��� �������� ������
    public static void ExecuteQueryWithoutAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        command.ExecuteNonQuery();
        CloseConnection();
    }

    /// ��������� ������ � ������������ �������
    public static string ExecuteQueryWithAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }

    /// ����� ���������� ����������� �������
    public static DataTable GetTable(string query)
    {
        OpenConnection();

        SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);

        DataSet DS = new DataSet();
        adapter.Fill(DS);
        adapter.Dispose();

        CloseConnection();

        return DS.Tables[0];
    }

    // ���������� ������ ������������
    public void InsertInto(InputField login, InputField password, InputField FIO, Dropdown dropdown)
    {
        var _FIOInput = FIO.text.Trim();
        var _LoginInput = login.text.Trim();
        var _PasswordInput = password.text.Trim();
        var _RoleItem = dropdown.options[dropdown.value].text;

        string SQLQuery = "Insert Into Authorization(Login, Password, FIO, Role, LastLogin)" +
                            "Values('" + _LoginInput + "', " +
                            "'" + _PasswordInput + "'," +
                            "'" + _FIOInput + "',  " +
                            "'" + _RoleItem + "', " +
                            "'"+ DateTime.Now.ToString()+"')";
        ExecuteQueryWithAnswer(SQLQuery);
    }

    // ����������� ������������
    public string Authorization(string loginInput, string passwordInput) 
    {
        DataTable users = GetTable("SELECT * FROM Authorization"); //���������� ������� ������� �� ��
        var role = (from row in users //��������� ���� �����
                    .AsEnumerable()

                     where row.Field<string>("Login") == loginInput
                     where row.Field<string>("Password") == passwordInput
                     select row.Field<string>("Role")).First<string>();
        return role;
    }

    public void SetTimeAuth(string loginInput, string passwordInput)
    {
        var id = GetUserID(loginInput, passwordInput); //���� �����
        string date = DateTime.Now.ToString(); //���� �����������
        string sql_query = $"UPDATE Authorization SET LastLogin = '{date}' WHERE Id = '{id}'"; //���������� ����
        string answer = ExecuteQueryWithAnswer(sql_query);
    }

    // ����� ���� �������������
    public void FindUsers(Transform contentFIO, GameObject FIOtext, Transform contentRole, GameObject RoleText) 
    {
        var textFIO = Resources.Load<Text>("textFIO");
        var textRole = Resources.Load<Text>("textRole");
        OpenConnection();
        DataTable findUser = GetTable("Select FIO, Role FROM Authorization");

        var _role = (from rows in findUser
                 .AsEnumerable()
                     select rows.Field<string>("Role")).ToList<string>();
        var _fio = (from rows in findUser
                      .AsEnumerable()
                    select rows.Field<string>("FIO")).ToList<string>();

        foreach (var one_fio in _fio)
        {
            FIOtext.GetComponent<Text>().text = one_fio.ToString();
            Text textOutput = Instantiate(textFIO, contentFIO);
        }
        foreach (var one_role in _role)
        {
            RoleText.GetComponent<Text>().text = one_role.ToString();
            Text textOutput = Instantiate(textRole, contentRole);
        }
        CloseConnection();
    }

    // ��������� ���� ������������
    public int GetUserID(string loginInput, string passwordInput)
    {
        string query = $"SELECT Id FROM Authorization WHERE Login = '{loginInput}' AND Password = '{passwordInput}'";
        var id = ExecuteQueryWithAnswer(query);
        return Convert.ToInt32(id);
    }


    // ��������� ���� �������
    public int GetTaskID(int IDTeacher)
    {
        string query = $"SELECT ID_Task FROM Tasks_Teacher WHERE ID_Teacher = '{IDTeacher}' ORDER BY ID_Task DESC LIMIT 1";
        var IDTask = ExecuteQueryWithAnswer(query);
        return Convert.ToInt32(IDTask);
    }

    // ���������� �������
    public void SaveTask(InputField login, InputField password)
    {
        var id = GetUserID(login.text, password.text);
        var role = Authorization(login.text, password.text);
        SavePrefab savePrefab = new SavePrefab();
        string fileName = savePrefab.FileName(login, password);

        if (role == "�������������")
        {
           string query = $"INSERT INTO Tasks_Teacher(ID_Teacher, JSON_Name) VALUES({id}, '{fileName}')";
           var answer = ExecuteQueryWithAnswer(query);
        }
        else
        {
            print("�� �� �������������");
        }
    }

}
