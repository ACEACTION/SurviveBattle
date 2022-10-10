using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public ProjectileStats stats;
    [SerializeField] private bool _usedPool;
    [SerializeField] float destroyTimerCd;
    [SerializeField] float destroyTimerCdAmount;
    private Action<Projectile> _killAction;

    [SerializeField] GameObject hitEffect;
    private ObjectPool<GameObject> pool;

    private void Start()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(hitEffect);
        }, hitEffect =>
        {
            hitEffect.gameObject.SetActive(true);
        }, hitEffect =>
        {
            hitEffect.gameObject.SetActive(false);
        }, hitEffect =>
        {
            Destroy(hitEffect.gameObject);
        }, false, 10, 20);
        destroyTimerCd = destroyTimerCdAmount;
    }

    private void Update()
    {
        transform.position += direction * stats.moveSpeed * Time.deltaTime;
        if (destroyTimerCd <= 0)
        {
            destroyTimerCd = destroyTimerCdAmount;
            _killAction(this);
        }
        else
            destroyTimerCd -= Time.deltaTime;


    }
    public void Init(Action<Projectile> killAction)
    {
        _killAction = killAction;
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyController>().stats.ReduceHp(stats.damage);
            var hiteffect = _usedPool ? pool.Get() : Instantiate(hitEffect);
            hiteffect.transform.position = col.transform.position;
            hiteffect.GetComponent<ProjectileHitEffect>().Init(KillEffect);
            _killAction(this);
        }

    }

    private void KillEffect(GameObject effect)
    {
        if (_usedPool) pool.Release(effect);
    }
}
