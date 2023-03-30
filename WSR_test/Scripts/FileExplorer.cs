using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FileExplorer : MonoBehaviour
{
    /// <summary>
    /// Класс FileExplorer
    /// для загрузки файлов из проводника
    /// </summary>
   
    string path;
    public RawImage image;

    public void OpenExplrore()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        GetImage();
    }

    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        WWW www = new WWW("file:///" + path);
        image.texture = www.texture;
    }
}
