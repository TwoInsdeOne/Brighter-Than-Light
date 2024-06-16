using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject shield;
    public bool active;
    public float duration;
    private float duration2;
    public Animator ani;
    private void Start()
    {
        //duration2 = duration;
        duration2 = 0.1f;
        active = false;
    }
    private void Update()
    {
        if(duration2 > 0)
        {
            duration2 -= Time.deltaTime;
            if(duration2 <= 0)
            {
                TurnOff();
            }
        }
    }
    public void TurnOn()
    {
        if (!active)
        {
            duration2 = duration;
            shield.GetComponent<CircleCollider2D>().enabled = true;
            //shield.SetActive(true);
            active = true;
            ani.SetBool("off", false);
            ani.SetBool("on", true);
        }
        
    }
    public void TurnOff()
    {
        //shield.SetActive(false);
        shield.GetComponent<CircleCollider2D>().enabled = false;
        active = false;
        ani.SetBool("on", false);
        ani.SetBool("off", true);
    }
}
