using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraDead : HydraState
{
    int heads;
    public HydraDead(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads) : base(hydra, hydraStateMachine, hydraAnimator, player, attackSpeed, head, dangerArea, p, numOfHeads)
    {

    }

    public override void Enter()
    {
        heads = head.HeadCount();
        switch (heads)
        {
            case 2:
                hydraAnimator.SetBool("2nd", true);
                break;
            case 3:
                hydraAnimator.SetBool("3rd", true);
                break;
        }
    }
}
