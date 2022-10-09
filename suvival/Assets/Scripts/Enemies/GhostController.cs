using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostController : MonoBehaviour
{


    [SerializeField] EnemyStats enemyStats;
    [SerializeField] GameManager gameManager;
    [SerializeField] float damage;

    private Action<GameObject> _killAction;

    NavMeshAgent agent;

    private void Start()
    {
        gameManager.AddToList(this.gameObject);

        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyStats.movespeed;
        
    }

    private void Update()
    {
        agent.SetDestination(PlayerShooting.instance.transform.position);

    }

    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameManager.RemoveFromList(this.gameObject);

            _killAction(this.gameObject);
        }
    }
}
