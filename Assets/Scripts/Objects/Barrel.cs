using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrel : CustomBehaviour
{
    [SerializeField] private TextMeshPro m_BarrelCountText;
    [SerializeField] private int m_BarrelCount = 5;
    private int m_CurrentBarrelCount;

    #region StartValue
    private Vector3 m_StartPos;
    private Quaternion m_StartRot;

    #endregion
    public override void Initialize()
    {
        m_StartPos = transform.position;
        m_StartRot = transform.rotation;
    }

    public void ActiveBarrel()
    {
        m_CurrentBarrelCount = m_BarrelCount;
        SetBarrelText();
        transform.position = m_StartPos;
        transform.rotation = m_StartRot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ObjectTags.Bullet))
        {
            DecreaseBarrelCount();
            SetBarrelText();
        }
    }

    private void SetBarrelText()
    {
        if (m_CurrentBarrelCount > 0)
        {
            m_BarrelCountText.text = m_CurrentBarrelCount.ToString();
        }
        else
        {
            m_BarrelCountText.text = "";
        }
    }

    private void DecreaseBarrelCount()
    {
        m_CurrentBarrelCount--;
        if (m_CurrentBarrelCount <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
