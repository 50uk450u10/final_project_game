using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerExample player, float moveSpeed, float attackSpeed) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed)
    {
        this.moveSpeed = 0;
    }

    public override void FixedDo()
    {

    }

    public override void Do()
    {
        base.Do();
    }

    public override void Exit()
    {
        Debug.Log("Hello");
    }

    public override void Enter()
    {
        enemyRB.velocity = new Vector2((player.transform.position.x - enemy.transform.position.x), (player.transform.position.y - enemy.transform.position.y)).normalized * moveSpeed;
        enemy.StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1/attackSpeed);
        Vector3 target = player.transform.position;
        target.z = 0;
        Vector3 start = enemy.transform.position;
        target.x -= start.x;
        target.y -= start.y;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        enemy.attackHitbox.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        enemy.attackHitbox.transform.localPosition = new Vector3(-(enemy.transform.position.x - player.transform.position.x) * .5f, -(enemy.transform.position.y - player.transform.position.y) * 0.5f, 0);
        enemy.attackHitbox.SetActive(true);
        yield return new WaitForSeconds(1/attackSpeed);
        enemy.attackHitbox.SetActive(false);
        
    }
}
