using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    public ParticleSystem portal;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = target.position;
            ParticleSystem.EmissionModule emi = portal.emission;
            emi.rateOverTime = 0;
        }
    }
}
