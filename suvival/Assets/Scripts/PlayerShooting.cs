using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class PlayerShooting : MonoBehaviour
{
    //variables
    private ObjectPool<Projectile> pool;
    public float attackSpeed;
    public float attackCd;
    [SerializeField] bool DiagonalArrows;

    Animator anim;
    [SerializeField] float radius;
    [SerializeField] float attackCdAmount;

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] private bool _usedPool;
    [SerializeField] int _spawnAmount = 20;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] LayerMask enemyLayerMask;
    //methods
    private void Start()
    {
        attackCd = attackCdAmount;
        pool = new ObjectPool<Projectile>(() =>
        {
            return Instantiate(projectilePrefab);
        }, projectile =>
            {
                projectile.gameObject.SetActive(true);
            }, projectile =>
            {
                projectile.gameObject.SetActive(false);
            }, projectil =>
            {
                Destroy(projectil.gameObject);
            }, false, 10, 20);

    }

    private void Update()
    {
        if(attackCd <= 0)
        {
            //attack here
            attackCd = attackCdAmount;


            Fire();
        }
        else
        {

            attackCd -= Time.deltaTime;
        }
    }

    void Fire()
    {
        float distanceToClosestEnemy = 1000;
        GameObject closestEnemy = null; 
            //finding the closest enemy
        var enemies = Physics.OverlapSphere(transform.position, radius, enemyLayerMask);
        foreach(var enemy in enemies)
        {
            float distanceToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = enemy.gameObject;
            }
        }
        var projectile = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        if(projectile)
        projectile.transform.position = bulletSpawnPoint.position;
        projectile.direction = closestEnemy.transform.position - transform.position;
        projectile.direction.y = 0;
        projectile.Init(KillProjectile);
        
    }

    private void KillProjectile(Projectile projectile)
    {
        if (_usedPool) pool.Release(projectile);
        else Destroy(projectile.gameObject);
    }
}
