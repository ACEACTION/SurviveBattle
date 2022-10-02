using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility_Meteor : MonoBehaviour
{
    [SerializeField] float randomOffsetScale;
    [SerializeField] GameObject meteorPrefab;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))    
            MakeMeteor();

    }



    void MakeMeteor()
    {
        Instantiate(meteorPrefab, transform.position + GetRandomPos(), Quaternion.identity);
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-randomOffsetScale, randomOffsetScale),
                           Random.Range(transform.position.y + 2, randomOffsetScale),
                           Random.Range(-randomOffsetScale, randomOffsetScale));
    }

}
