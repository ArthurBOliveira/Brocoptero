using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float interval = 3.0f;
    public bool isEnemy = false;

    private float timestamp = .0f;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        timestamp = Time.time;  // save the timestamp when the bullet instantiated
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.CauseDamage(damage);

            Destroy(gameObject);
        }
        if (col.CompareTag("Enemy") && !isEnemy)
        {
            col.GetComponent<Enemy>().CauseDamage(damage);

            Destroy(gameObject);
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
        if (interval < Time.time - timestamp)
        {
            Destroy(gameObject);  // destroy the bullet after {interval} seconds
        }
    }
}
