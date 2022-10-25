using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private PlayerMovement m_PlayerMovement;
    private PlayerStateMachine m_PlayerStateMachine;
    [SerializeField] private Transform m_DefaultBulletSpawnTransform;
    [SerializeField] private Transform m_CollectedTransform;
    [SerializeField] private List<GunShooter> m_GunShooters;
    [SerializeField] private Gun m_Gun;
    #endregion
    #region ExternalAccess
    public Transform CollectedTransform => m_CollectedTransform;
    public PlayerStateMachine PlayerStateMachine => m_PlayerStateMachine;
    #endregion
    public override void Initialize()
    {
        m_PlayerStateMachine = new PlayerStateMachine(this);
        m_PlayerMovement.Initialize();
        m_Gun.Initialize();

        m_GunShooters = new List<GunShooter>();

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
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
        }
    }

    public void PlayerForward()
    {
        m_PlayerMovement.PlayerForwardMovement();
    }

    private Vector3 m_TempCollectedLocalPos;
    private double m_TempDoubleConvertor;
    public void AddedCollected(Collactable _collected, ref CollactableData _collectedData)
    {
        _collected.transform.SetParent(CollectedTransform);
        m_TempCollectedLocalPos = _collected.transform.localPosition;
        m_TempDoubleConvertor = Math.Round(m_TempCollectedLocalPos.x, 3);
        m_TempCollectedLocalPos.x = (float)m_TempDoubleConvertor;
        m_TempCollectedLocalPos.x -= (m_TempCollectedLocalPos.x % 0.375f);
        _collected.transform.localPosition = m_TempCollectedLocalPos;

        if (GetShooterByLocalX(_collected.transform.localPosition.x) == null)
        {
            GunShooter tempGunShooter = new GunShooter(_collected.transform);
            if (_collectedData.CollactableOperation == CollactableOperation.Adding)
            {
                tempGunShooter.UpdateBulletCount((2 + _collectedData.CollactableValue), (_collected.transform));
            }
            else if (_collectedData.CollactableOperation == CollactableOperation.Multiplication)
            {
                tempGunShooter.UpdateBulletCount((2 * _collectedData.CollactableValue), (_collected.transform));
            }
            m_GunShooters.Add(tempGunShooter);
        }
        else
        {
            if (_collectedData.CollactableOperation == CollactableOperation.Adding)
            {
                GetShooterByLocalX(_collected.transform.localPosition.x).UpdateBulletCount((GetShooterByLocalX(_collected.transform.localPosition.x).BulletCountPerSecond + _collectedData.CollactableValue), (_collected.transform));
            }
            else if (_collectedData.CollactableOperation == CollactableOperation.Multiplication)
            {
                GetShooterByLocalX(_collected.transform.localPosition.x).UpdateBulletCount((GetShooterByLocalX(_collected.transform.localPosition.x).BulletCountPerSecond * _collectedData.CollactableValue), (_collected.transform));
            }
        }
    }
    public GunShooter GetShooterByLocalX(float _xPos)
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

    private GunShooter m_TempGunShooter;
    private void OnResetToMainMenu()
    {
        m_GunShooters.Clear();

        m_TempGunShooter = new GunShooter(m_DefaultBulletSpawnTransform);
        m_TempGunShooter.UpdateBulletCount(1, m_DefaultBulletSpawnTransform);
        m_GunShooters.Add(m_TempGunShooter);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
    }

    #endregion

    #region Datas
    public void UpdateCoinCountData(int _coinCount)
    {
        GameManager.Instance.JsonConverter.PlayerData.CoinCount = _coinCount;
        GameManager.Instance.JsonConverter.SavePlayerData();
    }
    public int GetTotalCoinCount()
    {
        return GameManager.Instance.JsonConverter.PlayerData.CoinCount;
    }
    public void UpdateLevelData(int _levelNumber)
    {
        GameManager.Instance.JsonConverter.PlayerData.LevelNumber = _levelNumber;
        GameManager.Instance.JsonConverter.SavePlayerData();
    }
    private void UpdateNextLevel()
    {
        GameManager.Instance.JsonConverter.PlayerData.LevelNumber = (GetLevelNumber() + 1);
        GameManager.Instance.JsonConverter.SavePlayerData();
    }

    public int GetLevelNumber()
    {
        return GameManager.Instance.JsonConverter.PlayerData.LevelNumber;
    }
    #endregion
}
