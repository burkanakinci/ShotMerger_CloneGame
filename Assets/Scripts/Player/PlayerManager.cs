using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private PlayerMovement m_PlayerMovement;
    #endregion
    public override void Initialize()
    {
        m_PlayerMovement.Initialize();
    }
}
