using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMode : MonoBehaviour
{
    public bool active;

    public float duration;
    private float duration2;
    public ParticleSystem ps;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        //duration2 = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration2 > 0)
        {
            duration2 -= Time.deltaTime;
            if (duration2 <= 0)
            {
                TurnOff();
            }
        }
    }
    public void TurnOn()
    {
        active = true;
        duration2 = duration;
        gameObject.layer = 10;
        ani.SetBool("ghost", true);
    }
    public void TurnOff()
    {
        active = false;
        gameObject.layer = 9;
        ani.SetBool("ghost", false);
    }
}
