using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpline : MonoBehaviour
{
    public Animator ani;
    public BSpline spline;
    public float m;
    public float duration;
    public bool reverse;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reverse)
        {
            m -= Time.fixedDeltaTime * (1 / duration);
            if (m > 0)
            {
                transform.position = new Vector3(spline.FullLerp(m).x, spline.FullLerp(m).y, 0);
                if (m < (1 / duration))
                {
                    ani.SetTrigger("selfdestroy");
                    Destroy(gameObject, 1f);
                }
            }

        } else
        {
            m += Time.fixedDeltaTime * (1 / duration);
            if (m < 1)
            {
                transform.position = new Vector3(spline.FullLerp(m).x, spline.FullLerp(m).y, 0);
                if (m >= 1 - (1 / duration))
                {
                    ani.SetTrigger("selfdestroy");
                    Destroy(gameObject, 1f);
                }
            }
        }
        
        

    }
    public void Reverse()
    {
        reverse = true;
        m = 1;
    }
}
