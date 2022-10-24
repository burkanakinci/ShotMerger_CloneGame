using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunShooter
{
    #region Attributes
    [SerializeField]private Transform m_BulletSpawnPos;
    [SerializeField]private int m_BulletCountPerSecond;
    private float m_Timer;
    #endregion

    #region ExternalAccess
    public int BulletCountPerSecond => m_BulletCountPerSecond;
    public float BulletSpawnXValue => m_BulletSpawnPos.localPosition.x;
    #endregion
    public GunShooter(Transform _bulletSpawnPos)
    {
        m_BulletSpawnPos = _bulletSpawnPos;

        m_Timer = 0;
    }


    public void UpdateBulletCount(int _bulletCount)
    {
        m_BulletCountPerSecond = _bulletCount;
        m_TempTimer = 1.0f / m_BulletCountPerSecond;
    }

    private float m_TempTimer;
    private int m_TempSpawnedCount;
    public void ShootBullet()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= m_TempTimer)
        {
            m_TempSpawnedCount = (int)(m_Timer / m_TempTimer);

            for (int _spawnCount = m_TempSpawnedCount; _spawnCount > 0; _spawnCount--)
            {
                GameManager.Instance.ObjectPool.SpawnFromPool(PooledObjectTags.Bullet, m_BulletSpawnPos.position, Quaternion.identity, null);
            }

            m_Timer -= (m_TempTimer * m_TempSpawnedCount);

        }
    }
}
