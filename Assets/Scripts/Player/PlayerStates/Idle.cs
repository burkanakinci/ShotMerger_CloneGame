using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    public Idle(string _stateName, StateMachine _stateMachine) : base(_stateName, _stateMachine)
    {
    }

    public override void Enter()
    {
    }
    public override void UpdateLogic()
    {
    }
    public override void Exit()
    {
        return;
    }
}
