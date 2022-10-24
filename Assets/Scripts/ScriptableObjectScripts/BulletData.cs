using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Bullet Data")]
public class BulletData : ScriptableObject
{
    #region Attributes
    [SerializeField] private float m_BulletForwardSpeed=0.5f;
    [SerializeField] private float m_BulletLifeTime=1.5f;
    #endregion

    #region ExternalAccess
    public float BulletForwardSpeed => m_BulletForwardSpeed;
    public float BulletLifeTime => m_BulletLifeTime;
    #endregion
}
