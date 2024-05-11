using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraShoot : HydraState
{
    Coroutine Pausing;
    public HydraShoot(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads) : base(hydra, hydraStateMachine, hydraAnimator, player, attackSpeed, head, dangerArea,p, numOfHeads)
    {

    }

    public override void Enter()
    {
        hydraAnimator.SetBool("firing", true);
        Pausing = head.StartCoroutine(Pause());
    }
    public override void Exit()
    {
        hydraAnimator.SetBool("firing", false);
        head.StopCoroutine(Pausing);
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        head.Shoot();
        yield return new WaitForSeconds(1.1f);
        head.hydraStateMachine.ChangeState(head.hydraIdle);
    }
}
