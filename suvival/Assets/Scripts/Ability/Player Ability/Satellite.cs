using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField] SatelliteStats stats;

    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, 
            stats.satelliteSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>()?.ReduceHp(stats.dmg);
        }
    }

}
