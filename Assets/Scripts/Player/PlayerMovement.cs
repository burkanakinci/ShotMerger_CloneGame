using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement
{
    #region Attributes
    [SerializeField] private Transform m_PlayerForwardParent;
    [SerializeField] private Transform m_PlayerGun;
    [SerializeField] private PlayerMovementData m_PlayerMovementData;
    #endregion
    public void Initialize()
    {
        GameManager.Instance.InputManager.OnSwiped += SwipeGun;
    }

    private float m_TargetXPos;
    public void SwipeGun(float _horizontalChange)
    {
        m_TargetXPos =
        m_PlayerGun.localPosition.x + (_horizontalChange * m_PlayerMovementData.HorizontalSpeed);

        m_TargetXPos = Mathf.Clamp(m_TargetXPos, (-1.0f * m_PlayerMovementData.XClampValue), m_PlayerMovementData.XClampValue);

        m_PlayerGun.localPosition = new Vector3(m_TargetXPos,
                m_PlayerGun.localPosition.y,
                m_PlayerGun.localPosition.z);
    }

    public void PlayerForwardMovement()
    {
        m_PlayerForwardParent.position = m_PlayerForwardParent.position + (Vector3.forward * m_PlayerMovementData.ForwardSpeed * Time.deltaTime);
    }
}
