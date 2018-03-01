using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 1;
    public int score = 1;

    public float bulletSpeed = 100;
    public float speed = 10;

    public bool isDead = false;

    public GameObject bullet;
    public Transform shootPoint;

    private AudioSource audio;
    private Rigidbody2D rb2d;
    private Player player;
    private Animator anim;
    private GameController gc;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();        
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();

        StartCoroutine(Shoot());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !isDead && !player.isDying)
        {
            player.CauseDamage(1000);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        rb2d.velocity = Vector2.left * speed;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);

        if (!isDead)
        {
            audio.Play();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
        }

        yield return new WaitForSeconds(0.75f);
    }

    IEnumerator Die()
    {
        isDead = true;
        anim.SetTrigger("Dead");

        gc.AddScore(score);

        yield return new WaitForSeconds(0.75f);

        Destroy(gameObject);
    }

    public void CauseDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }
}
