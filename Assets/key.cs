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
    public Animator gameEnd;
    public GameObject ressurectionWings;
    public Transform player;
    private bool activated;
    public float rwInterval;
    private float rwTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        delta = transform.position.y - key2.position.y;
        if(Mathf.Abs(delta) < 1)
        {
            rb2.AddForce(new Vector2(0, delta*50));
            ani.SetTrigger("activate");
            activated = true;
        }
        rwTimer -= Time.deltaTime;
        if (activated && rwTimer <= 0)
        {
            rwTimer = rwInterval;
            GameObject rw = Instantiate(ressurectionWings);
            rw.transform.parent = player;
            rw.transform.position = player.position;
        }
    }
    public void GameEnd()
    {
        gameEnd.SetTrigger("game end");
    }

}
