using System;
using UnityEngine;
public class CameraManager : CustomBehaviour
{
    #region Attributes
    [SerializeField] private Camera m_MainCamera;
    [SerializeField] private CameraMovementData m_CameraMovementData;
    [SerializeField] private Transform m_FollowedObject;
    #endregion


    private Vector3 lookPos;
    private Quaternion camRotation;
    public override void Initialize()
    {
        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
    }

    public void LateUpdate()
    {
        FollowCamera();
    }

    public void FollowCamera()
    {
        if (m_FollowedObject == null)
        {
            return;
        }
        m_MainCamera.transform.position = (m_FollowedObject.position + m_CameraMovementData.PlayPositionOffset);
    }

    #region Events
    private void OnStartGame()
    {

    }

    private void OnResumeGame()
    {
    }

    private void OnResetToMainMenu()
    {
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
    }

    #endregion
}
