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
    // Start is called before the first frame update
    void Start()
    {
        playerControl = new PlayerControl();
        playerControl.Movement.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = playerControl.Movement.Move.ReadValue<Vector2>();
        direction.Normalize();
        rb.AddForce(direction*speed);
    }
}
