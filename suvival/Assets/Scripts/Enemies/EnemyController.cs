using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    public float hp;
    public EnemyStats stats;
    public Transform hitBox;
    [SerializeField] Vector3 offset;
    [SerializeField] EnemyBloodSplat enemyBloodSplat;
    bool attckToPlayer;
    float attckToPlayerCd;

    private void OnEnable()
    {
        hp = stats.hpDefault;
    }
    private void Update()
    {
        if (attckToPlayer)
        {
            attckToPlayerCd -= Time.deltaTime;
            if (attckToPlayerCd <= 0)
            {
                PlayerController.Instance.TakeDamage(stats.damage);
                attckToPlayerCd = stats.attckToPlayerMaxCd;
            }
        }

    }
    public void ReduceHp( float damage)
    {
        hp -= damage;
        if(hp <= 0)        
            Die();        
    }
    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }
    private void Die()
    {
        var lootEffect = stats.lootEffectPool.Get();
        lootEffect.transform.position = transform.position + offset;
        lootEffect.GetComponent<EnemyXpLoot>().Init(stats.KillLootEffect);

        var deathEffect = stats.enemyBloodPool.Get();
        deathEffect.transform.position = transform.position + offset;
        deathEffect.GetComponent<EnemyBloodSplat>().Init(stats.KillDeathEffect,
                stats.enemyBloodSprites[Random.Range(0, stats.enemyBloodSprites.Length)]);
        AudioSourceController.Instance.PlayEnemyBloodsSfx();
      _killAction(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.Instance.RemoveFromList(this.gameObject);
            attckToPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {         
            attckToPlayer = false;
        }
    }

}
