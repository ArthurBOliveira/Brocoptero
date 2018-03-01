using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public int score = 1;
    public int speed = 5;

    private Player player;
    private GameController gc;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            gc.AddScore(score);
        }
    }

    void Update()
    {
        rb2d.velocity = Vector2.left * speed;
    }

}
