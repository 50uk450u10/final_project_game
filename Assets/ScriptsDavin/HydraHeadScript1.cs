using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHeadScript1 : MonoBehaviour
{
    [SerializeField] Projectile fire;
    [SerializeField] PlayerController1 player;
    [SerializeField] float attackTime;
    float elapsedTime;
    bool isAttacking = false;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= attackTime)
        {
            elapsedTime = 0;
            Projectile p = Instantiate(fire);
            Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;
            Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);
            p.spawnProjectileSettings(playerDirection);
            fire.transform.position = transform.position;
        }
    }
}
