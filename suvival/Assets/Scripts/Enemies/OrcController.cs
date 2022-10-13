using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrcController : MonoBehaviour
{
    Animator anim;
    [SerializeField] PlayerController player;
    [SerializeField] GameManager gameManager;
    [SerializeField] float damage;

    private Action<GameObject> _killAction;

    NavMeshAgent agent;
    private void OnEnable()
    {
        gameManager.AddToList(this.gameObject);

    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);

    }

    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //anim.SetBool("Attacking", true);

            _killAction(this.gameObject);
        }
    }
}
