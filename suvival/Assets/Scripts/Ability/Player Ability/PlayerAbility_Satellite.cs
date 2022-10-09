using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAbility_Satellite : MonoBehaviour
{

    int satelliteCounter;
    [SerializeField] SatelliteCenter satelliteCenterPrefab;
    SatelliteCenter satelliteCenter;

    public static Action AddSatellite;

    private void Start()
    {
        AddSatellite = SatelliteCountProcess;
    }

    void SatelliteCountProcess()
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

}
