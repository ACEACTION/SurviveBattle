using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class PlayerShooting : MonoBehaviour
{
    //variables
    public static PlayerShooting instance;
    private void Awake()
    {
        if(instance == null)
        instance = this;
    }
    public Collider[] enemies;
    public GameObject closestEnemy;


    private ObjectPool<Projectile> pool;
    public float attackSpeed;
    public float attackCd;
    [SerializeField] bool diagonalArrows;

    [SerializeField] Animator anim;
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
    public Collider[] EnemiesInRange(float range)
    {
        return enemies = Physics.OverlapSphere(transform.position, range, enemyLayerMask);

    }

    public GameObject FindingClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        closestEnemy = null;
        EnemiesInRange(radius);
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = enemy.gameObject;
            }
        }
        return closestEnemy;
    }
    void Fire()
    {
        //finding closest enemy here
        FindingClosestEnemy();

        if (closestEnemy == null)
        {
            anim.SetBool("Attacking", false);
            anim.SetLayerWeight(1, 0);
            return;
        }

        anim.SetBool("Attacking", true);
        anim.SetLayerWeight(1, .5f);
        var projectile = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        
        projectile.transform.position = bulletSpawnPoint.position;
        projectile.direction = closestEnemy.transform.position - transform.position;
        projectile.direction.y = 0;
        projectile.Init(KillProjectile);
        if (diagonalArrows)
        {
            //diagonal arrows here
            DiagonalArrows(projectile);
        }
    }

    public void DiagonalArrows(Projectile projectile)
    {
        //left projectile
        var projLeft = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        projLeft.transform.position = bulletSpawnPoint.position;
        
        projLeft.direction = Quaternion.AngleAxis(-25, Vector3.up * 10) * projectile.direction;

        projLeft.Init(KillProjectile);

        //right projectile
        var projRight = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        projRight.transform.position = bulletSpawnPoint.position;
        projRight.direction = Quaternion.AngleAxis(25, Vector3.up * 10) * projectile.direction; ;

        projRight.Init(KillProjectile);

    }
    private void KillProjectile(Projectile projectile)
    {
        if (_usedPool) pool.Release(projectile);
        else Destroy(projectile.gameObject);
    }
}
