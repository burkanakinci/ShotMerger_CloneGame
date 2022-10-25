using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Collactable : CustomBehaviour
{
    private CollactableParent m_CollactableParent;
    [SerializeField] private CollactableData m_CollactableData;

    #region StartValue
    private Vector3 m_StartPos;
    private Quaternion m_StartRot;
    #endregion
    public void Initialize(CollactableParent _collactableParent)
    {
        m_CollactableParent = _collactableParent;
        this.gameObject.layer = (int)ObjectsLayer.Collactable;

        m_StartPos = transform.localPosition;
        m_StartRot = transform.localRotation;
    }

    public void ActiveCollactable()
    {
        transform.localPosition = m_StartPos;
        transform.localRotation = m_StartRot;
    }

    private Vector3 m_TempCollisionDiff, m_TempCollidedLocalPos;
    private double m_TempDiffConvertor, m_TempCollidedConvertor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ObjectTags.Gun) || (other.CompareTag(ObjectTags.Collactable)))
        {
            m_TempCollisionDiff = m_CollactableParent.transform.position - transform.position;
            m_TempCollisionDiff.z += 0.375f;
            m_TempDiffConvertor = Math.Round(m_TempCollisionDiff.x, 3);
            m_TempCollisionDiff.x = (float)m_TempDiffConvertor;
            m_TempCollisionDiff.x -= (m_TempCollisionDiff.x % 0.375f);

            m_TempCollidedLocalPos = other.transform.localPosition;
            m_TempCollidedConvertor = Math.Round(m_TempCollidedLocalPos.x, 2);
            m_TempCollidedLocalPos.x = (float)m_TempCollidedConvertor;
            m_TempCollidedLocalPos.x -= (m_TempCollidedLocalPos.x % 0.75f);



            m_CollactableParent.MoveCollactableParent
            (m_TempCollisionDiff,
            GameManager.Instance.PlayerManager.GetShooterByLocalX(m_TempCollidedLocalPos.x).LastCollected);

        }
    }

    public void CollectCollactable()
    {
        this.gameObject.layer = (int)ObjectsLayer.Collacted;
        GameManager.Instance.PlayerManager.AddedCollected(this, ref m_CollactableData);
    }

}
