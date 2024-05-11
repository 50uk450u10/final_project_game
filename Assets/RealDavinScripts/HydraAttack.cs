using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraAttack : HydraState
{
    Coroutine Slam;
    public HydraAttack(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads) : base(hydra, hydraStateMachine, hydraAnimator, player, attackSpeed, head, dangerArea,p, numOfHeads)
    {

    }
    public override void Enter()
    {
        hydraAnimator.SetBool("attacking", true);
        Slam = head.StartCoroutine(SerpentSLAM());
    }
    public override void Exit()
    {
        hydraAnimator.SetBool("attacking", false);
        head.StopCoroutine(Slam);
    }
    IEnumerator SerpentSLAM()
    {
        yield return new WaitForSeconds(1.7f/2);
        hydraAnimator.SetFloat("multiplier", 0);
        yield return new WaitForSeconds(2);
        hydraAnimator.SetFloat("multiplier", 1);
        yield return new WaitForSeconds(1.7f / 2);
        head.hydraStateMachine.ChangeState(head.hydraAttack);
    }
}
