using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rb2d;
    private Player player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        rb2d.velocity = Vector2.left * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !player.isDying)
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
}
