using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter
{
    private Transform m_BulletSpawnPos;
    public GunShooter(Transform _bulletSpawnPos)
    {
        m_BulletSpawnPos = _bulletSpawnPos;

        m_Timer = 0;
    }

    private int m_BulletCountPerSecond;
    public void UpdateBulletCount(int _bulletCount)
    {
        m_BulletCountPerSecond = _bulletCount;
        m_TempTimer = 1.0f / m_BulletCountPerSecond;
    }

    private float m_Timer, m_TempTimer;
    public void ShootBullet()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= m_TempTimer)
        {
            GameManager.Instance.ObjectPool.SpawnFromPool(PooledObjectTags.Bullet, m_BulletSpawnPos.position, Quaternion.identity, null);
            m_Timer = 0.0f;
        }
    }
}
