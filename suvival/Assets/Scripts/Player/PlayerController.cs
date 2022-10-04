using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    [SerializeField] float hp;
    public Transform[] spawnPoints;
    //methods
    public void TakeDamage(float damage)
    {
        if(hp >= damage) hp -= damage; 
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Died();
        }
    }

    void Died()
    {
        Destroy(this.gameObject);
    }
}
