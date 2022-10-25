using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : CustomBehaviour
{
    public override void Initialize()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ObjectTags.Gun))
        {
            GameManager.Instance.LevelCompleted();
        }
    }
}
