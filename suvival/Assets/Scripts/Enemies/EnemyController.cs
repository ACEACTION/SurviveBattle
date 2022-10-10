using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    public float hp;
    public EnemyStats stats;
    [SerializeField] Vector3 offset;

    private void OnEnable()
    {
        hp = stats.hpDefault;
    }
    private void Update()
    {
        if(hp <= 0)
        {
            Die();

        }
    }
    public void ReduceHp( float damage)
    {
        hp -= damage;
    }
    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }
    private void Die()
    {
       // var deathEffect = stats.DeathEffectPool.Get();
      //  deathEffect.transform.position = transform.position + offset;
       // deathEffect.GetComponent<DeathEffectController>().Init(stats.KillDeathEffect);
        _killAction(this.gameObject);


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.instance.RemoveFromList(this.gameObject);

        }
    }

}
