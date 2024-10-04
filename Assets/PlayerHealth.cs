using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    private bool enabledHPbar;

    public Animator visualAnimator;
    public float damageTimer;
    public PlayerMovement playerMovement;
    public bool gameover;
    public ParticleSystem ghostTrail;
    public Animator gameoverScreen;
    public Animator shakeAni;

    public List<SpriteRenderer> scars;
    public List<ParticleSystem> blood;


    public GameObject bleeding;
    public ParticleSystem bleedingFX;

    public GameObject healingFX;

    public FacePoses facePoses;

    public AudioSource hitsound;
    private GameMaster gm;
    public Light2D light1;
    public Light2D light2;
    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.Find("GM").GetComponent<GameMaster>();
        //gm.endGameEvent.endGame.AddListener(DisableHPbarParticleSystem);
        enabledHPbar = true;
        bleedingFX = bleeding.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabledHPbar)
        {
            emission = 1200 * ((health * 1f) / maxHealth);
            hpLenght = 2 * ((health * 1f) / maxHealth);
            hpX = (hpLenght / 2f) - 1;
            ParticleSystem.EmissionModule m = hpbar.emission;
            m.rateOverTime = emission;
            ParticleSystem.ShapeModule s = hpbar.shape;
            s.position = new Vector3(hpX, 0, 0);
            s.scale = new Vector3(hpLenght, 0.33f, 1);
        }
        

        damageTimer -= Time.deltaTime;
        if(damageTimer < 0.9f)
        {
            playerMovement.free = true;
        }
        if(damageTimer < 0)
        {
            playerMovement.playerControl.Enable();
            ParticleSystem.EmissionModule bleedingEmission = bleedingFX.emission;
            bleedingEmission.rateOverTime = 0;
            facePoses.DrawSprite(true);
            damageTimer = 0;
        }

        for (int i = 0; i < scars.Count; i++)
        {
            scars[i].color = new Color(1, 1, 1, 1 - (health + 0f) / maxHealth);
        }
        for (int i = 0; i < blood.Count; i++)
        {
            ParticleSystem.EmissionModule bloodEmission = blood[i].emission;
            bloodEmission.rateOverTime = (5+ i) * (1 - (health + 0f) / maxHealth);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "enemy" && !shieldController.active && damageTimer <= 0 && !gameover)
        {
            damageTimer = 1;
            playerMovement.playerControl.Disable();
            playerMovement.free = false;
            Vector2 mPoint = transform.position + (collision.transform.position - transform.position).normalized *transform.localScale.x* 0.4f;
            GameObject fire = Instantiate(fire1VFX);
            fire.transform.position = mPoint;
            bleeding.transform.position = mPoint;
            bleeding.transform.parent = transform;
            ParticleSystem.EmissionModule bleedingEmission = bleedingFX.emission;
            bleedingEmission.rateOverTime = 50;
            if(collision.transform.position.x < transform.position.x)
            {
                DamageAnimation(-1);
            } else if(collision.transform.position.x >= transform.position.x)
            {
                DamageAnimation(1);
            }
            int damage = collision.transform.parent.GetComponent<FireStar>().damage;
            TakeDamate(damage);

            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * damage *kbSpeed );
            shakeAni.SetTrigger("shake");
            


        }

    }
    public void Heal(int amount)
    {
        int actualAmount = amount;
        if(health + amount > maxHealth)
        {
            actualAmount = maxHealth - health;
        }
        health = Mathf.Min(health + amount, maxHealth);
        GameObject hFX = Instantiate(healingFX);
        hFX.transform.position = transform.position;
        hFX.transform.parent = transform;
        ParticleSystem.EmissionModule hFXemission = hFX.GetComponent<ParticleSystem>().emission;
        hFXemission.rateOverTime = actualAmount * 5;
    }
    public void TakeDamate(int amount)
    {
        hitsound.pitch = Random.Range(0.7f, 1.2f);
        hitsound.Play();
        health -= amount;

        if(health <= 0)
        {
            health = 0;
            playerMovement.playerControl.Disable();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = 1;
            rb.mass = 100;
            visualAnimator.SetTrigger("death");
            gameoverScreen.SetBool("game over", true);
            ParticleSystem.EmissionModule emission = ghostTrail.emission;
            emission.rateOverTime = 0;
            gameover = true;
        }
    }
    public void DamageAnimation(int side)
    {
        visualAnimator.SetInteger("direction", 2 * side);
        facePoses.DrawSprite(false);
    }
    public void DisableHPbarParticleSystem()
    {
        enabledHPbar = false;
        ParticleSystem.EmissionModule m = hpbar.emission;
        m.rateOverTime = 0;
    }
    public void DisableLight()
    {
        light1.enabled = false;
        light2.enabled = false;
    }
}
