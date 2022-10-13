using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { Spawnign, Waiting };
    public SpawnState state = SpawnState.Waiting;
    [SerializeField] int orcCount = 1;
    [SerializeField] EnemyMultiplier enemyMultiplier;

    private ObjectPool<GameObject> pool;
    [SerializeField] private bool _usedPool;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float radius;
    [SerializeField] int enemiesAmount;
    int enemyPrefabIndex;
    private void OnEnable()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemyPrefabs[enemyPrefabIndex]);
        }, enemy =>
        {
            enemy.gameObject.SetActive(true);
        }, enemy =>
        {
            enemy.gameObject.SetActive(false);
        }, enemy =>
        {
            Destroy(enemy.gameObject);
        }, false, 10, 20);
    }



    private void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (GameManager.Instance.enemiesList.Count <= enemiesAmount)
            {
                StartCoroutine(Spawn());
            }
        }
    }

    IEnumerator Spawn()
    {
        state = SpawnState.Spawnign;

            yield return new WaitForSeconds(enemyMultiplier.cdBetweenSpawnsMultiplier);
            if(orcCount % 10 == 0)
            {
                enemyPrefabIndex = 1;
                orcCount++;
                var enemy = _usedPool ? pool.Get() : Instantiate(enemyPrefabs[1]);
                enemy.GetComponent<EnemyController>().stats.hp = enemyMultiplier.GetHpMultiplier();
                enemy.transform.position = PlayerController.Instance.spawnPoints[Random.Range(0, PlayerController.Instance.spawnPoints.Length)].position;
                enemy.GetComponent<EnemyController>().Init(KillEnemy);
            }
            else
            {
                enemyPrefabIndex = 0;
                orcCount++;
                var enemy = _usedPool ? pool.Get() : Instantiate(enemyPrefabs[0]);
                enemy.GetComponent<EnemyController>().stats.hp = enemyMultiplier.GetHpMultiplier();
                enemy.transform.position = 
                    PlayerController.Instance.spawnPoints[Random.Range(0, PlayerController.Instance.spawnPoints.Length)].position;
                enemy.GetComponent<EnemyController>().Init(KillEnemy);
        }

        state = SpawnState.Waiting;

    }

    private void KillEnemy(GameObject enemy)
    {
        if (_usedPool) pool.Release(enemy);
    }


}
