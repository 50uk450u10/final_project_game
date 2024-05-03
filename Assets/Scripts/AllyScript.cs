using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform followArea;
    [SerializeField] PlayerController player;
    [SerializeField] Collider2D collider;
    Rigidbody2D rb;
    Vector2 direction;
    const float maxHealth = 5;
    float health;
    bool isDefended = false;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        transform.position = followArea.position;
    }

    private void Update()
    {
        isDefended = Input.GetKey(KeyCode.Q);
        if (isDefended){ collider.enabled = false; }
        else { collider.enabled = true; }
        transform.position = isDefended? player.transform.position:
            Vector3.Lerp(transform.position, followArea.position, speed);
    }

    public void damaged()
    {
        health -= 1;

        if (health == 0)
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
