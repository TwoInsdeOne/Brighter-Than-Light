using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PolygonCollider2D pg;
    public Animator animator;
    public bool unlocked;
  
    public void UnlockDoor()
    {
        animator.SetInteger("state", 1);
        unlocked = true;
    }
    public void DisableCollider()
    {
        pg.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (unlocked)
            {
                animator.SetInteger("state", 2);
                DisableCollider();
            }
        }
    }
}
