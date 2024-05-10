using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllyScript1 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform followArea;
    [SerializeField] PlayerController1 player;
    [SerializeField] Collider2D collider;
    [SerializeField] UnityEvent onDeath;
    Rigidbody2D rb;
    Vector2 direction;
    const float maxHealth = 5;
    public float MaxHealth { get { return maxHealth; } }
    public float health { get; private set; }
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
