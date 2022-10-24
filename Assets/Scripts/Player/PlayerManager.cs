using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private PlayerMovement m_PlayerMovement;
    private PlayerStateMachine m_PlayerStateMachine;
    [SerializeField] private Transform m_DefaultBulletSpawnTransform;
    private List<GunShooter> m_GunShooters;
    #endregion

    #region ExternalAccess
    public PlayerStateMachine PlayerStateMachine => m_PlayerStateMachine;
    #endregion
    public override void Initialize()
    {
        m_PlayerStateMachine = new PlayerStateMachine(this);
        m_PlayerMovement.Initialize();

        m_GunShooters = new List<GunShooter>();

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
    }

    private void Update()
    {
        m_PlayerStateMachine.UpdateStateMachine();
        UpdateGunShooters();
    }

    private void UpdateGunShooters()
    {
        for (int i = m_GunShooters.Count - 1; i >= 0; i--)
        {
            m_GunShooters[i].ShootBullet();
        }
    }

    public void PlayerForward()
    {
        m_PlayerMovement.PlayerForwardMovement();
    }

    #region Events
    private void OnStartGame()
    {

    }

    private void OnResumeGame()
    {
    }

    private GunShooter m_TempGunShooter;
    private void OnResetToMainMenu()
    {
        m_GunShooters.Clear();

        m_TempGunShooter = new GunShooter(m_DefaultBulletSpawnTransform);
        m_TempGunShooter.UpdateBulletCount(5);
        m_GunShooters.Add(m_TempGunShooter);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
    }

    #endregion
}
