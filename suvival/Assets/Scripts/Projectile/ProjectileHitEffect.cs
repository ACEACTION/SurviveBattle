using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitEffect : MonoBehaviour
{
    [SerializeField] float lifeTime = 1.2f;
    private Action<GameObject> _killAction;
    public void Init(Action<GameObject> killAction)
    {
        _killAction = killAction;
    }

    private void Update()
    {
        if(lifeTime <= 0)
        {
            lifeTime = 1.2f;
            _killAction(this.gameObject);

        }
        else lifeTime -= Time.deltaTime; 
    }
}
