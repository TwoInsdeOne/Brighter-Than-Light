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

    public ParticleSystem hpbar;
    public float emission;
    public float hpLenght;
    public float hpX;

    public Animator visualAnimator;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        emission = 1200 * ((health*1f) / maxHealth);
        hpLenght = 2 * ((health*1f) / maxHealth);
        hpX = (hpLenght / 2f) - 1;
        ParticleSystem.EmissionModule m = hpbar.emission;
        m.rateOverTime = emission;
        ParticleSystem.ShapeModule s = hpbar.shape;
        s.position = new Vector3(hpX, 0, 0);
        s.scale = new Vector3(hpLenght, 0.33f, 1);

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "enemy" && !shieldController.active && timer <= 0)
        {
            timer = 1;
            Vector2 mPoint = transform.position + (collision.transform.position - transform.position).normalized *transform.localScale.x* 0.4f;
            GameObject fire = Instantiate(fire1VFX);
            fire.transform.position = mPoint;
            if(collision.transform.position.x < transform.position.x)
            {
                DamageAnimation(-1);
            } else if(collision.transform.position.x >= transform.position.x)
            {
                DamageAnimation(1);
            }
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
        if(health < 0)
        {
            health = 0;
        }
    }
    public void DamageAnimation(int side)
    {
        visualAnimator.SetInteger("direction", 2 * side);
    }
}
