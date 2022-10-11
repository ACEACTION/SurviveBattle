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
    [SerializeField] bool activeAbility;
    public static Action DoActiveAbilityAction;
    float cd;

    private void Start()
    {
        DoActiveAbilityAction = DoActiveAbility;
        cd = stats.maxCd;

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
                cd = stats.maxCdDefault;
                LightningSpawn();
            }
            else cd -= Time.deltaTime;
        }
    }

    public void LightningSpawn()
    {
        var lightning = pool.Get();
        var enemies = PlayerShooting.instance.EnemiesInRange(stats.radius);

        if (enemies.Length <= 0) return;

        var chosenEnemy = enemies[Random.Range(0, enemies.Length)];
        lightning.transform.position = chosenEnemy.transform.position + offset;
        lightning.GetComponent<LightningController>().Init(KillProjectile, stats.radius);
    }

    private void KillProjectile(GameObject obj)
    {
         pool.Release(obj);
;
    }

    public void DoActiveAbility()
    {
        activeAbility = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, stats.radius);
    }
}
