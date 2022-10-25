using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CustomBehaviour, IPooledObject
{
    #region Attributes
    [SerializeField] private BulletData m_BulletData;
    [SerializeField] private Rigidbody m_BulletRigidbody;
    #endregion
    public override void Initialize()
    {

    }
    private void FixedUpdate()
    {
        m_BulletRigidbody.velocity = (m_BulletData.BulletForwardSpeed * transform.forward);
    }
    public void OnObjectSpawn()
    {
        transform.eulerAngles = Vector3.zero;
        GameManager.Instance.Entities.ManageBulletList(ListOperation.Adding, this);

        StartDestroyBulletCoroutine(true);
    }
    public void OnObjectDeactive()
    {
        GameManager.Instance.Entities.ManageBulletList(ListOperation.Subtraction, this);
        GameManager.Instance.ObjectPool.AddObjectPool(PooledObjectTags.Bullet, this);

        if (m_DestroyBulletCoroutine != null)
        {
            StopCoroutine(m_DestroyBulletCoroutine);
        }

        this.gameObject.SetActive(false);
    }
    public CustomBehaviour GetGameObject()
    {
        return this;
    }
    private Coroutine m_DestroyBulletCoroutine;
    private void StartDestroyBulletCoroutine(bool _onLifeTime)
    {
        if (m_DestroyBulletCoroutine != null)
        {
            StopCoroutine(m_DestroyBulletCoroutine);
        }
        if (_onLifeTime)
        {
            m_DestroyBulletCoroutine = StartCoroutine(DestroyBullet(m_BulletData.BulletLifeTime));
        }
        else
        {
            m_DestroyBulletCoroutine = StartCoroutine(DestroyBullet());
        }
    }
    private IEnumerator DestroyBullet(float _lifeTime)
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        OnObjectDeactive();
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForEndOfFrame();
        OnObjectDeactive();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ObjectTags.Barrel))
        {
            StartDestroyBulletCoroutine(false);
        }
    }
}
