using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAbility_Lightning : MonoBehaviour
{
    private ObjectPool<GameObject> pool;
    [SerializeField] GameObject lightningPrefab;
    [SerializeField] float radius;
    [SerializeField] Vector3 offset;
    [SerializeField] bool _usedPool;
    [SerializeField] float lightningCd;
    [SerializeField] float lightningCdAmount;



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
        /* if (lightningCd < 0)
         {
             lightningCd = lightningCdAmount;
             LightningSpawn();
         }
         else lightningCd -= Time.deltaTime;
 */
        if (Input.GetKeyDown(KeyCode.V)) LightningSpawn();
    }

    public void LightningSpawn()
    {
        var lightning = _usedPool ? pool.Get() : Instantiate(lightningPrefab);
        var enemies = PlayerShooting.instance.EnemiesInRange(radius);
        var chosenEnemy = enemies[Random.Range(0, enemies.Length)];
        lightning.transform.position = chosenEnemy.transform.position + offset;
        lightning.GetComponent<LightningController>().Init(KillProjectile);
    }

    private void KillProjectile(GameObject obj)
    {
        if (_usedPool) pool.Release(obj);
        else Destroy(obj.gameObject);
    }
}
