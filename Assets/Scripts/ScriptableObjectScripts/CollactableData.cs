using UnityEngine;

[CreateAssetMenu(fileName = "CollactableData", menuName = "Collactable Data")]
public class CollactableData : ScriptableObject
{
    #region Attributes
    [SerializeField] private CollactableOperation m_CollactableOperation;
    [SerializeField] private int m_CollactableValue;
    #endregion

    #region ExternalAccess
    public CollactableOperation CollactableOperation => m_CollactableOperation;
    public int CollactableValue => m_CollactableValue;
    #endregion
}
