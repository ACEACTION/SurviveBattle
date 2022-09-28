using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAbility_Satellite : MonoBehaviour
{

    int satelliteCounter;
    [SerializeField] SatelliteCenter satelliteCenterPrefab;
    SatelliteCenter satelliteCenter;

    public delegate void PlayerSatelliteAbilityDel();
    public static PlayerSatelliteAbilityDel PlayerAbilitySatellite;

    public static Action<float> UpgradeSatelliteSpeed;

    private void Start()
    {
        PlayerAbilitySatellite = SatelliteProcess;
        UpgradeSatelliteSpeed = UpgradeSpeed;
    }

    void SatelliteProcess()
    {
        if (satelliteCounter == 0)
        {
            satelliteCenter = Instantiate(satelliteCenterPrefab, transform.position, Quaternion.identity);
            satelliteCenter.player = transform;
        }
        else if (satelliteCounter == 1)
        {
            satelliteCenter.ActiveLevel2();
        }
        else if (satelliteCounter == 2)
        {
            satelliteCenter.ActiveLevel3();
        }

        satelliteCounter++;
    }

    void UpgradeSpeed(float speed)
    {
        satelliteCenter.UpgradeSpeed(speed);
    }

}
