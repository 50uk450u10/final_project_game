using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraShoot : HydraState
{
    Coroutine Pausing;
    public HydraShoot(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads, GameObject damageArea, GameObject damagableArea) : base(hydra, hydraStateMachine, hydraAnimator, player, attackSpeed, head, dangerArea,p, numOfHeads, damageArea, damagableArea)
    {

    }

    public override void Enter()
    {
        hydraAnimator.SetBool("firing", true);
        Pausing = head.StartCoroutine(Pause());
        head.hydraSounds.PlayOneShot(head.fireBreath);
    }
    public override void Exit()
    {
        hydraAnimator.SetBool("firing", false);
        head.StopCoroutine(Pausing);
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.2f);
        head.Shoot(head.HeadCount());
        yield return new WaitForSeconds((1 / (DifficultyManager.difficultyMultiplier * attackSpeed)));
        head.hydraStateMachine.ChangeState(head.hydraIdle);
    }
}
