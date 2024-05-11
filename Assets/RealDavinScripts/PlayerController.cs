using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float activeMeleeTime;
    [SerializeField] float activeRangedTime;
    [SerializeField] Projectile arrow;
    [SerializeField] BoxCollider2D collide;
    [SerializeField] UnityEvent onDeath;
    [SerializeField] AllyScript ally;
    [SerializeField] AudioSource soundMaker;
    [SerializeField] AudioClip arrowSound;
    [SerializeField] AudioClip swordSound;
    Rigidbody2D rb;
    Animator animator;
    Vector2 direction;
    const float maxHealth = 5;
    public float MaxHealth { get { return maxHealth; } private set { MaxHealth = maxHealth; } }
    public float health { get; private set; }
    float hMove;
    float vMove;
    float rangedElapsedTime = 0;
    float meleeElapsedTime = 0;
    bool isAttacking = false;
    bool isShooting = false;

    public enum animationState { standard, attack, shoot }
    animationState anim = animationState.standard;
    public animationState Anim {  get { return anim; } }

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isShooting)
        {
            hMove = Input.GetAxis("Horizontal");
            vMove = Input.GetAxis("Vertical");
        }
        else//stop movement when shooting
        {
            hMove = 0;
            vMove = 0;
        }
        direction = new Vector2(hMove, vMove);
        direction.Normalize();//equalize diagonal movement speed
        rb.velocity = direction * speed;

        if(direction != Vector2.zero)
        {
            if(hMove > 0) { transform.localScale = Vector3.one; }
            else if(hMove < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        }

        if (!ally.isDefended) {//disallow movement when defending ally
            if (Input.GetKeyDown(KeyCode.R) && !isAttacking && !isShooting)
            {
                isShooting = true;
            }

            if (isShooting)
            {
                rangedElapsedTime += Time.deltaTime;
                if (rangedElapsedTime >= activeMeleeTime)
                {
                    animator.SetTrigger("Shoot");
                    rangedElapsedTime = 0;
                    isShooting = false;
                    Projectile arrow = Instantiate(this.arrow);
                    arrow.spawnProjectileSettings(Vector2.right);
                    arrow.transform.position = transform.position;
                    soundMaker.PlayOneShot(arrowSound);
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && !isShooting && !isAttacking)
            {
                isAttacking = true;
                collide.enabled = true;
                soundMaker.PlayOneShot(swordSound);
            }

            if (isAttacking)
            {
                meleeElapsedTime += Time.deltaTime;
                if (meleeElapsedTime >= activeMeleeTime)
                {
                    animator.SetTrigger("Attack");
                    meleeElapsedTime = 0;
                    isAttacking = false;
                    collide.enabled = false;
                }
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