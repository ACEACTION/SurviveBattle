using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using Random = UnityEngine.Random;

public class PlayerAbility_Meteor : MonoBehaviour
{
    // variables
    [SerializeField] float randomOffsetScale;    
    [SerializeField] float makeMeteorCd;
    bool activeAbility;

    // references
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] MeteorStats meteorStats;
    public ObjectPool<GameObject> meteorPool;
    public static Action DoActiveAbilityAction;

    void Start()
    {
        makeMeteorCd = meteorStats.maxMakeMeteorCd;
        meteorPool = new ObjectPool<GameObject>(CreateMeteor, OnGet, OnRelease, OnDestoryMeteor, false, 100, 100000);
        DoActiveAbilityAction = DoActiveAbility;
    }

    #region pool object
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
        obj.transform.position = GetRandomPos();
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
    #endregion

    void Update()
    {
        if (activeAbility)
        {
            makeMeteorCd -= Time.deltaTime;
            if (makeMeteorCd <= 0)
            {
                MakeMeteor();
                makeMeteorCd = meteorStats.maxMakeMeteorCd;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))    
            MakeMeteor();
    }


    void MakeMeteor()
    {
        for (int i = 0; i < meteorStats.meteorCounter; i++)
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
