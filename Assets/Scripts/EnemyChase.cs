using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public EnemyChase(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerExample player, float moveSpeed, float attackSpeed) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed)
    {
        this.attackSpeed = 0;
    }

    public override void FixedDo()
    {
        enemyRB.velocity = new Vector2((player.transform.position.x - enemy.transform.position.x), (player.transform.position.y - enemy.transform.position.y)).normalized * moveSpeed;
    }

    public override void Do()
    {
        //Vector3 target = player.transform.position;
        //target.z = 0;
        //Vector3 start = enemy.transform.position;
        //target.x -= start.x;
        //target.y -= start.y;
        //float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90;
        //enemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (Physics2D.OverlapCircle(enemy.transform.position, 1, 1 << 3))
        {
            enemy.enemyStateMachine.ChangeState(enemy.enemyAttack);
        }
    }
}
