using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAbility_Satellite : MonoBehaviour
{

    [SerializeField] SatelliteCenter satelliteCenterPrefab;
    SatelliteCenter satelliteCenter;


    
    public delegate PlayerAbility_Satellite GetPlayerAbilitySatelliteDelegate();
    public static GetPlayerAbilitySatelliteDelegate GetPlayerAbilitySatellite;

    private void Start()
    {
        GetPlayerAbilitySatellite = GetPlayerAbility;
    }

    PlayerAbility_Satellite GetPlayerAbility()
    {
        return this;
    }

    public void ActiveLevel1()
    {
        satelliteCenter = Instantiate(satelliteCenterPrefab, transform.position, Quaternion.identity);
        satelliteCenter.player = transform;
    }

    public void ActiveLevel2()
    {
        satelliteCenter.ActiveLevel2();
    }

    public void ActiveLevel3()
    {
        satelliteCenter.ActiveLevel3();
    }  

    public void UpgradeSpeed(float speed)
    {
        satelliteCenter.UpgradeSpeed(speed);
    }

}
