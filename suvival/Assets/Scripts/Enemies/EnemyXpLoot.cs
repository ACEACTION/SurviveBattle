using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXpLoot : MonoBehaviour
{
    Action<GameObject> releaseLoot;
    [SerializeField] EnemyStats stats;
    public void Init(Action<GameObject> action)
    {
        releaseLoot = action;
    }

    private void Update()
    {
        if(Vector3.Distance( PlayerShooting.instance.transform.position, this.transform.position) <= 15f)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerShooting.instance.transform.position, 40f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddXp(stats.xpAmount);
            releaseLoot(this.gameObject);
        }
    }
}
