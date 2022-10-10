using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        if(stats.hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var deathEffect = stats.DeathEffectPool.Get();
        deathEffect.transform.position = transform.position + offset;
        deathEffect.GetComponent<DeathEffectController>().Init(stats.KillDeathEffect);
    }

}
