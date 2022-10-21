using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Player Movement Data")]
public class PlayerMovementData : ScriptableObject
{
    #region Attributes
    [SerializeField] private float m_ForwardSpeed = 5f;
    [SerializeField] private float m_HorizontalSpeed = 50f;
    [SerializeField] private float m_XClampValue = 2.5f;
    #endregion

    #region ExternalAccess
    public float ForwardSpeed => m_ForwardSpeed;
    public float HorizontalSpeed => m_HorizontalSpeed;
    public float XClampValue => m_XClampValue;
    #endregion
}
