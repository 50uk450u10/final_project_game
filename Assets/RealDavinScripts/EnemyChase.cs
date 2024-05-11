using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public EnemyChase(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerController player, float moveSpeed, float attackSpeed, int wave, Enemy.EnemyType type, SpriteRenderer sprite) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed, wave, type, sprite)
    {
        this.attackSpeed = 0;
    }

    public override void FixedDo()
    {
        enemyRB.velocity = new Vector2((player.transform.position.x - enemy.transform.position.x), (player.transform.position.y - enemy.transform.position.y)).normalized * moveSpeed;
    }

    public override void Do()
    {
        if (!sprite.flipX && enemyRB.velocity.x < 0f)
        {
            sprite.flipX = enemyRB.velocity.x < 0f;
        }
        else if (sprite.flipX && enemyRB.velocity.x > 0f)
        {
            sprite.flipX = enemyRB.velocity.x < 0f;
        }
        switch (type)
        {
            case Enemy.EnemyType.DRAGON:
                if (Physics2D.OverlapCircle(enemy.transform.position, 0.5f, 1 << 6))
                {
                    enemy.enemyStateMachine.ChangeState(enemy.enemyAttack);
                }
                break;
            case Enemy.EnemyType.GORGON:
                if (Physics2D.OverlapCircle(enemy.transform.position, 3, 1 << 6))
                {
                    enemy.enemyStateMachine.ChangeState(enemy.enemyAttack);
                }
                break;
            case Enemy.EnemyType.DEMON:
                if (Physics2D.OverlapCircle(enemy.transform.position, 1, 1 << 6))
                {
                    enemy.enemyStateMachine.ChangeState(enemy.enemyAttack);
                }
                break;


        }
    }
    public override void Enter()
    {
        enemyAnimator.SetBool("hasAttacked", false);
        enemyAnimator.ResetTrigger("attacking");
        enemyAnimator.SetBool("chasing", true);
        switch (type)
        {
            case Enemy.EnemyType.DRAGON:
                this.moveSpeed = 3 * DifficultyManager.difficultyMultiplier;
                type = Enemy.EnemyType.DRAGON;
                break;
            case Enemy.EnemyType.GORGON:
                this.moveSpeed = 1 * DifficultyManager.difficultyMultiplier;
                type = Enemy.EnemyType.GORGON;
                break;
            case Enemy.EnemyType.DEMON:
                this.moveSpeed = 2 * DifficultyManager.difficultyMultiplier;
                type = Enemy.EnemyType.DEMON;
                break;
        }
    }
    public override void Exit()
    {
        enemyAnimator.SetBool("chasing", false);
        enemyRB.velocity = Vector2.zero;
    }
}


