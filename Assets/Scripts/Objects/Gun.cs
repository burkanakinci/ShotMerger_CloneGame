using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : CustomBehaviour
{
    private Vector3 m_StartLocalPos;
    public override void Initialize()
    {
        m_StartLocalPos = transform.localPosition;
        GameManager.Instance.OnResetToMainMenu += OnResetMainMenu;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ObjectTags.Barrel))
        {
            GameManager.Instance.LevelFailed();
        }
    }

    private void OnResetMainMenu()
    {
        transform.localPosition = m_StartLocalPos;
    }
}
