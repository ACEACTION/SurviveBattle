using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using Random = UnityEngine.Random;

public class PlayerAbility_DeathPulse : MonoBehaviour
{
    float deathPulseCd;
    private ObjectPool<GameObject> pool;

    [SerializeField] GameObject deathPulsePrefab;
    [SerializeField] DpStats stats;
    [SerializeField] float radius;
    [SerializeField] Transform spawnPoint;
    [SerializeField] bool _usedPool;
    bool abilityIsActive;

    public static Action DoActiveAbilityAction;


    private void Start()
    {
        DoActiveAbilityAction = DoActiveAbility;
        deathPulseCd = stats.maxDeathPulseCd;

        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(deathPulsePrefab);
        }, deathPulse =>
        {
            deathPulse.gameObject.SetActive(true);
        }, deathPulse =>
        {
            deathPulse.gameObject.SetActive(false);
        }, deathPulse =>
        {
            Destroy(deathPulse.gameObject);
        }, false, 10, 20);

    }

    private void Update()
    {
        if (abilityIsActive)
        {
            if (deathPulseCd < 0)
            {
                deathPulseCd = stats.maxDeathPulseCd;
                DeathPulseSpawning();
            }
            else
            {
                deathPulseCd -= Time.deltaTime;
            }
        }
    }
    public void DeathPulseSpawning()
    {
        for (int i = 0; i < stats.count; i++)
        {
            var enemies = PlayerShooting.instance.EnemiesInRange(radius);
            if (enemies.Length <= 0) return;

            var chosenEnemy = enemies[Random.Range(0, enemies.Length)];
            var deathpulse = pool.Get();
            deathpulse.transform.position = spawnPoint.transform.position;
            deathpulse.GetComponent<DeathPulseController>().destination = chosenEnemy.transform;
            deathpulse.GetComponent<DeathPulseController>().Init(KillDeathPulse);
        }

    }

    private void KillDeathPulse(GameObject obj)
    {
        if (_usedPool) pool.Release(obj);
        else Destroy(obj.gameObject);
    }

    void DoActiveAbility()
    {
        abilityIsActive = true;
    }

}

