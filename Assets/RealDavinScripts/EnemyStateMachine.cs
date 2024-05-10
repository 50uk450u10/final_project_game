using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState currentState { get; set; }

    public void Initialize(EnemyState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(EnemyState changingState)
    {
        currentState.Exit();
        currentState = changingState;
        changingState.Enter();
    }
}
