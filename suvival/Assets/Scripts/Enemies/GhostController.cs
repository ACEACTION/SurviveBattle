using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostController : MonoBehaviour
{
    NavMeshAgent agent;

    private void Start()
    {
        GameManager.Instance.AddToList(this.gameObject);

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(PlayerShooting.instance.transform.position);

    }

}
