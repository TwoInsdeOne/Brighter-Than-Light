using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarTrigger : MonoBehaviour
{
    public Transform fireStarSet;
    public bool done;
    public SplineFollowerGenerator sfg;
    public BSpline nextSpline;
    public bool setNextSpline;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!done && collision.tag == "Player") {
            for (int i = 0; i < fireStarSet.childCount; i++) {
                fireStarSet.GetChild(i).GetComponent<FireStar>().Deactivate();
            }
            done = true;
            GetComponent<Animator>().SetTrigger("deactivate");
            if (setNextSpline)
            {
                sfg.UpdateSpline(nextSpline);
            }
        }
    }
}
