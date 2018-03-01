using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour
{
    public int heal = -1;
    public int speed = 5;

    private Player player;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.CauseDamage(heal);
        }
    }

    void Update()
    {
        rb2d.velocity = Vector2.left * speed;
    }

}
