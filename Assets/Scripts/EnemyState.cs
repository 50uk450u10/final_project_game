using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    protected Rigidbody2D enemyRB;
    protected Animator enemyAnimator;
    protected PlayerExample player;
    protected float moveSpeed;
    protected float attackSpeed;

    public virtual void Enter() { }

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public virtual void Exit() { }

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerExample player, float moveSpeed, float attackSpeed)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        this.enemyRB = enemyRB;
        this.enemyAnimator = enemyAnimator;
        this.player = player;
        this.moveSpeed = moveSpeed;
        this.attackSpeed = attackSpeed;
    }
}
