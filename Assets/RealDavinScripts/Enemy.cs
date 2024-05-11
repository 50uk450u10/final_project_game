using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    PlayerController player;
    public Rigidbody2D enemyRB { get; protected set; }
    public EnemyStateMachine enemyStateMachine { get; protected set; }
    public EnemyChase enemyChase { get; protected set; }
    public Animator enemyAnim { get; protected set; }
    public EnemyState enemyState { get; protected set; }
    public Enemy enemy { get; protected set; }
    public EnemyChase ememyChase { get; protected set; }
    public EnemyRecovery enemyRecovery { get; protected set; }
    public EnemyAttackState enemyAttack { get; protected set; }
    public EnemyHurt enemyHurt { get; protected set; }
    public EnemyDied enemyDied { get; protected set; }
    [SerializeField] protected float baseMoveSpeed;
    [SerializeField] protected float attackSpeed;
    EnemyType type;
    public GameObject attackHitbox { get; protected set; }
    public SpriteRenderer sprite { get; protected set; }
    int health;
    public UnityEvent deathCheck;
    Coroutine Death;
    protected virtual void OnEnable()
    {
        player = FindAnyObjectByType<PlayerController>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyStateMachine = new EnemyStateMachine();
        enemyAnim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        attackHitbox = GetComponentInChildren<Damager>().gameObject;
        sprite = GetComponent<SpriteRenderer>();
        attackSpeed += WaveCounter.waveCount / 10;
        switch (gameObject.tag)
        {
            case "Dragon":
                type = EnemyType.DRAGON;
                health = 1;
                break;
            case "Demon":
                type = EnemyType.DEMON;
                health = 5;
                break;
            case "Gorgon":
                type = EnemyType.GORGON;
                health = 3;
                break;
        }
        enemyChase = new EnemyChase(enemy, enemyStateMachine, enemyRB, enemyAnim, player, baseMoveSpeed, attackSpeed, WaveCounter.waveCount, type, sprite);
        enemyAttack = new EnemyAttackState(enemy, enemyStateMachine, enemyRB, enemyAnim, player, baseMoveSpeed, attackSpeed, WaveCounter.waveCount, type, sprite);
        enemyRecovery = new EnemyRecovery(enemy, enemyStateMachine, enemyRB, enemyAnim, player, baseMoveSpeed, attackSpeed, WaveCounter.waveCount, type, sprite);
        enemyHurt = new EnemyHurt(enemy, enemyStateMachine, enemyRB, enemyAnim, player, baseMoveSpeed, attackSpeed, WaveCounter.waveCount, type, sprite);
        enemyDied = new EnemyDied(enemy, enemyStateMachine, enemyRB, enemyAnim, player, baseMoveSpeed, attackSpeed, WaveCounter.waveCount, type, sprite);
        enemyState = new EnemyState(enemy, enemyStateMachine, enemyRB, enemyAnim, player, baseMoveSpeed, attackSpeed, WaveCounter.waveCount, type, sprite);
    }

    protected virtual void Start()
    {
        attackHitbox.SetActive(false);
        enemyStateMachine.Initialize(enemyChase);
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        enemyStateMachine.currentState.Do();
        enemyStateMachine.currentState.FixedDo();
    }
    public enum EnemyType
    {
        DRAGON = 1,
        GORGON = 2,
        DEMON = 3
    }
    public void OnDamaged()
    {
        health -= 1;
        if (health <= 0)
        {
            Death = StartCoroutine(Dying());
        }
        else
        {
            enemyStateMachine.currentState.GotHit();
        }
    }
    IEnumerator Dying()
    {
        enemyStateMachine.ChangeState(enemyDied);
        yield return new WaitForSeconds(0.5f);
        Destroy(enemy.gameObject);
    }
}
