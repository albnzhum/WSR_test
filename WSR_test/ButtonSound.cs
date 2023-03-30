using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
   public AudioSource source;
    public AudioClip clip;

    public void ClickSound()
    {
        source.PlayOneShot(clip);
    }
}
