using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField] float rotSpeed;

    void Start()
    {
        
    }
     
    
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, rotSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // destroy enemy
        }
    }

}
