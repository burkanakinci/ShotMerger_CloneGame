using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    public PlayerStateMachine(PlayerManager _player)
    {
        m_Player = _player;

        m_States = new Dictionary<string, BaseState>();
        m_States.Add("PlayerIdle", new Idle("PlayerIdle", this));
        m_States.Add("PlayerFail", new Fail("PlayerFail", this));
        m_States.Add("PlayerRun", new Run("PlayerRun", this));
        m_States.Add("PlayerSuccess", new Success("PlayerSuccess", this));

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
