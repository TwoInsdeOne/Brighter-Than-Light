using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineFollowerGenerator : MonoBehaviour
{
    public GameObject splineFollower;
    public float interval;
    private float timer;
    public BSpline currentSpline;
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
            timer = interval;
        }
    }
}