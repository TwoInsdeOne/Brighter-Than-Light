using UnityEngine;
using UnityEngine.InputSystem;

public class UseShieldController : MonoBehaviour
{
    public PlayerControl playerControl;
    private float lastUse;
    public float coldDown;
    public bool canUse;
    public Animator useShieldAni;
    public bool active;
    void Start()
    {
        playerControl = new PlayerControl();
        playerControl.Enable();
        playerControl.Shield.UseShield.started += UseShield;
    }
    void Update()
    {
        if(Time.time - lastUse > coldDown)
        {
            useShieldAni.ResetTrigger("useShield");
            canUse = true;
        } else
        {
            canUse = false;
        }
    }
    public void UseShield(InputAction.CallbackContext context)
    {
        if (canUse)
        {
            lastUse = Time.time;
            useShieldAni.SetTrigger("useShield");
            active = true;
        }
    }
    public void DeActivate()
    {
        active = false;
    }
}
