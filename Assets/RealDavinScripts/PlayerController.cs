using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float activeMeleeTime;
    [SerializeField] Projectile arrow;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] UnityEvent onDeath;
    Rigidbody2D rb;
    Vector2 direction;
    const float maxHealth = 5;
    public float MaxHealth { get { return maxHealth; } private set { MaxHealth = maxHealth; } }
    public float health { get; private set; }
    float hMove;
    float vMove;
    float elapsedTime = 0;
    bool isAttacking = false;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        direction = new Vector2(hMove, vMove);
        direction.Normalize();//equalize diagonal movement speed
        rb.velocity = direction * speed;

        if(direction != Vector2.zero)
        {
            if(hMove > 0) { transform.localScale = Vector3.one; }
            else if(hMove < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Projectile arrow = Instantiate(this.arrow);
            arrow.spawnProjectileSettings(Vector2.right);
            arrow.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.E) && isAttacking == false)
        {
            isAttacking = true;
            collider.enabled = true;
        }

        if (isAttacking)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= activeMeleeTime)
            {
                elapsedTime = 0;
                isAttacking = false;
                collider.enabled = false;
            }
        }
    }

    public void damaged()
    {
        health -= 1;

        if(health == 0)
        {
            StartCoroutine(death());
        }
    }

    IEnumerator death()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        onDeath?.Invoke();
        Destroy(gameObject);
    }
}