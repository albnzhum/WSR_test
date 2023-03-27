using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using static Unity.VisualScripting.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static LoadJson;
using Unity.VisualScripting;
using System.Drawing;
using System.Linq;
using UnityEditor.UI;

public class SavePrefab : MonoBehaviour
{
    /// <summary>
    /// Класс SavePrefab 
    /// для сохранения данных объектов
    /// в JSON
    /// </summary>

    private int userId;
    private int taskId;

    public GameObject prefab;

    [HideInInspector] public List<Dictionary<string, float>> childTransformData;
    private string jsonData;
    

    // имя json-файла
    public string FileName(InputField loginInput, InputField passwordInput)
    {
        InsertIntoDB database = new InsertIntoDB();
        userId = database.GetUserID(loginInput.text, passwordInput.text);
        taskId = database.GetTaskID(userId);
        string fileName = $"task{taskId}_user{userId}.json";
        return fileName;
    }

    private string serializeObject(GameObjectData objData)
    {
        jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(objData);
        return jsonData;
    }


    // запись в json
    public void Save(InputField loginInput, InputField passwordInput, GameObjectData obj)
    {
        childTransformData = new List<Dictionary<string, float>>();
        //GameObjectData objData = new GameObjectData(obj);
        jsonData = serializeObject(obj);
        // Сериализуем список словарей в формат JSON

        string fileName = FileName(loginInput, passwordInput);
        File.WriteAllText(Application.streamingAssetsPath + "/" + fileName, jsonData);

        // Выводим результат в консоль
        Debug.Log(jsonData);
    }

    public void Deserialize(string json, Transform parent)
    {
        GameObjectData data = JsonConvert.DeserializeObject<GameObjectData>(json);
        Debug.Log($"Name: {data.Name}, Position: ({data.X}, {data.Y}, {data.Z})");
        foreach (GameObjectData childData in data.Children)
        {
            Debug.Log($"Child Name: {childData.Name}, Child Position: ({childData.X}, {childData.Y}, {childData.Z})");
        }

        if (data.Children != null)
        {
            foreach (GameObjectData childData in data.Children)
            {
                if (childData.Name.Contains("CircleSprite"))
                {
                    GameObject circle = CircleSprite();
                    circle.transform.SetParent(parent);
                    circle.transform.localScale = new Vector3(1, 1, 1);

                    circle.transform.position = new Vector3(childData.X, childData.Y, childData.Z);
                }
                else if (childData.Name.Contains("RectangleSprite"))
                {
                    GameObject rectangle = RectangleSprite();
                    rectangle.transform.SetParent(parent);
                    rectangle.transform.localScale = new Vector3(1, 1, 1);
                    rectangle.transform.position = new Vector3(childData.X, childData.Y, childData.Z);
                }
                else if (childData.Name.Contains("PolygonSprite"))
                {
                    GameObject polygon = PolygonSprite();
                    polygon.transform.SetParent(parent);
                    polygon.transform.localScale = new Vector3(1, 1, 1);

                    polygon.transform.position = new Vector3(childData.X, childData.Y, childData.Z);

                }

            }
        }
    }

    private string _path;

    private GameObject CircleSprite()
    {
       GameObject circle =  Resources.Load<GameObject>("CircleSprite");
        GameObject cloned = Instantiate(circle);
        //circle.transform.SetParent(prefab.transform);
        return cloned;
    }

    private GameObject RectangleSprite()
    {
        GameObject rectangle = Resources.Load<GameObject>("RectangleSprite");
        GameObject cloned = Instantiate(rectangle);
        //rectangle.transform.SetParent(prefab.transform);
        return cloned;

    }

    private GameObject PolygonSprite()
    {

        GameObject polygon = Resources.Load<GameObject>("PolygonSprite");
        GameObject cloned = Instantiate(polygon);

        //polygon.transform.SetParent(parent.transform);
        return cloned;

    }

}
public class GameObjectData
{
    public string Name;
    public float X;
    public float Y;
    public float Z;
    public List<GameObjectData> Children;

    public GameObjectData(GameObject obj)
    {
        if (obj != null)
        {


            Name = obj.name;
            X = obj.transform.position.x;
            Y = obj.transform.position.y;
            Z = obj.transform.position.z;

            Children = new List<GameObjectData>();
            foreach (Transform child in obj.transform)
            {
                Children.Add(new GameObjectData(child.gameObject));
            }
        }
    }
}
