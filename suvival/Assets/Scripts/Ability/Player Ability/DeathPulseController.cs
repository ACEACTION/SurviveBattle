using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DeathPulseController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    [SerializeField] PlayerShooting plShooting;
    [SerializeField] float destroyTimer;
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
        if(other.gameObject.CompareTag("Enemy"))
        _killAction(this.gameObject);
    }


}