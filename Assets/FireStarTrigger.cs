using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireStarTrigger : MonoBehaviour
{
    public Transform fireStarSet;
    public bool done;
    public SplineFollowerGenerator sfg;
    public BSpline nextSpline;
    public bool setNextSpline;
    public Door doorToOpen;
    public AudioSource audioSource;

    public UnityEvent triggerFireStar;
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
            triggerFireStar.Invoke();
            if (setNextSpline)
            {
                sfg.UpdateSpline(nextSpline);
            }
            if(doorToOpen != null)
            {
                doorToOpen.UnlockDoor();
            }
            audioSource.Play();
        }
    }
}
