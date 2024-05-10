using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDied : EnemyState
{
    public EnemyDied(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerController1 player, float moveSpeed, float attackSpeed, int wave, Enemy.EnemyType type, SpriteRenderer sprite) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed, wave, type, sprite)
    {
        
    }

    public override void Enter()
    {
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        enemyAnimator.SetTrigger("died");
        enemy.deathCheck.Invoke();
    }
    public override void FixedDo()
    {
        //enemyRB.velocity = new Vector2(Mathf.Lerp(enemyRB.velocity.x, 0, 1f), Mathf.Lerp(enemyRB.velocity.y, 0, 1f));
        enemyRB.velocity = Vector2.zero;
    }
    public override void GotHit()
    {

    }
}
