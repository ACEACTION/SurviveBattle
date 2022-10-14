using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    public float hp;
    public EnemyStats stats;
    public Transform hitBox;
    
    [SerializeField] EnemyBloodSplat enemyBloodSplat;
    bool attckToPlayer;
    float attckToPlayerCd;
    [SerializeField] NavMeshAgent agent;

    private void OnEnable()
    {
        hp = 0;
        hp += stats.hp;
    }

    private void Update()
    {
        if (PlayerController.Instance.playerIsDead) return;

        if (DistanceToPlayer() <= agent.stoppingDistance)
        {
            attckToPlayerCd -= Time.deltaTime;
            if (attckToPlayerCd <= 0)
            {
                PlayerController.Instance.TakeDamage(stats.damage);
                attckToPlayerCd = stats.attckToPlayerMaxCd;
            }
        }

        if(DistanceToPlayer() >= stats.maxDistToPlayer)
        {
            _killAction(this.gameObject);
        }

    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(PlayerController.Instance.transform.position, transform.position);
    }

    public void ReduceHp( float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }
    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }
    private void Die()
    {
        var lootEffect = stats.lootEffectPool.Get();
        lootEffect.transform.position = transform.position + stats.lootOffset;
        lootEffect.GetComponent<EnemyXpLoot>().Init(stats.KillLootEffect);

        var deathEffect = stats.enemyBloodPool.Get();
        deathEffect.transform.position = transform.position + stats.bloodSplatOffset;
        deathEffect.GetComponent<EnemyBloodSplat>().Init(stats.KillDeathEffect,
                stats.enemyBloodSprites[Random.Range(0, stats.enemyBloodSprites.Length)]);

        AudioSourceController.Instance.PlayEnemyBloodsSfx();
        GameManager.Instance.RemoveFromList(this.gameObject);
        _killAction(gameObject);
    }    

}
