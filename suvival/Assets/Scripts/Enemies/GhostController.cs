using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostController : MonoBehaviour
{


    [SerializeField] EnemyStats enemyStats;


    NavMeshAgent agent;

    private void Start()
    {
        GameManager.instance.AddToList(this.gameObject);

        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyStats.movespeed;
        
    }

    private void Update()
    {
        agent.SetDestination(PlayerShooting.instance.transform.position);

    }

}
