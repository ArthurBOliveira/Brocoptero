using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public float speed = 100f;
    public float jumpPower = 100f;

    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool isDead = false;
    public bool isDying = false;

    public AudioClip shootSound;
    public AudioClip explosionSound;

    public Slider healthBarSlider;
    public GameObject bullet;
    public Transform shootPoint;
    public AudioSource mainAudio;
    public AudioSource subAudio;

    private Rigidbody2D rb2d;
    private Animator anim;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }    

    void Start()
    {
        health = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Up();

    }

    IEnumerator Die()
    {
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(0, 0);

        mainAudio.Stop();
        subAudio.clip = explosionSound;
        subAudio.Play();

        anim.SetTrigger("Dead");

        isDying = true;

        yield return new WaitForSeconds(2f);

        isDead = true;
    }    

    public void Shoot()
    {
        if (!isDying)
        {
            bulletTimer += Time.deltaTime;

            if (bulletTimer >= shootInterval)
            {
                subAudio.clip = shootSound;
                subAudio.Play();

                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;

                bulletTimer = 0;
            }
        }
    }

    public void Up()
    {
        if (!isDying)
            rb2d.AddForce(Vector2.up * jumpPower);
    }

    public void CauseDamage(int damage)
    {
        health -= damage;
        healthBarSlider.value -= damage;

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }
}
