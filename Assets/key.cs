using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Transform key2;
    public float delta;
    public ParticleSystem ps;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta = transform.position.y - key2.position.y;
        if(Mathf.Abs(delta) < 1)
        {
            rb2.AddForce(new Vector2(0, delta*50));
            ani.SetTrigger("activate");
        }
    }
}
