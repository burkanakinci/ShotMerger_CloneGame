using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : BaseState
{
    public Run(string _stateName, StateMachine _stateMachine) : base(_stateName, _stateMachine)
    {
    }

    public override void Enter()
    {
        return;
    }
    public override void UpdateLogic()
    {
        m_stateMachine.Player.PlayerForward();
        m_stateMachine.Player.UpdateGunShooters();
    }
    public override void Exit()
    {
        return;
    }
}
