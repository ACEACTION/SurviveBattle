using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorArea : MonoBehaviour
{
    Action<GameObject> ReleaseMeteorArea;
    float dmg;
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
            other.GetComponent<EnemyController>()?.ReduceHp(dmg);
        }
    }

}
