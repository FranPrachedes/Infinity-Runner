using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FlyEnemy : Enemy
{

    private Rigidbody2D rig;
    private Player player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.OnHit(damage);
        }

        if (collision.CompareTag("Bullet"))
        {
            int dmg = collision.GetComponent<Projectile>().damage;
            collision.GetComponent<Projectile>().OnHit();
            ApplyDamage(dmg);
        }
    }
}
