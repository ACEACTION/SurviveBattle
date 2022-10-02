using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorArea : MonoBehaviour
{

    void Start()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // dmg to enemy
        }
    }

}
