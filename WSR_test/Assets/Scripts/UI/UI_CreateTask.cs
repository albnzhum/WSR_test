using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UI_CreateTask : MonoBehaviour
{
    public InputField loginInput;
    public InputField passwordInput;

    public GameObject task;

    public void SaveTask()
    {
        if (task.transform.childCount > 0)
        {
            InsertIntoDB insertIntoDB = new InsertIntoDB();
            GameObjectData data = new GameObjectData(task);
            SavePrefab save = new SavePrefab();
            insertIntoDB.SaveTask(loginInput, passwordInput);
            save.Save(loginInput, passwordInput, data);

            
        }
        else
        {
            print("нечего сохранять");
        }
    }

    public void LoadTask()
    {

        foreach (Transform child in task.transform)
        {
            Vector3 childPosition = child.transform.position;
            Debug.Log($"Child position: {childPosition}");
        }

        SavePrefab save = new SavePrefab();
        GameObjectData data = new GameObjectData(task);
        string filename = save.FileName(loginInput,passwordInput);
        string path = Application.streamingAssetsPath + "/" + filename;
        print(path);
        string json = File.ReadAllText(path);
        save.Deserialize(json, task.transform);
    }
}
