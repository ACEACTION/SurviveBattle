using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    [SerializeField] LightninStats stats;
    [SerializeField] float destroyCd;
    [SerializeField] bool _destroyActivator;
    [SerializeField] LayerMask enemyLayerMask;
    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;        
    }

    void Update()
    {
        if (_destroyActivator)
        {
            destroyCd -= Time.deltaTime;
            if (destroyCd < 0)
            {
                _destroyActivator = false;
                destroyCd = 1f;
                _killAction(this.gameObject);

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            var enemies = Physics.OverlapSphere(transform.position, stats.aoeRadius, enemyLayerMask);

            foreach (var x in enemies)
            {
                var enemy = x.gameObject.GetComponent<EnemyController>();
                enemy.ReduceHp(stats.damage);
                AudioSourceController.Instance.PlayLightningSfx();
            }
            _destroyActivator = true;
        }
    }


}
