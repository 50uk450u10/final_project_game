using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraIdle : HydraState
{
    Coroutine Waiting;
    public HydraIdle(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads, GameObject damageArea, GameObject damagableArea) : base(hydra, hydraStateMachine, hydraAnimator, player, attackSpeed, head, dangerArea, p, numOfHeads, damageArea, damagableArea)
    {

    }

    public override void Enter()
    {
        Waiting = head.StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1 / (DifficultyManager.difficultyMultiplier * attackSpeed));
        head.hydraStateMachine.ChangeState(head.hydraShoot);
    }

    public override void Exit()
    {
        head.StopCoroutine(Waiting);
        Waiting = null;
    }
}
