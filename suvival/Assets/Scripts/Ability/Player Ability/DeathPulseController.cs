using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DeathPulseController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    [SerializeField] float destroyTimer;
    [SerializeField] DeathPulseStats dpStats;
    [SerializeField] DpStats stats;
    [SerializeField] Vector3 offset;
    NavMeshAgent agent;
    public Transform destination;
    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        if (destination != null)
        {
            agent.SetDestination(destination.position);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DeathPulseHitEffect dpEffect = dpStats.deathPulseHitEffectPool.Get().GetComponent<DeathPulseHitEffect>();
            dpEffect.transform.position = transform.position + offset;
            dpEffect.Init(dpStats.KillDeathPulseEffect);

            //dealing damage here
            var enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.ReduceHp(stats.dmg);
            _killAction(this.gameObject);
        }
    }


}