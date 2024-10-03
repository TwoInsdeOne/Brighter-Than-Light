using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSoundVolume : MonoBehaviour
{
    public AudioSource track;
    public float volume;
    private void Awake()
    {
        track.volume = volume;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float newVolume)
    {
        track.volume = newVolume;
    }
}
