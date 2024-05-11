using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HydraScript : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float offScreenDist;
    public UnityEvent respawned;
    public UnityEvent died;
    public UnityEvent hit;
    Vector3 outPosition;
    Vector3 inPosition;
    float maxHealth = 10;
    public float MaxHealth { get { return maxHealth; } }
    public float health { get; private set; }

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

            died.Invoke();
            this.transform.position = outPosition;
            this.enabled = false;
            StartCoroutine(respawn());
        }
        else
        {
            hit.Invoke();
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(spawnTime);
        maxHealth += 5;
        health = maxHealth;
        respawned.Invoke();
        this.enabled = true;
        this.transform.position = inPosition;
    }


}
