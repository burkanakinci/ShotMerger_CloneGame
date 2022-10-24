using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private PlayerMovement m_PlayerMovement;
    private PlayerStateMachine m_PlayerStateMachine;
    [SerializeField] private Transform m_DefaultBulletSpawnTransform;
    [SerializeField] private Transform m_CollectedTransform;
    [SerializeField] private List<GunShooter> m_GunShooters;
    #endregion
    public CollactableParent collactableParent;
    #region ExternalAccess
    public Transform CollectedTransform => m_CollectedTransform;
    #endregion
    public override void Initialize()
    {
        m_PlayerStateMachine = new PlayerStateMachine(this);
        m_PlayerMovement.Initialize();

        m_GunShooters = new List<GunShooter>();

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;

        collactableParent.Initialize();
    }

    private void Update()
    {
        m_PlayerStateMachine.UpdateStateMachine();
    }

    public void UpdateGunShooters()
    {
        for (int i = m_GunShooters.Count - 1; i >= 0; i--)
        {
            m_GunShooters[i].ShootBullet();
            Debug.Log(m_GunShooters.Count);
        }
    }

    public void PlayerForward()
    {
        m_PlayerMovement.PlayerForwardMovement();
    }

    public void AddedCollected(float _collectedXPos, Collactable _collected, ref CollactableData _collectedData)
    {
        GunShooter tempGunShooter = new GunShooter(_collected.transform);
        if (GetShooterByLocalX(_collectedXPos) == null)
        {
            if (_collectedData.CollactableOperation == CollactableOperation.Adding)
            {
                tempGunShooter.UpdateBulletCount((2 + _collectedData.CollactableValue));
            }
            else if (_collectedData.CollactableOperation == CollactableOperation.Multiplication)
            {
                tempGunShooter.UpdateBulletCount((2 * _collectedData.CollactableValue));
            }
            m_GunShooters.Add(tempGunShooter);
        }
        else
        {
            if (_collectedData.CollactableOperation == CollactableOperation.Adding)
            {
                GetShooterByLocalX(_collectedXPos).UpdateBulletCount((GetShooterByLocalX(_collectedXPos).BulletCountPerSecond + _collectedData.CollactableValue));
            }
            else if (_collectedData.CollactableOperation == CollactableOperation.Multiplication)
            {
                GetShooterByLocalX(_collectedXPos).UpdateBulletCount((GetShooterByLocalX(_collectedXPos).BulletCountPerSecond * _collectedData.CollactableValue));
            }
        }

        if (GetShooterByLocalX(m_DefaultBulletSpawnTransform.localPosition.x) != null)
        {
            m_GunShooters.Remove(GetShooterByLocalX(m_DefaultBulletSpawnTransform.localPosition.x));
        }
    }
    private GunShooter GetShooterByLocalX(float _xPos)
    {
        for (int _shooterCount = m_GunShooters.Count - 1; _shooterCount >= 0; _shooterCount--)
        {
            if (m_GunShooters[_shooterCount].BulletSpawnXValue == _xPos)
            {
                return m_GunShooters[_shooterCount];
            }
        }
        return null;
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
        m_TempGunShooter.UpdateBulletCount(1);
        m_GunShooters.Add(m_TempGunShooter);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
    }

    #endregion
}
