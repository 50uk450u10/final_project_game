using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]//make rigidbody a requirement to possess this script
public class Projectile : MonoBehaviour
{
    [SerializeField] int projectileSpeed;
    [SerializeField] Rigidbody2D rb;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);//destroy instance outside of gameview
    }

    public void spawnProjectileSettings(Vector2 dir)
    {
        rb.AddForce(dir * projectileSpeed, ForceMode2D.Impulse);//launch projectile

    }
}
