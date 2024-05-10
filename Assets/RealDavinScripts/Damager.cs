using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    Damagable d;
    Projectile p;
    Enemy e;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (d = collision.GetComponent<Damagable>())
        {
            d.Hurt();
            if (p = GetComponent<Projectile>())
            {
                if (e = collision.GetComponent<Enemy>())
                {
                    collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    collision.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 5;
                }
                Destroy(gameObject);
            }
        }
    }
}
