using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollactableParent : CustomBehaviour
{
    [SerializeField] private List<Collactable> m_Collactables;
    public override void Initialize()
    {
        m_CollectedJumpTweenID = GetInstanceID() + "m_CollectedJumpTweenID";

        m_Collactables.ForEach
        (
            x => x.Initialize(this)
        );
    }

    private string m_CollectedJumpTweenID;
    public void MoveCollactableParent(Vector3 _diff, Transform _collidedTransform)
    {
        this.transform.SetParent(_collidedTransform);

        DOTween.Kill(m_CollectedJumpTweenID);

        this.transform.DOLocalJump(_diff, 1f, 1, 1f).
        OnComplete(() =>
        {
            for (int _collactableCount = m_Collactables.Count - 1; _collactableCount >= 0;_collactableCount--)
            {
                m_Collactables[_collactableCount].CollectCollactable();
            }
        }).
        SetId(m_CollectedJumpTweenID);
    }
}
