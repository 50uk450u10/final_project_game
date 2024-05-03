using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] int projectileSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * projectileSpeed, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
