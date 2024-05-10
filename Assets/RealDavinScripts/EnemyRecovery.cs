using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecovery : EnemyState
{
    Coroutine Recovering;
    public EnemyRecovery(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerController player, float moveSpeed, float attackSpeed, int wave, Enemy.EnemyType type, SpriteRenderer sprite) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed, wave, type,sprite)
    {
        this.moveSpeed = 0;
    }
    public override void Enter()
    {
        Recovering = enemy.StartCoroutine(Recovery());
    }
    public override void FixedDo()
    {
        if (enemyRB.velocity != Vector2.zero)
        {
            enemyRB.velocity = new Vector2(Mathf.Lerp(enemyRB.velocity.x, 0, 2), Mathf.Lerp(enemyRB.velocity.y, 0, 2));
        }
    }
    IEnumerator Recovery()
    {
        yield return new WaitForSeconds(1/DifficultyManager.difficultyMultiplier);
        enemyAnimator.SetBool("hasAttacked", false);
        enemy.enemyStateMachine.ChangeState(enemy.enemyChase);
    }
    public override void Exit()
    {
        enemy.StopCoroutine(Recovering);
    }
}
