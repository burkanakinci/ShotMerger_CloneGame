using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private Idle m_IdleState;
    private PlayerManager m_Player;
    public PlayerStateMachine()
    {
        m_IdleState = new Idle("PlayerIdle", this);
        m_States.Add("PlayerIdle", m_IdleState);
    }
}
