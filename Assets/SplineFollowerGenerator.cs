using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineFollowerGenerator : MonoBehaviour
{
    public GameObject splineFollower;
    public float interval;
    private float timer;
    public BSpline currentSpline;
    public BSpline previousSpline;
    //public GameObject reverseSplineFollower;
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GameObject sf = Instantiate(splineFollower);
            sf.GetComponent<FollowSpline>().spline = currentSpline;
            sf.transform.parent = transform;
            sf.transform.position = currentSpline.FullLerp(0);
            if (previousSpline != null)
            {
                GameObject rsf = Instantiate(splineFollower);
                rsf.GetComponent<FollowSpline>().spline = previousSpline;
                rsf.GetComponent<FollowSpline>().Reverse();
                rsf.transform.parent = transform;
                rsf.transform.position = previousSpline.FullLerp(1);
            }
            timer = interval;
            
        }
    }
    public void UpdateSpline(BSpline newSpline)
    {
        previousSpline = currentSpline;
        currentSpline = newSpline;
        
    }
}
