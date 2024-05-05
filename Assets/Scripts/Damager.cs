using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable d = collision.GetComponent<Damagable>();
        if(d != null)
        {
            d.Hurt();
        }
    }
}
