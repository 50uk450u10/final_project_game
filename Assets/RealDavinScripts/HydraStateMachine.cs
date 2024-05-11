using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraStateMachine
{
    public HydraState hCurrentState { get; set; }

    public void Initialize(HydraState startingState)
    {
        hCurrentState = startingState;
        hCurrentState.Enter();
    }
    public void ChangeState(HydraState changingState)
    {
        hCurrentState.Exit();
        hCurrentState = changingState;
        changingState.Enter();
    }
}
