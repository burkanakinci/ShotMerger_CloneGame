using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : CustomBehaviour
{
    [SerializeField] private Barrel[] m_BarrelsOnLevel;
    [SerializeField] private CollactableParent[] m_CollactableParentsOnLevel;
    public override void Initialize()
    {
        for (int _barrels = m_BarrelsOnLevel.Length - 1; _barrels >= 0; _barrels--)
        {
            m_BarrelsOnLevel[_barrels].Initialize();
        }
        for (int _collactables = m_CollactableParentsOnLevel.Length - 1; _collactables >= 0; _collactables--)
        {
            m_CollactableParentsOnLevel[_collactables].Initialize();
        }
    }

    public void ActiveLevel()
    {
        for (int _barrels = m_BarrelsOnLevel.Length - 1; _barrels >= 0; _barrels--)
        {
            m_BarrelsOnLevel[_barrels].gameObject.SetActive(true);
            m_BarrelsOnLevel[_barrels].ActiveBarrel();
        }
        for (int _collactables = m_CollactableParentsOnLevel.Length - 1; _collactables >= 0; _collactables--)
        {
            m_CollactableParentsOnLevel[_collactables].gameObject.SetActive(true);
            m_CollactableParentsOnLevel[_collactables].ActiveCollactableParent();
        }
    }
}
