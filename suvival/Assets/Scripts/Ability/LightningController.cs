using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    private Action<GameObject> _killAction;
    [SerializeField] float radius;
    [SerializeField] float destroyCd;
    [SerializeField] bool _destroyActivator;

    public void Init(Action<GameObject> killAction, float radius)
    {
        _killAction = killAction;
        this.radius = radius;
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
            foreach(var enemy in PlayerShooting.instance.EnemiesInRange(radius))
            {
                //dmg them
                print(enemy.name);
            }
            _destroyActivator = true;
        }
    }
}
