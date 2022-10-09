using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using Random = UnityEngine.Random;

public class PlayerAbility_Meteor : MonoBehaviour
{
    [SerializeField] float randomOffsetScale;
    [SerializeField] GameObject meteorPrefab;
    public ObjectPool<GameObject> meteorPool;
    bool activeAbility;
    [SerializeField] MeteorStats stats;
    float cd;

    public static Action DoActiveAbilityAction;

    void Start()
    {
        meteorPool = new ObjectPool<GameObject>(CreateMeteor, OnGet, OnRelease, OnDestoryMeteor, false, 100, 100000);
        cd = stats.maxCd;
        DoActiveAbilityAction = DoActiveAbility;
    }


    private void OnDestoryMeteor(GameObject obj)
    {
        Destroy(obj);
    }

    private void OnRelease(GameObject obj)
    {
        obj.transform.position = GetRandomPos();
        obj.SetActive(false);        
    }

    private void OnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    private GameObject CreateMeteor()
    {
        GameObject meteor = Instantiate(meteorPrefab, GetRandomPos(), Quaternion.identity);
        return meteor;
    }

    public void OnReleaseMeteor(GameObject meteor)
    {
        meteorPool.Release(meteor);
    }


    void Update()
    {
        if (activeAbility)
        {
            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                MakeMeteor();
                cd = stats.maxCd;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))    
            MakeMeteor();
    }


    void MakeMeteor()
    {
        for (int i = 0; i < stats.counter; i++)
        {
            Meteor meteor = meteorPool.Get().GetComponent<Meteor>();
            meteor.InitMeteor(OnReleaseMeteor);
        }
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(transform.position.x - randomOffsetScale, 
                                transform.position.x + randomOffsetScale),
                           transform.position.y + 30,
                           Random.Range(transform.position.z - randomOffsetScale, 
                            transform.position.z + randomOffsetScale));
    }

    void DoActiveAbility()
    {
        activeAbility = true;
    }


}
