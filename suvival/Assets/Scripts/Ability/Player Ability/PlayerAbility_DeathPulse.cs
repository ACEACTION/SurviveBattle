using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class PlayerAbility_DeathPulse : MonoBehaviour
{
    private ObjectPool<GameObject> pool;

    [SerializeField] GameObject deathPulsePrefab;
    [SerializeField] int enemyCount;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float radius;
    [SerializeField] bool _usedPool;
    [SerializeField] PlayerShooting plShooting;
    [SerializeField] float deathPulseCd;
    [SerializeField] float deathPulseCdAmount;



    private void Start()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(deathPulsePrefab);
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
        deathPulseCd = deathPulseCdAmount;
    }

    private void Update()
    {
        if(deathPulseCd < 0)
        {
            deathPulseCd = deathPulseCdAmount;
            DeathPulseSpawning();
        }
        else
        {
            deathPulseCd -= Time.deltaTime;
        }
    }
    public void DeathPulseSpawning()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemies = plShooting.EnemiesInRange(radius);
            var chosenEnemy = enemies[Random.Range(0, enemies.Length)];
            var deathpulse = _usedPool ? pool.Get() : Instantiate(deathPulsePrefab);
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
}

