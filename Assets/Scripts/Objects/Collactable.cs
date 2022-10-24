using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : CustomBehaviour
{
    private CollactableParent m_CollactableParent;
    [SerializeField] private CollactableData m_CollactableData;
    public void Initialize(CollactableParent _collactableParent)
    {
        m_CollactableParent = _collactableParent;
    }

    private Vector3 m_TempCollisionDiff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ObjectTags.Gun))
        {
            m_TempCollisionDiff = m_CollactableParent.transform.position - transform.position;
            m_TempCollisionDiff.z += 0.375f;
            m_CollactableParent.MoveCollactableParent(m_TempCollisionDiff, GameManager.Instance.PlayerManager.CollectedTransform);
        }
    }

    public void CollectCollactable()
    {
        GameManager.Instance.PlayerManager.AddedCollected(transform.localPosition.x, this, ref m_CollactableData);
    }

}
