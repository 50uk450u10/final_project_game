using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HydraScript : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float offScreenDist;
    [SerializeField] UnityEvent onDefeat;
    [SerializeField] UnityEvent onRespawn;
    Vector3 outPosition;
    Vector3 inPosition;
    int maxHealth = 10;
    int health;

    private void Start()
    {
        health = maxHealth;
        inPosition = transform.position;//set inPosition to current position on screen
        outPosition = new Vector3(offScreenDist, 0, 0) + inPosition;//set outPosition to offscreen

    }

    public void OnHit()
    {
        health -= 1;
        if(health == 0)
        {
            this.transform.position = outPosition;//when defeated move entity offscreen
            this.enabled = false;//disable the entity
            onDefeat?.Invoke();
            StartCoroutine(respawn());
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(spawnTime);
        maxHealth += 5;
        health = maxHealth;
        this.enabled = true;//reenable entity on respawn
        this.transform.position = inPosition;//move entity back in camera
        onRespawn?.Invoke();
    }
}
