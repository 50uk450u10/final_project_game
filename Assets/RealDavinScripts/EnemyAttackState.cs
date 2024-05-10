using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    bool isGorgon = false;
    GorgonShoot shoot;
    Coroutine Attacking;
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine, Rigidbody2D enemyRB, Animator enemyAnimator, PlayerController1 player, float moveSpeed, float attackSpeed, int wave, Enemy.EnemyType type, SpriteRenderer sprite) : base(enemy, enemyStateMachine, enemyRB, enemyAnimator, player, moveSpeed, attackSpeed, wave, type, sprite)
    {
        this.moveSpeed = 0;
        enemyAnimator.SetFloat("attackSpeed", DifficultyManager.difficultyMultiplier);
        switch (type)
        {
            case Enemy.EnemyType.DRAGON:
                this.attackSpeed = attackSpeed * DifficultyManager.difficultyMultiplier;
                break;
            case Enemy.EnemyType.GORGON:
                this.attackSpeed = attackSpeed * DifficultyManager.difficultyMultiplier;
                isGorgon = true;
                break;
            case Enemy.EnemyType.DEMON:
                this.attackSpeed = attackSpeed * DifficultyManager.difficultyMultiplier;
                break;
        }
    }

    public override void FixedDo()
    {
        if (enemyRB.velocity != Vector2.zero)
        {
            Mathf.Lerp(enemyRB.velocity.x, 0, 5);
            Mathf.Lerp(enemyRB.velocity.y, 0, 5);
        }
    }
    public override void Exit()
    {
        enemy.StopCoroutine(Attacking);
        Attacking = null;
    }

    public override void Enter()
    {
        enemyRB.velocity = new Vector2((player.transform.position.x - enemy.transform.position.x), (player.transform.position.y - enemy.transform.position.y)).normalized * moveSpeed;
        if (isGorgon)
        {
            shoot = enemy.GetComponent<GorgonShoot>();
        }
        Attacking = enemy.StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        enemyAnimator.SetBool("chasing", false);
        yield return new WaitForSeconds(0.5f/attackSpeed);
        enemyAnimator.SetTrigger("attacking");
        Vector3 target = player.transform.position;
        target.z = 0;
        Vector3 start = enemy.transform.position;
        target.x -= start.x;
        target.y -= start.y;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Vector2 targeting = new Vector3(-(enemy.transform.position.x - player.transform.position.x) * .5f, -(enemy.transform.position.y - player.transform.position.y) * 0.5f).normalized;
        sprite.flipX = targeting.x < 0f;
        if (isGorgon)
        {
            yield return new WaitForSeconds(0.5f / attackSpeed);
            shoot.Shoot(targeting, enemy);
            yield return new WaitForSeconds(1f / attackSpeed);
            enemyAnimator.SetBool("hasAttacked", true);
        }
        else 
        {
            enemy.attackHitbox.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            enemy.attackHitbox.transform.localPosition = targeting;
            enemy.attackHitbox.SetActive(true);
            yield return new WaitForSeconds(2f / attackSpeed);
            enemy.attackHitbox.SetActive(false);
            enemyAnimator.SetBool("hasAttacked", true);
        }
        enemyAnimator.SetTrigger("attacking");
        enemy.enemyStateMachine.ChangeState(enemy.enemyRecovery);
    }
}
