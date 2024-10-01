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
    public void SwitchToTrack(AudioClip track)
    {
        animator.SetTrigger("switchtrack");
        nextTrack = track;
    }
    public void Switch()
    {
        audioSource.clip = nextTrack;
    }
}
