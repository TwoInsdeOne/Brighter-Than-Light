using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrack : MonoBehaviour
{
    public AudioSource track;
    
    public void PlayTrackNow()
    {
        track.Play();
    }
}
