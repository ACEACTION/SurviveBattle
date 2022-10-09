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
    public static Action DoActiveAbilityAction;

    private void Start()
    {
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
            if (stats.maxCd < 0)
            {
                stats.maxCd = stats.maxCdDefault;
                LightningSpawn();
            }
            else stats.maxCd -= Time.deltaTime;
        }
    }

    public void LightningSpawn()
    {
        var lightning = _usedPool ? pool.Get() : Instantiate(lightningPrefab);
        var enemies = PlayerShooting.instance.EnemiesInRange(stats.radius);
        var chosenEnemy = enemies[Random.Range(0, enemies.Length)];
        lightning.transform.position = chosenEnemy.transform.position + offset;
        lightning.GetComponent<LightningController>().Init(KillProjectile, stats.radius);
    }

    private void KillProjectile(GameObject obj)
    {
        if (_usedPool) pool.Release(obj);
        else Destroy(obj.gameObject);
    }

    public void DoActiveAbility()
    {
        activeAbility = true;
    }

}
