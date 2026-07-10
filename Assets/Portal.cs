using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Portal : MonoBehaviour
{
    public Transform target;
    public ParticleSystem portal;
    public UnityEvent enterPortal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = target.position;
            ParticleSystem.EmissionModule emi = portal.emission;
            emi.rateOverTime = 0;
            enterPortal.Invoke();
        }
    }
}
