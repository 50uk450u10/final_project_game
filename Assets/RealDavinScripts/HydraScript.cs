using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraScript : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float offScreenDist;
<<<<<<< Updated upstream
=======
    public UnityEvent respawned;
    public UnityEvent died;
    public UnityEvent hit;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }

    public void OnHit()
    {
        health -= 1;
        if(health == 0)
        {
<<<<<<< Updated upstream
=======
            died.Invoke();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        respawned.Invoke();
>>>>>>> Stashed changes
        this.enabled = true;
        this.transform.position = inPosition;
    }
}
