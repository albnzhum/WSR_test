using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoPanel : MonoBehaviour
{
    public VideoPlayer videoplayer;
    public VideoPlayer bigPlayer;

    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
        videoplayer.Pause();
    }
    public void OnButtonClick()
    {
        bigPlayer.clip = videoplayer.clip;
    }
}
