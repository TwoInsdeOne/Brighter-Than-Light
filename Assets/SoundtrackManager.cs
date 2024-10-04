using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;
    private AudioClip nextTrack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        audioSource.Play();
    }
    public void SwitchToTrack(AudioClip track, bool loop)
    {
        animator.SetTrigger("switchtrack");
        nextTrack = track;
        audioSource.loop = loop;
    }
    public void Switch()
    {
        audioSource.clip = nextTrack;
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}
