using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStar : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform point1;
    public Transform point2;
    public Transform body;
    public float speed;
    public int turn;
    public int damage;
    public bool active;
    public bool deactive;
    public float massOnDeactivation;
    public float stuckTimer;
    public ParticleSystem trail;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
        deactive = false;
        stuckTimer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            if (turn == 1)
            {
                MoveToPoint(point1);
                if ((body.position - point1.position).sqrMagnitude < 1)
                {
                    turn = 2;
                    if (deactive)
                    {
                        OnDeactivate();
                    }
                }
            } else if (turn == 2)
            {
                MoveToPoint(point2);
                if ((body.position - point2.position).sqrMagnitude < 0.04f)
                {
                    turn = 1;
                    if (deactive)
                    {
                        OnDeactivate();
                    }
                }
            }
            TestStuck();
            if(stuckTimer > 1f)
            {
                if(turn == 1)
                {
                    turn = 2;
                } else if(turn == 2)
                {
                    turn = 1;
                }
                stuckTimer = 0;
            }
        }
        
    }
    public void MoveToPoint(Transform point)
    {
        Vector2 direction = (point.position  - body.position).normalized;
        rb.AddForce(direction * speed);
        rb.AddTorque(speed / 10f);
    }
    public void OnDeactivate()
    {
        active = false;
        gameObject.tag = "disabled enemy";
        body.tag = "disabled enemy";
        GetComponent<Animator>().SetTrigger("deactivate");
        rb.mass = massOnDeactivation;
        ParticleSystem.EmissionModule emission = trail.emission;
        emission.rateOverTime = 0;

    }
    public void Deactivate()
    {
        deactive = true;
    }
    void TestStuck()
    {
        if(rb.velocity.sqrMagnitude < 0.25f)
        {
            stuckTimer += Time.deltaTime;
        } else
        {
            stuckTimer = 0;
        }
    }
    
}
