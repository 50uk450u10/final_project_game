using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllyScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float defenseSpeed;
    [SerializeField] Transform followArea;
    [SerializeField] PlayerController player;
    [SerializeField] Collider2D collide;
    [SerializeField] UnityEvent onDeath;
    Rigidbody2D rb;
    Vector2 direction;
    const float maxHealth = 5;
    float health;
    public bool isDefended = false;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        transform.position = followArea.position;//set the ally to designated follow area at start
    }

    private void Update()
    {
        isDefended = Input.GetKey(KeyCode.Q);//set defense button to Q
        if (isDefended){ collide.enabled = false; }//disable collider so ally can't take damage
        else { collide.enabled = true; }//if Q is not pressed, reenable collider
        transform.position = isDefended? Vector3.Lerp(transform.position, player.transform.position, defenseSpeed) :
            Vector3.Lerp(transform.position, followArea.position, speed);//change lerp speed depending on isDefended bool
    }

    public void damaged()
    {
        health -= 1;

        if (health == 0)
        {
            StartCoroutine(death());
        }
    }

    IEnumerator death()//IEnumerator allows access to "WaitForSecondsRealtime" then ran with StartCoroutine
    {
        Time.timeScale = 0;//stop game time
        yield return new WaitForSecondsRealtime(3);//wait 3 actual seconds before continuing
        onDeath?.Invoke();
        Destroy(gameObject);
    }
}
