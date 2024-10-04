using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCullController : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - cameraTransform.position).magnitude > 20)
        {
            audioSource.gameObject.SetActive(false);
        } else
        {
            audioSource.gameObject.SetActive(true);
        }
    }
}
