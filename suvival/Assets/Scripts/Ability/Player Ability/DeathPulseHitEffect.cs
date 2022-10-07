using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPulseHitEffect : MonoBehaviour
{
    Action<GameObject> releaseDeathPulseHitEffect;
    [SerializeField] float destroyCd;
    [SerializeField] bool _destroyActivator;

    private void Update()
    {
        if (_destroyActivator)
        {
            destroyCd -= Time.deltaTime;
            if (destroyCd < 0)
            {
                _destroyActivator = false;
                destroyCd = 1f;
                releaseDeathPulseHitEffect(this.gameObject);

            }
        }
    }


    public void Init(Action<GameObject> action)
    {
        releaseDeathPulseHitEffect = action;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _destroyActivator = true;
        }
    }
}
