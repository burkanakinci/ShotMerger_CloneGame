using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private Level[] m_Levels;
    private int m_CurrentLevelNumber;
    private int m_ActivatedLevelIndex;
    private bool mCurrentLevelPassed = false;
    #endregion
    #region ExternalAccess
    #endregion
    #region Actions
    #endregion
    public override void Initialize()
    {
        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnLevelCompleted += OnLevelCompleted;
        GameManager.Instance.OnLevelFailed += OnLevelFailed;
    }

    private void ActivateCurrentLevel()
    {
        m_CurrentLevelNumber = GameManager.Instance.PlayerManager.GetLevelNumber();

        if (IsLastLevelPlayed())
        {
            if (mCurrentLevelPassed)
            {
                m_ActivatedLevelIndex = SelectRandomLevelIndex();
                mCurrentLevelPassed = false;
            }
        }
        else
        {
            m_ActivatedLevelIndex = m_CurrentLevelNumber - 1;
        }

        SpawnLevelObject();
    }

    private bool IsLastLevelPlayed()
    {
        return m_Levels.Length <= m_CurrentLevelNumber - 1;
    }
    private int SelectRandomLevelIndex()
    {
        return Random.Range(0, (m_Levels.Length));
    }

    private Level m_TempSpawnedLevel;
    private void SpawnLevelObject()
    {
        if (m_TempSpawnedLevel != null)
        {
            m_TempSpawnedLevel.gameObject.SetActive(false);
        }
        if (IsLastLevelPlayed())
        {
            m_TempSpawnedLevel = m_Levels[m_ActivatedLevelIndex];
        }
        else
        {
            m_TempSpawnedLevel = Instantiate(m_Levels[m_ActivatedLevelIndex], Vector3.zero, Quaternion.identity, null).GetComponent<Level>();
            m_Levels[m_ActivatedLevelIndex] = m_TempSpawnedLevel;
            m_TempSpawnedLevel.Initialize();
        }
        m_TempSpawnedLevel.gameObject.SetActive(true);
        m_TempSpawnedLevel.ActiveLevel();
    }

    private void OnResetToMainMenu()
    {
        ActivateCurrentLevel();
    }

    private void OnLevelCompleted()
    {
        mCurrentLevelPassed = true;
    }

    private void OnLevelFailed()
    {
        mCurrentLevelPassed = false;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
        GameManager.Instance.OnLevelCompleted -= OnLevelCompleted;
        GameManager.Instance.OnLevelFailed -= OnLevelFailed;
    }

}
