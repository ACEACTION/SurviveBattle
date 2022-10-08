using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using Random = UnityEngine.Random;

public class PlayerAbility_Lightning : MonoBehaviour
{
    private ObjectPool<GameObject> pool;
    [SerializeField] GameObject lightningPrefab;
    [SerializeField] LightninStats stats;
    [SerializeField] Vector3 offset;
    [SerializeField] bool _usedPool;
    bool activeAbility;
    float cd;

    public static Action DoActiveAbilityAction;

    

    private void Start()
    {
        DoActiveAbilityAction = DoActiveAbility;

        // object pool
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(lightningPrefab);
        }, lightning =>
        {
            lightning.gameObject.SetActive(true);
        }, lightning =>
        {
            lightning.gameObject.SetActive(false);
        }, lightning =>
        {
            Destroy(lightning.gameObject);
        }, false, 10, 20);

    }

    private void Update()
    {
        if (activeAbility)
        {
            if (cd < 0)
            {
                cd = stats.maxCd;
                LightningSpawn();
            }
            else cd -= Time.deltaTime;
        }
    }

    public void LightningSpawn()
    {
        var enemies = PlayerShooting.instance.EnemiesInRange(stats.radius);
        if (enemies.Length <= 0) return;
        
        var lightning = _usedPool ? pool.Get() : Instantiate(lightningPrefab);
        var chosenEnemy = enemies[Random.Range(0, enemies.Length)];
        lightning.transform.position = chosenEnemy.transform.position + offset;
        lightning.GetComponent<LightningController>().Init(KillProjectile, stats.radius);
    }

    private void KillProjectile(GameObject obj)
    {
        if (_usedPool) pool.Release(obj);
        else Destroy(obj.gameObject);
    }

    void DoActiveAbility()
    {
        activeAbility = true;
    }

}
