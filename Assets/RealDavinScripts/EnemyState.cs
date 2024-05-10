using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    protected Rigidbody2D enemyRB;
    protected Animator enemyAnimator;
    protected PlayerController1 player;
    protected float moveSpeed;
    protected float attackSpeed;
    protected int wave;
    protected Enemy.EnemyType type;
    protected SpriteRenderer sprite;

    public virtual void Enter() { }

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public virtual void Exit() { }

    public virtual void GotHit() { enemy.enemyStateMachine.ChangeState(enemy.enemyHurt); }

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerController1 player, float moveSpeed, float attackSpeed, int wave, Enemy.EnemyType type, SpriteRenderer sprite)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        this.enemyRB = enemyRB;
        this.enemyAnimator = enemyAnimator;
        this.player = player;
        this.moveSpeed = moveSpeed;
        this.attackSpeed = attackSpeed;
        this.wave = wave;
        this.type = type;
        this.sprite = sprite;
    }
}
