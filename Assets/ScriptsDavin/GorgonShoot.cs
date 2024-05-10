using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorgonShoot : MonoBehaviour
{
    [SerializeField] GameObject projectileObject;
    Projectile projectile;

    public void Shoot(Vector2 playerPos, Enemy gorgon)
    {
        projectile = Instantiate(projectileObject.GetComponent<Projectile>());
        projectile.transform.position = gorgon.transform.position;
        projectile.spawnProjectileSettings(playerPos);
    }
}
