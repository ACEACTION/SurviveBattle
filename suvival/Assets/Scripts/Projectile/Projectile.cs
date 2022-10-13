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
        destroyTimerCd = stats.projectileDestroyTime;
    }

    private void OnEnable()
    {
        destroyTimerCd = stats.projectileDestroyTime;

    }

    private void Update()
    {
        transform.position += direction * stats.projecMoveSpeed * Time.deltaTime;
        if (destroyTimerCd <= 0)
        {
            destroyTimerCd = stats.projectileDestroyTime;
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
            var enemy = col.gameObject.GetComponent<EnemyController>();

            var hiteffect = _usedPool ? pool.Get() : Instantiate(hitEffect);
            hiteffect.transform.position = col.transform.position;
            enemy?.ReduceHp(stats.damage);

            hiteffect.GetComponent<ProjectileHitEffect>().Init(KillEffect);
            _killAction(this);
        }

    }

    private void KillEffect(GameObject effect)
    {
        if (_usedPool) pool.Release(effect);
    }
}
