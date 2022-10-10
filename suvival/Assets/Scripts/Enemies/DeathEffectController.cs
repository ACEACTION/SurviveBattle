using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectController : MonoBehaviour
{
    Action<GameObject> _KillAction;
    [SerializeField] EnemyStats stats;
    [SerializeField] float destroyTimer = 2f;

    public void Init(Action<GameObject> action)
    {
        _KillAction = action;
    }

    private void Update()
    {
        if(destroyTimer <= 0)
        {
            destroyTimer = 2f;
            _KillAction(this.gameObject);
        }
        else
        {
            destroyTimer -= Time.deltaTime;
        }
    }

}
