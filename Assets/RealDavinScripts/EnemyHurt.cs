using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : EnemyState
{
    float timer;
    public EnemyHurt(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerController player, float moveSpeed, float attackSpeed, int wave, Enemy.EnemyType type, SpriteRenderer sprite) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed, wave, type, sprite)
    {

    }
    public override void FixedDo()
    {
        timer += Time.deltaTime;
        enemyRB.velocity = new Vector2(Mathf.Lerp(enemyRB.velocity.x, 0, .5f), Mathf.Lerp(enemyRB.velocity.y, 0, .05f));
        if (enemyRB.velocity == Vector2.zero && timer > 1/DifficultyManager.difficultyMultiplier)
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyRecovery);
        }
    }
    public override void Enter()
    {
        timer = 0;
        enemyAnimator.SetBool("hurt",true);
        if (player.transform.position.x > enemy.transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (player.transform.position.x > enemy.transform.position.x)
        {
            sprite.flipX = false;
        }
    }
    public override void Exit()
    {
        enemyAnimator.SetBool("hurt", false);
    }
}
