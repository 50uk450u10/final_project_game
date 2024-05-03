using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject arrow;
    Rigidbody2D rb;
    Vector2 direction;
    const float maxHealth = 5;
    float health;
    float hMove;
    float vMove;

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

        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject arrow = Instantiate(this.arrow);
            arrow.transform.position = transform.position;
        }
    }

    public void damaged()
    {
        health -= 1;

        if(health == 0)
        {
            death();
        }
    }

    void death()
    {
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}