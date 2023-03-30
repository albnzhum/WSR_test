using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public GameObject videoPlayer;
    private MyVideoPlayer videoPlayerScript;
    private void Start()
    {
        videoPlayerScript = videoPlayer.GetComponent<MyVideoPlayer>();
    }

    private void OnMouseDown()
    {
        videoPlayerScript.KnobOnPressDown();
    }

    private void OnMouseUp()
    {
        videoPlayerScript.KnobOnRelease();
    }
    private void OnMouseDrag()
    {
        videoPlayerScript.KnobOnDrag();
    }
}
