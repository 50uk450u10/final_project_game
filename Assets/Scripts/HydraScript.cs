using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraScript : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float offScreenDist;
    Vector3 outPosition;
    Vector3 inPosition;
    int maxHealth = 10;
    int health;

    private void Start()
    {
        health = maxHealth;
        inPosition = transform.position;
        outPosition = new Vector3(offScreenDist, 0, 0) + inPosition;

    }

    public void OnHit()
    {
        health -= 1;
        if(health == 0)
        {
            this.transform.position = outPosition;
            this.enabled = false;
            StartCoroutine(respawn());
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(spawnTime);
        maxHealth += 5;
        health = maxHealth;
        this.enabled = true;
        this.transform.position = inPosition;
    }
}
