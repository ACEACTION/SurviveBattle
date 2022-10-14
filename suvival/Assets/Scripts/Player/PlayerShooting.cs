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

    [SerializeField] PlayerMovement playerMovement;
    public Collider[] enemies;
    [HideInInspector]public EnemyController closestEnemy;
    public ProjectileStats stats;
    public float xp;
    float attackCd;

    private ObjectPool<Projectile> pool;
    [SerializeField] bool diagonalArrows;
    [SerializeField] bool sidedArrows;


    [SerializeField] Animator anim;
    [SerializeField] float radius;

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] private bool _usedPool;
    [SerializeField] int _spawnAmount = 20;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] LayerMask enemyLayerMask;
    //methods
    private void Start()
    {
        attackCd = stats.attackCdAmount;
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
            attackCd = stats.attackCdAmount;
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

    public EnemyController FindingClosestEnemy()
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
                closestEnemy = enemy.GetComponent<EnemyController>();
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

        
        if (playerMovement.PlayerIsMoving())
        {
            anim.SetBool("AttackingRun", true);
            anim.SetLayerWeight(1, .5f);
        }
        else
        {
            anim.SetBool("AttackingRun", false);
            anim.SetBool("Attacking", true);
            anim.SetLayerWeight(1, 0);
        }


        var projectile = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        
        projectile.transform.position = bulletSpawnPoint.position;
        projectile.direction = (closestEnemy.hitBox.transform.position - bulletSpawnPoint.transform.position).normalized;
        projectile.direction.y = 0;
        projectile.transform.LookAt(closestEnemy.transform);
        projectile.transform.Rotate(0, +90f, 0);

        projectile.Init(KillProjectile);

        //sided and diagonal arrows here
        if(stats.diagonalArrows) DiagonalArrows(projectile);
        if (stats.sidedArrows) sideArrows(projectile);

    }

    private void sideArrows(Projectile projectile)
    {
        //left projectile
        var projLeft = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        projLeft.transform.position = bulletSpawnPoint.position;

        projLeft.direction = Quaternion.AngleAxis(-75, Vector3.up * 10) * projectile.direction;
        projLeft.transform.rotation = projectile.transform.rotation;
        projLeft.transform.Rotate(0, -75, 0);

        projLeft.Init(KillProjectile);

        //right projectile
        var projRight = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        projRight.transform.position = bulletSpawnPoint.position;

        projRight.direction = Quaternion.AngleAxis(75, Vector3.up * 10) * projectile.direction;
        projRight.transform.rotation = projectile.transform.rotation;
        projRight.transform.Rotate(0, +75, 0);
        projRight.Init(KillProjectile);
    }

    public void DiagonalArrows(Projectile projectile)
    {
        //left projectile
        var projLeft = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        projLeft.transform.position = bulletSpawnPoint.position;
        
        projLeft.direction = Quaternion.AngleAxis(-25, Vector3.up * 10) * projectile.direction;
        projLeft.transform.rotation = projectile.transform.rotation;
        projLeft.transform.Rotate(0, -25, 0);

        projLeft.Init(KillProjectile);

        //right projectile
        var projRight = _usedPool ? pool.Get() : Instantiate(projectilePrefab);
        projRight.transform.position = bulletSpawnPoint.position;
        projRight.direction = Quaternion.AngleAxis(25, Vector3.up * 10) * projectile.direction; ;
        projRight.transform.rotation = projectile.transform.rotation;
        projRight.transform.Rotate(0, +25, 0);
        projRight.Init(KillProjectile);

    }
    private void KillProjectile(Projectile projectile)
    {
        if (_usedPool) pool.Release(projectile);
        else Destroy(projectile.gameObject);
    }
}
