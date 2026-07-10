using UnityEngine;
using UnityEngine.InputSystem;

public class TransposeController : MonoBehaviour
{
    public GameObject transposeBall;
    public PlayerMovement pm;
    public float throwSpeed;
    public bool throwing;
    public PlayerControl playerControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = new PlayerControl();
        playerControl.Act.Enable();
        playerControl.Act.Transpose.started += ThrowTranspose;
    }

    public void ThrowTranspose(InputAction.CallbackContext context)
    {
        GameObject tb = Instantiate(transposeBall);
        tb.GetComponent<TransposeBall>().player = gameObject;
        if(pm.direction.magnitude < 0.1f)
        {
            if(pm.lookSide > 0)
            {
                tb.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * throwSpeed, ForceMode2D.Impulse);
            }else if(pm.lookSide < 0)
            {
                tb.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * throwSpeed, ForceMode2D.Impulse);
            }
        } else
        {
            tb.GetComponent<Rigidbody2D>().AddForce(pm.direction * throwSpeed, ForceMode2D.Impulse);
        }
        throwing = true;
    }
    public void FinishTransposed()
    {
        throwing = false;
    }
}
