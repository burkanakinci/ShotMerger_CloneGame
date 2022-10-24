using UnityEngine;
using System.Collections.Generic;

public class StateMachine
{
    protected BaseState m_CurrentState;
    protected PlayerManager m_Player;
    public PlayerManager Player => m_Player;
    protected Dictionary<string, BaseState> m_States;

    public void UpdateStateMachine()
    {
        if (m_CurrentState != null)
        {
            m_CurrentState.UpdateLogic();
        }
    }
    public void ChangeState(string _nextState, bool _changeForce = false)
    {
        if (m_States[_nextState] != m_CurrentState || _changeForce)
        {
            if (m_CurrentState != null)
            {
                m_CurrentState.Exit();
            }

            m_CurrentState = m_States[_nextState];
            m_CurrentState.Enter();
        }
    }
}
