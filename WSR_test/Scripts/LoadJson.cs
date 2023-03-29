using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;

public class LoadJson : MonoBehaviour
{
    private string _path;
    private JsonFile _file = new JsonFile();
    public class JsonFile
    {
        public string name;
        public float x;
        public float y;
        public float z;
    }

    public void load(InputField loginInput, InputField passwordInput)
    {
        InsertIntoDB database = new InsertIntoDB();
        int id = database.GetUserID(loginInput.text, passwordInput.text);
        int taskId = database.GetTaskID(id);
        string fileName = $"task{taskId}_user{id}.json";

        _path = Application.streamingAssetsPath + "/" + fileName;
        _file = JsonUtility.FromJson<JsonFile>(File.ReadAllText(_path));
        foreach (char name in _file.name)
        {
            Debug.Log(name.ToString());
        }
        

    }
}
