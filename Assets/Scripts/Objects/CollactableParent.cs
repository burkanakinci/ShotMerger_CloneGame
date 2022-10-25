using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollactableParent : CustomBehaviour
{
    [SerializeField] private List<Collactable> m_Collactables;

    #region StartValue
    private Vector3 m_StartPos;
    private Quaternion m_StartRot;
    #endregion
    public override void Initialize()
    {
        m_CollectedJumpTweenID = GetInstanceID() + "m_CollectedJumpTweenID";

        m_StartPos = transform.position;
        m_StartRot = transform.rotation;

        m_Collactables.ForEach
        (
            x => x.Initialize(this)
        );
    }
    public void ActiveCollactableParent()
    {

        if (m_CollectCoroutine != null)
        {
            StopCoroutine(m_CollectCoroutine);
        }
        DOTween.Kill(m_CollectedJumpTweenID);

        transform.position = m_StartPos;
        transform.rotation = m_StartRot;

        m_Collactables.ForEach
        (
            x => x.ActiveCollactable()
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
            StartCollectCoroutine();
        }).
        SetId(m_CollectedJumpTweenID);
    }

    private Coroutine m_CollectCoroutine;
    private void StartCollectCoroutine()
    {
        if (m_CollectCoroutine != null)
        {
            StopCoroutine(m_CollectCoroutine);
        }
        m_CollectCoroutine = StartCoroutine(CollectCoroutine());
    }
    private IEnumerator CollectCoroutine()
    {
        yield return new WaitForEndOfFrame();
        for (int _collactableCount = m_Collactables.Count - 1; _collactableCount >= 0; _collactableCount--)
        {
            m_Collactables[_collactableCount].CollectCollactable();
        }
    }
}
