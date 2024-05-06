using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerExample player;
    public Rigidbody2D enemyRB { get; private set; }
    public EnemyStateMachine enemyStateMachine { get; private set; }
    public EnemyChase enemyChase { get; private set; }
    public Animator enemyAnim { get; private set; }
    public EnemyState enemyState { get; private set; }
    public Enemy enemy { get; private set; }
    public EnemyChase ememyChase { get; private set; }
    public EnemyAttackState enemyAttack { get; private set; }
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    public GameObject attackHitbox;

    private void OnEnable()
    {
        player = FindAnyObjectByType<PlayerExample>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyStateMachine = new EnemyStateMachine();
        enemyAnim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        enemyChase = new EnemyChase(enemy, enemyStateMachine, enemyRB, enemyAnim, player, moveSpeed, attackSpeed);
        enemyAttack = new EnemyAttackState(enemy, enemyStateMachine, enemyRB, enemyAnim, player, moveSpeed, attackSpeed);
        enemyState = new EnemyState(enemy, enemyStateMachine, enemyRB, enemyAnim, player, moveSpeed, attackSpeed);
    }

    private void Start()
    {
        enemyStateMachine.Initialize(enemyChase);
    }
    // Update is called once per frame
    void Update()
    {
        enemyStateMachine.currentState.Do();
        enemyStateMachine.currentState.FixedDo();
    }
}
