using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerControl playerControl;
    public Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    public Animator visualAnimator;
    public bool free;
    public FacePoses facePoses;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = new PlayerControl();
        playerControl.Movement.Enable();
        free = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (free)
        {
            direction = playerControl.Movement.Move.ReadValue<Vector2>();
            facePoses.y = direction.y;
            direction.Normalize();
            rb.AddForce(direction * speed);
            if (direction.x > 0)
            {
                visualAnimator.SetInteger("direction", 1);
            } else if (direction.x < 0)
            {
                visualAnimator.SetInteger("direction", -1);
            } else if (direction.x == 0)
            {
                visualAnimator.SetInteger("direction", 0);
            }
        }
        
    }
    
}
