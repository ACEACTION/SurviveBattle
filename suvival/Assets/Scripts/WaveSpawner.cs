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

    private ObjectPool<GameObject> pool;
    [SerializeField] private bool _usedPool;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float radius;
    [SerializeField] int enemiesAmount;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float cdBetweenSpawns;
    [SerializeField] GameManager gameManager;
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
            if (gameManager.enemiesList.Count <= enemiesAmount)
            {
                StartCoroutine(Spawn());
            }

        }

    }



    IEnumerator Spawn()
    {
        state = SpawnState.Spawnign;

            yield return new WaitForSeconds(cdBetweenSpawns);
            if(orcCount % 10 == 0)
            {
                enemyPrefabIndex = 1;
                orcCount++;
                var enemy = _usedPool ? pool.Get() : Instantiate(enemyPrefabs[1]);
                enemy.transform.position = player.spawnPoints[Random.Range(0, player.spawnPoints.Length)].position;
                enemy.GetComponent<GhostController>().Init(KillEnemy);
            }
            else
            {
                enemyPrefabIndex = 0;
                orcCount++;
                var enemy = _usedPool ? pool.Get() : Instantiate(enemyPrefabs[0]);
                enemy.transform.position = player.spawnPoints[Random.Range(0, player.spawnPoints.Length)].position;
                enemy.GetComponent<GhostController>().Init(KillEnemy);
            }



        state = SpawnState.Waiting;

    }

    private void KillEnemy(GameObject enemy)
    {
        if (_usedPool) pool.Release(enemy);
    }


}
