using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private PlayerMovement m_PlayerMovement;
    private PlayerStateMachine m_PlayerStateMachine;
    #endregion

    #region ExternalAccess
    public PlayerStateMachine PlayerStateMachine => m_PlayerStateMachine;
    #endregion
    public override void Initialize()
    {
        m_PlayerStateMachine = new PlayerStateMachine(this);
        m_PlayerMovement.Initialize();
    }

    private void Update()
    {
        m_PlayerStateMachine.UpdateStateMachine();
    }

    public void PlayerForward()
    {
        m_PlayerMovement.PlayerForwardMovement();
    }
}
