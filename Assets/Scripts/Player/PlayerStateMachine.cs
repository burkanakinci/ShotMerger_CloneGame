using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    public PlayerStateMachine(PlayerManager _player)
    {
        m_Player = _player;

        m_States = new Dictionary<string, BaseState>();
        m_States.Add(PlayerStates.IdleState, new Idle(PlayerStates.IdleState, this));
        m_States.Add(PlayerStates.FailState, new Fail(PlayerStates.FailState, this));
        m_States.Add(PlayerStates.RunState, new Run(PlayerStates.RunState, this));
        m_States.Add(PlayerStates.SuccessState, new Success(PlayerStates.SuccessState, this));

        GameManager.Instance.OnResetToMainMenu += OnStartGame;
    }

    #region Events
    private void OnStartGame()
    {
        ChangeState(PlayerStates.IdleState, true);
    }

    private void OnResumeGame()
    {
    }

    private void OnResetToMainMenu()
    {
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnStartGame;
    }

    #endregion
}
