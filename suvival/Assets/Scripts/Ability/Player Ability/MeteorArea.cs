using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorArea : MonoBehaviour
{
    Action<GameObject> ReleaseMeteorArea;
    float dmg;
    [SerializeField] SphereCollider collider;
    [SerializeField] LayerMask enemyLayerMask;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        ReleaseMeteorArea(gameObject);
    }
    

    public void InitAction(Action<GameObject> action, float d)
    {
        ReleaseMeteorArea = action;
        dmg = d;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemies = Physics.OverlapSphere(transform.position, collider.radius, enemyLayerMask);

            foreach (var x in enemies)
            {
                var enemy = x.gameObject.GetComponent<EnemyController>();
                enemy.ReduceHp(dmg);
            }
        }
    }

}
