using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Rigidbody2D rb;
    public float kbSpeed;
    public GameObject fire1VFX;
    public ShieldController shieldController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "enemy" && !shieldController.active)
        {
            Vector2 mPoint = transform.position + (collision.transform.position - transform.position).normalized *transform.localScale.x* 0.4f;
            GameObject fire = Instantiate(fire1VFX);
            fire.transform.position = mPoint;

            int damage = collision.transform.parent.GetComponent<FireStar>().damage;
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * damage *kbSpeed );
            TakeDamate(damage);
            
        }

    }
    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
    }
    public void TakeDamate(int amount)
    {
        health -= amount;
    }
}
