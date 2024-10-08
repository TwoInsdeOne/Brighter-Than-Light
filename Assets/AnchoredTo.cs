using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchoredTo : MonoBehaviour
{
    public Transform transformToAnchor;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = transformToAnchor.position + offset;
    }
}
