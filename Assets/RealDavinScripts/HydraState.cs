using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraState 
{
    protected HydraScript hydra;
    protected HydraStateMachine hydraStateMachine;
    protected Animator hydraAnimator;
    protected float attackSpeed;
    protected PlayerController player;
    protected HydraHeadScript head;
    protected BoxCollider2D dangerArea;
    protected GameObject p;
    protected int numOfHeads;
    protected GameObject damageArea;
    protected GameObject damagableArea;

    public virtual void Enter() { }

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public virtual void Exit() { }

    public HydraState(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads, GameObject damageArea, GameObject damagableArea)
    {
        this.hydra = hydra;
        this.hydraStateMachine = hydraStateMachine;
        this.hydraAnimator = hydraAnimator;
        this.attackSpeed = attackSpeed;
        this.player = player;
        this.head = head;
        this.dangerArea = dangerArea;
        this.p = p;
        this.numOfHeads = numOfHeads;
        this.damageArea = damageArea;
        this.damagableArea = damagableArea;
    }
}
