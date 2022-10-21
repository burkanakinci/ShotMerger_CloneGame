using UnityEngine;
using System.Collections.Generic;

public class StateMachine
{
    private BaseState m_CurrentState;
    protected Dictionary<string, BaseState> m_States;

    private void Update()
    {
        if (m_CurrentState != null)
        {
            m_CurrentState.UpdateLogic();
        }
    }
    public void ChangeState(BaseState _nextState)
    {
        if (_nextState != m_CurrentState)
        {
            if (m_CurrentState != null)
            {
                m_CurrentState.Exit();
            }

            m_CurrentState = _nextState;
            m_CurrentState.Enter();
        }
    }    
}
