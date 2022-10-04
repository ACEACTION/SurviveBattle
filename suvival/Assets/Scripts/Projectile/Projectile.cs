using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private bool _usedPool;
    private Action<Projectile> _killAction;

    [SerializeField] GameObject hitEffect;
    private ObjectPool<GameObject> pool;

    [SerializeField] float projectileSpeed;

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

    }

    private void Update()
    {
        transform.position += direction * projectileSpeed * Time.deltaTime;
    }
    public void Init(Action<Projectile> killAction)
    {
        _killAction = killAction;
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
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
