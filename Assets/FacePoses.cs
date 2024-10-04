using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePoses : MonoBehaviour
{
    public float y;
    public float timer;
    private Vector3 initialPosition;
    private Vector3 initialScale;
    private Vector3 finalScale;
    private Vector3 finalPositionUp;
    private Vector3 finalPositionDown;
    private float lastY;

    private SpriteRenderer sr;
    private void Awake()
    {
        sr  = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(0, 0, 0);
        initialScale = new Vector3(1, 1, 1);
        finalScale = new Vector3(1, 0.9f, 1);
        finalPositionDown = new Vector3(0, -0.07f, 0);
        finalPositionUp = new Vector3(0, 0.07f, 0);
        lastY = 0;

    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        
        if(y > 0)
        {
            if (lastY == -1)
            {
                timer *= -1;
            }
            lastY = 1;
            timer += Time.fixedDeltaTime * 2f;
            if (timer > 1)
            {
                timer = 1;
            }
            transform.localPosition = Vector3.LerpUnclamped(initialPosition, finalPositionUp, timer);
            transform.localScale = Vector3.LerpUnclamped(initialScale, finalScale, timer);
        }else if(y < 0)
        {
            if(lastY == 1)
            {
                timer *= -1;
            }
            lastY = -1;
            timer += Time.fixedDeltaTime * 2f;
            if (timer > 1)
            {
                timer = 1;
            }
            transform.localPosition = Vector3.LerpUnclamped(initialPosition, finalPositionDown, timer);
            transform.localScale = Vector3.LerpUnclamped(initialScale, finalScale, timer);
        }else if(y == 0)
        {
            timer -= Time.fixedDeltaTime * 2f;
            if (timer < 0)
            {
                timer = 0;
            }
            if(lastY == 1)
            {
                transform.localPosition = Vector3.LerpUnclamped(initialPosition, finalPositionUp, timer);
            }
            if (lastY == -1)
            {
                transform.localPosition = Vector3.LerpUnclamped(initialPosition, finalPositionDown, timer);
            }
            transform.localScale = Vector3.LerpUnclamped(initialScale, finalScale, timer);
        }
    }*/
    void FixedUpdate()
    {

        if (y > 0)
        {
            /*if (lastY == -1)
            {
                timer *= -1;
            }
            lastY = 1;
            timer += Time.fixedDeltaTime * 2f;
            if (timer > 1)
            {
                timer = 1;
            }
            transform.localPosition = Vector3.LerpUnclamped(initialPosition, finalPositionUp, timer);
            transform.localScale = Vector3.LerpUnclamped(initialScale, finalScale, timer);*/
            if(transform.localPosition.y < 0.07f)
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y + Time.fixedDeltaTime, 0);
                if (transform.localPosition.y > 0.07f)
                {
                    transform.localPosition = new Vector3(0, 0.07f, 0);
                }
            }
            if(transform.localScale.y > 0.9)
            {
                transform.localScale = new Vector3(1, transform.localScale.y - Time.fixedDeltaTime, 0);
                if(transform.localScale.y < 0.9)
                {
                    transform.localScale = new Vector3(1, 0.9f, 1);
                }
            }
            


        } else if (y < 0)
        {
            if (transform.localPosition.y > -0.07f)
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y - Time.fixedDeltaTime, 0);
                if (transform.localPosition.y < -0.07f)
                {
                    transform.localPosition = new Vector3(0, -0.07f, 0);
                }
            }
            if (transform.localScale.y > 0.9)
            {
                transform.localScale = new Vector3(1, transform.localScale.y - Time.fixedDeltaTime, 0);
                if (transform.localScale.y < 0.9)
                {
                    transform.localScale = new Vector3(1, 0.9f, 1);
                }
            }
        } else if (y == 0)
        {
            if (transform.localPosition.y < 0)
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y + Time.fixedDeltaTime, 0);
                
            }
            if (transform.localPosition.y > 0)
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y - Time.fixedDeltaTime, 0);

            }
            if (Mathf.Abs(transform.localPosition.y - Time.fixedDeltaTime) < Time.fixedDeltaTime)
            {
                transform.localPosition = new Vector3(0, 0, 0);
            }
            if (transform.localScale.y < 1)
            {
                transform.localScale = new Vector3(1, transform.localScale.y + Time.fixedDeltaTime, 0);
                if (transform.localScale.y > 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
    public void DrawSprite(bool shouldDraw)
    {
        sr.enabled = shouldDraw;
    }
}
