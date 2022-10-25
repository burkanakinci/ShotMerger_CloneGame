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

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnGameStart += OnStartGame;
        GameManager.Instance.OnLevelFailed += OnFailGame;
        GameManager.Instance.OnLevelCompleted += OnSuccessGame;
    }

    #region Events
    private void OnStartGame()
    {
        ChangeState(PlayerStates.RunState);
    }
    private void OnResetToMainMenu()
    {
        ChangeState(PlayerStates.IdleState, true);
    }
    private void OnFailGame()
    {
        ChangeState(PlayerStates.FailState);
    }
    private void OnSuccessGame()
    {
        ChangeState(PlayerStates.SuccessState);
    }

    public bool EqualCurrentState(string _state)
    {
        return m_States[_state] == m_CurrentState;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
        GameManager.Instance.OnGameStart -= OnStartGame;
        GameManager.Instance.OnResetToMainMenu -= OnFailGame;
        GameManager.Instance.OnGameStart -= OnSuccessGame;
    }

    #endregion
}
