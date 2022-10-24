using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : CustomBehaviour
{
    #region Attributes
    private List<Bullet> m_BulletOnScene;
    #endregion
    public override void Initialize()
    {
        m_BulletOnScene = new List<Bullet>();
    }

    #region ListManagement
    public void ManageBulletList(ListOperation _operation, Bullet _bullet)
    {
        if ((_operation == ListOperation.Adding) && (!m_BulletOnScene.Contains(_bullet)))
        {
            m_BulletOnScene.Add(_bullet);
        }
        else if ((_operation == ListOperation.Subtraction) && (m_BulletOnScene.Contains(_bullet)))
        {
            m_BulletOnScene.Remove(_bullet);
        }
    }
    #endregion
}
